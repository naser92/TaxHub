using PDN.TPS.Framework.Core.Results;
using PDN.TPS.Framework.Core.Service;
using PDN.TPS.Framework.ViewModels;

namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Services
{

    public interface IInvoiceInboxQueryService : IBaseService
    {
        #region base methods
        Task<IResult<T>> Get<T>(Guid id);
        Task<IResult<object>> Get<T>(GridParameters parameters);
        Task<IResult<IList<T>>> Get<T>();
        //Task<List<T>> Get<T>(IList<int> codes);
        #endregion
    }

}
