using KSN.TPS.InvoiceHub.Query.DataContext;
using KSN.TPS.InvoiceHub.Query.DataContext.DataModels;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Repositories;
using PDN.TPS.Framework.Core.Caching;

namespace KSN.TPS.InvoiceHub.QueryService.Repositories
{
    public class InvoiceInboxQueryRepository : QueryRepository<InvoiceInboxModel, Guid>, IInvoiceInboxQueryRepository
    {

        public InvoiceInboxQueryRepository(IStaticCacheManager staticCachManager, QueryDbContext context) : base(staticCachManager, context)
        {
        }

    }

}

