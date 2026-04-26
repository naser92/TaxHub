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
    public class InvoiceInboxSelectListCommandHandler : CommandHandler,IQueryHandler<InvoiceInboxSelectListCommand, IList<InvoiceInboxSimpleDto>>
    {
        private readonly IInvoiceInboxQueryService _service;
           
        public InvoiceInboxSelectListCommandHandler(IInvoiceInboxQueryService invoiceinboxService, IUnitOfWork uow) : base(uow)
        {
            _service = invoiceinboxService;
        }
           
        public Task<IResult<IList<InvoiceInboxSimpleDto>>> Handle(InvoiceInboxSelectListCommand command)
        {
            return _service.Get<InvoiceInboxSimpleDto>();
        }
           
    }
}
