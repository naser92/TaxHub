using System;
using Microsoft.EntityFrameworkCore;
using PDN.TPS.Framework.Data;
using PDN.TPS.Framework.Core.Caching;
using KSN.TPS.InvoiceHub.Domain;

namespace KSN.TPS.InvoiceHub.Persistence.Repository
{
    public class InvoiceInboxWriteRepository : WriteRepository<InvoiceInbox,Guid>, IInvoiceInboxWriteRepository
    {
        public InvoiceInboxWriteRepository(IStaticCacheManager staticCacheManager,WriteDbContext context) : base(staticCacheManager,context)
        {
        }

            
    }
}
