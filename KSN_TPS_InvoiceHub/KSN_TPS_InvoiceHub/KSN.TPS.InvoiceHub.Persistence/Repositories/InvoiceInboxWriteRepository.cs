using KSN.TPS.InvoiceHub.Domain;
using PDN.TPS.Framework.Core.Caching;

namespace KSN.TPS.InvoiceHub.Persistence.Repository
{
    public class InvoiceInboxWriteRepository : WriteRepository<InvoiceInbox, Guid>, IInvoiceInboxWriteRepository
    {
        public InvoiceInboxWriteRepository(IStaticCacheManager staticCacheManager, WriteDbContext context) : base(staticCacheManager, context)
        {
        }


    }
}
