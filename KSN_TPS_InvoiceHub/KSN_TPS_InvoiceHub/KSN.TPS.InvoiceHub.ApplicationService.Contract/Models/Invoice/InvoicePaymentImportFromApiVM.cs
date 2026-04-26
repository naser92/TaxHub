using Newtonsoft.Json;

namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice
{
    public class InvoicePaymentImportFromApiVM
    {
        public int? RowIndex { get; set; }
        [JsonProperty("paymentMethod")]
        public int? BasePaymentCreditTypeId { get; set; }
        public decimal PaymentAmount { get; set; }

        public DateTime? PaymentDate { get; set; }


        public string SwitchNumber { get; set; }
        public string AcceptanceNumber { get; set; }
        public string TerminalNumber { get; set; }
        public string TraceNumber { get; set; }
        public string PayerCardNumber { get; set; }
        public string PayerNationalCode { get; set; }
        public string Description { get; set; }

        //public string VatPaymentId { get; set; }
        //public string VatBillId { get; set; }
    }
}
