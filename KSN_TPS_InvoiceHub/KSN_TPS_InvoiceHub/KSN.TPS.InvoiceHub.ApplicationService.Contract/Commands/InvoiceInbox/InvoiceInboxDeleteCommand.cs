using System;
using PDN.TPS.Framework.ViewModels;
using PDN.TPS.Framework.Core.Bus;

namespace KSN.TPS.InvoiceHub.ApplicationService.Commands
{
  public class InvoiceInboxDeleteCommand :BaseDto<Guid> , ICommand
  {

      public InvoiceInboxDeleteCommand(Guid id)
      {
          Id = id;
      }

  }
}

