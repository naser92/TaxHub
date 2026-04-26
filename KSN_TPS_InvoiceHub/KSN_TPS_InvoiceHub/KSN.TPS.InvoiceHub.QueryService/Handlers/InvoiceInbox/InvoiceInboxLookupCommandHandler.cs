using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Models;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Services;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Results;

namespace KSN.TPS.InvoiceHub.QueryService
{
    public class InvoiceInboxLookupCommandHandler : CommandHandler, IQueryHandler<InvoiceInboxLookupCommand, object>
    {
        private readonly IInvoiceInboxQueryService _service;

        public InvoiceInboxLookupCommandHandler(IInvoiceInboxQueryService invoiceinboxQueryService, IUnitOfWork uow) : base(uow)
        {
            _service = invoiceinboxQueryService;
        }

        public Task<IResult<object>> Handle(InvoiceInboxLookupCommand command)
        {
            return _service.Get<InvoiceInboxLookupDto>(command.Parameters);
        }

    }
}
