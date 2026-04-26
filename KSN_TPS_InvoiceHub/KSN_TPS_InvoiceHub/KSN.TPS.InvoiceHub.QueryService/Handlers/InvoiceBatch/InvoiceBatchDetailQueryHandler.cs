using System.Threading.Tasks;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Results;
using PDN.TPS.Framework.Core.Persistence;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Models;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Services;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;

            
namespace KSN.TPS.InvoiceHub.QueryService
{
    public class InvoiceBatchDetailQueryHandler : CommandHandler, IQueryHandler<InvoiceBatchDetailCommand,InvoiceBatchDto>
    {

        private readonly IInvoiceBatchQueryService _Service;
            
        public InvoiceBatchDetailQueryHandler(IInvoiceBatchQueryService invoicebatchService, IUnitOfWork uow) : base(uow) 
        {
            _Service = invoicebatchService;
        }
            
        public Task<IResult<InvoiceBatchDto>> Handle(InvoiceBatchDetailCommand command)
        {
            return _Service.Get<InvoiceBatchDto> (command.Id);
        }

    }
}

