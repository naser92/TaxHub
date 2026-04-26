using System;
using PDN.TPS.Framework.ViewModels;
using PDN.TPS.Framework.Core.Bus;

            
namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Commands
{
    public class InvoiceBatchDetailCommand :BaseDto<Guid>, ICommand
    {
            
        public InvoiceBatchDetailCommand(Guid id)
        {
            Id = id;
        }
          
    }
}
