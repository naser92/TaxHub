using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Models;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Services;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.QueryService
{
    public class InvoiceBatchLookupCommandHandler : CommandHandler, IQueryHandler<InvoiceBatchLookupCommand, object>
    {
        private readonly IInvoiceBatchQueryService _service;

        public InvoiceBatchLookupCommandHandler(IInvoiceBatchQueryService invoicebatchQueryService, IUnitOfWork uow) : base(uow)
        {
            _service = invoicebatchQueryService;
        }

        public Task<IResult<object>> Handle(InvoiceBatchLookupCommand command)
        {
            return _service.Get<InvoiceBatchLookupDto>(command.Parameters);
        }

    }
}
