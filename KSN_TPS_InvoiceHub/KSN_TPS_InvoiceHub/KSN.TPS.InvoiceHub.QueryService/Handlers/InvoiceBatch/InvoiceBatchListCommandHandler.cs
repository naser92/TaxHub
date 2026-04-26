using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Models;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Services;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.QueryService
{
    public class InvoiceBatchListCommandHandler : CommandHandler, IQueryHandler<InvoiceBatchListCommand, object>
    {

        private readonly IInvoiceBatchQueryService _service;

        public InvoiceBatchListCommandHandler(IInvoiceBatchQueryService invoicebatchService, IUnitOfWork uow) : base(uow)
        {
            _service = invoicebatchService;
        }

        public Task<IResult<object>> Handle(InvoiceBatchListCommand command)
        {
            return _service.Get<InvoiceBatchDto>(command.Parameters);
        }

    }
}

