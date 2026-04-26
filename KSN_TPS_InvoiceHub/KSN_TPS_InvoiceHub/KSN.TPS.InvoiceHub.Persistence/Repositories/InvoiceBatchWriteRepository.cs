using KSN.TPS.InvoiceHub.Domain;
using PDN.TPS.Framework.Core.Caching;

namespace KSN.TPS.InvoiceHub.Persistence.Repository
{
    public class InvoiceBatchWriteRepository : WriteRepository<InvoiceBatch, Guid>, IInvoiceBatchWriteRepository
    {
        public InvoiceBatchWriteRepository(IStaticCacheManager staticCacheManager, WriteDbContext context) : base(staticCacheManager, context)
        {
        }


    }
}
