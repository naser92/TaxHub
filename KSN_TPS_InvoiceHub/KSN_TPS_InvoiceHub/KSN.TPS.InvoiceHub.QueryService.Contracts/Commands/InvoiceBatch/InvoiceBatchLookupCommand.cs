using System.ComponentModel.DataAnnotations; 
using PDN.TPS.Framework.ViewModels;
using PDN.TPS.Framework.Core.Bus;


namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Commands
{
    public class InvoiceBatchLookupCommand : ICommand
    {

        public InvoiceBatchLookupCommand(GridParameters gridParameters) => this.Parameters = gridParameters;
    
        /// <summary>
        ///  تنظیمات لیست
        /// </summary>
        [Display(Name="تنظیمات لیست")]
        public GridParameters Parameters { get; set; }

    }
}
