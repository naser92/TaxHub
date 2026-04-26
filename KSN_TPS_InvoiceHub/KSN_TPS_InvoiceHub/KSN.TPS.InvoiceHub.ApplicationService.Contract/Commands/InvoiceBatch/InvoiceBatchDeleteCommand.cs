using System;
using PDN.TPS.Framework.ViewModels;
using PDN.TPS.Framework.Core.Bus;

namespace KSN.TPS.InvoiceHub.ApplicationService.Commands
{
  public class InvoiceBatchDeleteCommand :BaseDto<Guid> , ICommand
  {

      public InvoiceBatchDeleteCommand(Guid id)
      {
          Id = id;
      }

  }
}

