using KSN.TPS.InvoiceHub.Domain;

namespace KSN.TPS.InvoiceHub.ApplicationService.Dto
{
    public class InvoiceBatchPreparationResult
    {
        public InvoiceBatch Batch { get; set; }
        public List<InvoiceInbox> Inboxes { get; set; } = new();
        public List<InvoiceResponseDto> ResponseItems { get; set; } = new();
    }
}
