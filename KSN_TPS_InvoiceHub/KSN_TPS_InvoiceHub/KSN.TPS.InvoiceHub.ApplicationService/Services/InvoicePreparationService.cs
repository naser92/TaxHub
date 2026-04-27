using FluentValidation;
using KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice;
using KSN.TPS.InvoiceHub.ApplicationService.Dto;
using KSN.TPS.InvoiceHub.ApplicationService.Services;
using KSN.TPS.InvoiceHub.Domain;
using System.Text.Json;

namespace KSN.TPS.InvoiceHub.ApplicationService
{
    public class InvoicePreparationService : IInvoicePreparationService
    {
        private AbstractValidator<InvoiceImportFromApiVM> _validatorInvoice;

        public InvoicePreparationService(AbstractValidator<InvoiceImportFromApiVM> validatorInvoice)
        {
            _validatorInvoice = validatorInvoice;
        }

        public async Task<InvoiceBatchPreparationResult> PrepareAsync(List<InvoiceImportFromApiVM> invoices, Guid sellerUserContainerId)
        {
            var batchId = Ulid.NewUlid().ToGuid();
            var inboxList = new List<InvoiceInbox>();
            var responseList = new List<InvoiceResponseDto>();

            var invoiceBatch = new InvoiceBatch
            {
                Id = batchId,
                InsertBaseType = 1, // 1 = API 
                UserContainerId = sellerUserContainerId,
                TotalInvoiceCount = invoices.Count,

            };

            foreach (var invoice in invoices)
            {
                var trackingUlid = Ulid.NewUlid();
                var trackingIdGuid = trackingUlid.ToGuid();
                var trackingIdString = trackingIdGuid.ToString();

                var validationResult = await _validatorInvoice.ValidateAsync(invoice);

                //var validationResult = new { IsValid = true, Errors = new List<dynamic>() };

                var errorsDictionary = new Dictionary<string, List<string>>();
                string processResultJson = null;

                if (!validationResult.IsValid)
                {

                    errorsDictionary = validationResult.Errors
                        .GroupBy(e => (string)e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => (string)e.ErrorMessage).ToList()
                        );


                    processResultJson = JsonSerializer.Serialize(errorsDictionary);
                }

                var inboxRecord = new InvoiceInbox
                {
                    Id = trackingIdGuid,
                    BatchId = batchId,
                    UserContainerId = sellerUserContainerId,
                    InvoiceNumber = invoice.InvoiceNumber,
                    InvoiceDate = invoice.InvoiceDate,
                    Payload = JsonSerializer.Serialize(invoice),
                    Status = validationResult.IsValid ? (byte)0 : (byte)3, // 0 = Pending, 3 = Failed
                    ProcessResult = processResultJson,

                };

                inboxList.Add(inboxRecord);
                responseList.Add(new InvoiceResponseDto
                {
                    TrackingId = trackingIdString,
                    InvoiceNumber = invoice.InvoiceNumber,
                    InvoiceDate = invoice.InvoiceDate,
                    IsValid = validationResult.IsValid,
                    Errors = errorsDictionary
                });
            }

            return new InvoiceBatchPreparationResult
            {
                Batch = invoiceBatch,
                Inboxes = inboxList,
                ResponseItems = responseList
            };


        }
    }
}
