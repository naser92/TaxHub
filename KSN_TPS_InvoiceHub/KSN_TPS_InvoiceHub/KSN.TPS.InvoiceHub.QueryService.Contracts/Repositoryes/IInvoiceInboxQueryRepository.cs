using KSN.TPS.InvoiceHub.Query.DataContext.DataModels;
using PDN.TPS.Framework.Persistence.EF;

namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Repositories
{
    public interface IInvoiceInboxQueryRepository : IQueryRepository<InvoiceInboxModel, Guid>
    {


    }

}

