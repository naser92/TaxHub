using System.ComponentModel.DataAnnotations; 
using PDN.TPS.Framework.Core.Bus;
using PDN.TPS.Framework.ViewModels;
            
namespace KSN.TPS.InvoiceHub.QueryService.Contracts.Commands
{
    public class InvoiceBatchListCommand : ICommand
    {      
        public InvoiceBatchListCommand(GridParameters gridParameters) => this.Parameters = gridParameters;  

        /// <summary>
        ///  تنظیمات لیست
        /// </summary>
        [Display(Name="تنظیمات لیست")]
        public GridParameters Parameters { get; set; }

    }
}
