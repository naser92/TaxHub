using System.Threading.Tasks;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Results;
using PDN.TPS.Framework.Core.Persistence;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Models;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Services;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;

            
namespace KSN.TPS.InvoiceHub.QueryService
{
    public class InvoiceInboxDetailQueryHandler : CommandHandler, IQueryHandler<InvoiceInboxDetailCommand,InvoiceInboxDto>
    {

        private readonly IInvoiceInboxQueryService _Service;
            
        public InvoiceInboxDetailQueryHandler(IInvoiceInboxQueryService invoiceinboxService, IUnitOfWork uow) : base(uow) 
        {
            _Service = invoiceinboxService;
        }
            
        public Task<IResult<InvoiceInboxDto>> Handle(InvoiceInboxDetailCommand command)
        {
            return _Service.Get<InvoiceInboxDto> (command.Id);
        }

    }
}

