using KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice;
using PDN.TPS.Framework.Core.Bus;

namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Commands
{
    public class InvoiceImportFromApiCommand : ICommand
    {
        public List<InvoiceImportFromApiVM> Invoices { get; set; }
    }
}
