using System;
using PDN.TPS.Framework.ViewModels;
using PDN.TPS.Framework.Core.Bus;

            
namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Commands
{
    public class InvoiceInboxDetailCommand :BaseDto<Guid>, ICommand
    {
            
        public InvoiceInboxDetailCommand(Guid id)
        {
            Id = id;
        }
          
    }
}
