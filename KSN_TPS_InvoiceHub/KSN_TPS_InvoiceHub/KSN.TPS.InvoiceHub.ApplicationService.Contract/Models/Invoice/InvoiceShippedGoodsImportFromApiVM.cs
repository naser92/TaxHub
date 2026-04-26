namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice
{
    public class InvoiceShippedGoodsImportFromApiVM
    {
        public string StuffTitle { get; set; }
        public string Stuffid { get; set; }
        public int? RowIndex { get; set; }
        public string Description { get; set; }
    }
}
