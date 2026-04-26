using PDN.TPS.Framework.Persistence.EF;

namespace KSN.TPS.InvoiceHub.Domain
{
    public interface IInvoiceBatchWriteRepository : IWriteRepository<InvoiceBatch, Guid>
    {

    }
}
