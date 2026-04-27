using KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice;
using KSN.TPS.InvoiceHub.ApplicationService.Dto;
using PDN.TPS.Framework.Core.Service;

namespace KSN.TPS.InvoiceHub.ApplicationService.Services
{
    public interface IInvoicePreparationService : IBaseService
    {
        Task<InvoiceBatchPreparationResult> PrepareAsync(List<InvoiceImportFromApiVM> invoices, Guid sellerUserContainerId);
    }
}
