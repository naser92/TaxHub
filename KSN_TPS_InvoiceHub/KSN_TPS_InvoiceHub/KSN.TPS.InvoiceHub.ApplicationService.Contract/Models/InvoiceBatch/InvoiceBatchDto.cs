using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using PDN.TPS.Framework.ViewModels;

namespace KSN.TPS.InvoiceHub.ApplicationService.Dto
{

 
    public class InvoiceBatchDto : BaseDto<Guid>
    {

        public int InsertBaseType { get; set; }

        public Guid UserContainerId { get; set; }

        public Guid CreatedUserId { get; set; }

        public string FileName { get; set; }

        public int TotalInvoiceCount { get; set; }

    }
}
