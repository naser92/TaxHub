using KSN.TPS.InvoiceHub.QueryService.Contracts.Repositories;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using PDN.TPS.Framework.Core.Mapper;
using PDN.TPS.Framework.Core.Results;
using PDN.TPS.Framework.ViewModels;

namespace KSN.TPS.InvoiceHub.QueryServices
{
    public class InvoiceInboxQueryService : IInvoiceInboxQueryService
    {

        #region variables

        private readonly IInvoiceInboxQueryRepository _repository;

        #endregion

        #region constructors

        public InvoiceInboxQueryService(IInvoiceInboxQueryRepository invoiceinboxRepository)
        {
            _repository = invoiceinboxRepository;
        }

        #endregion

        #region base methods

        public async Task<IResult<TResult>> Get<TResult>(Guid id)
        {

            return await _repository.Get<TResult>(x => x.Id.Equals(id)).ResultAsync();

        }

        public async Task<IResult<object>> Get<T>(GridParameters parameters)//SortedGridParameters parameters
        {

            var query = _repository.Table;
            var result = await query.ProjectTo<T>().GridAsync(parameters)
                .ResultAsync();

            return result;
        }

        public async Task<IResult<IList<T>>> Get<T>()
        {

            var query = _repository.Table;//.OrderBy(x => x.Priority);

            var result = await query.ProjectTo<T>().ToListAsync()
                .ResultAsync();

            return result;
        }

        //public async Task<List<T>> Get<T>(IList<int> codes)
        //{

        //    return await _repository.Table.Where(x => codes.Any(y => y == x.Code))
        //    .ProjectTo<T>().ToListAsync();
        //}

        #endregion

    }

}

