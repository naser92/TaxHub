using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Models;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Services;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.QueryService
{
    public class InvoiceInboxListCommandHandler : CommandHandler, IQueryHandler<InvoiceInboxListCommand, object>
    {

        private readonly IInvoiceInboxQueryService _service;

        public InvoiceInboxListCommandHandler(IInvoiceInboxQueryService invoiceinboxService, IUnitOfWork uow) : base(uow)
        {
            _service = invoiceinboxService;
        }

        public Task<IResult<object>> Handle(InvoiceInboxListCommand command)
        {
            return _service.Get<InvoiceInboxDto>(command.Parameters);
        }

    }
}

