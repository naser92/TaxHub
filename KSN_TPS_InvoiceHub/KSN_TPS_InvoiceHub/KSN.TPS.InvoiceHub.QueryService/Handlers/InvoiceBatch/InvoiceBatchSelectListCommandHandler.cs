using System;
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.Core.Results;
using PDN.TPS.Framework.Core.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Commands;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Models;
using KSN.TPS.InvoiceHub.QueryService.Contracts.Services;
           
namespace KSN.TPS.InvoiceHub.QueryService
{
    public class InvoiceBatchSelectListCommandHandler : CommandHandler,IQueryHandler<InvoiceBatchSelectListCommand, IList<InvoiceBatchSimpleDto>>
    {
        private readonly IInvoiceBatchQueryService _service;
           
        public InvoiceBatchSelectListCommandHandler(IInvoiceBatchQueryService invoicebatchService, IUnitOfWork uow) : base(uow)
        {
            _service = invoicebatchService;
        }
           
        public Task<IResult<IList<InvoiceBatchSimpleDto>>> Handle(InvoiceBatchSelectListCommand command)
        {
            return _service.Get<InvoiceBatchSimpleDto>();
        }
           
    }
}
