using Newtonsoft.Json;

namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice
{
    public class InvoiceItemImportFromApiVM
    {
        public int? RowIndex { get; set; }
        // [JsonProperty("commodityType")]
        //public int BaseCommodityServiceTypeCode { get; set; }

        public string CommodityCode { get; set; }
        public string ExtendStuffTitle { get; set; }

        //[JsonProperty("computeCostType")]
        //  public int? BaseComputeCostTypeCode { get; set; }

        public decimal Amount { get; set; }

        [JsonProperty("unitType")]
        public int? BaseUnitTypeCode { get; set; }

        //[JsonProperty("equivalentUnitType")]
        //public int? EquivalentBaseUnitTypeCode { get; set; }

        //public decimal EquivalentAmount { get; set; }

        [JsonProperty("moneyType")]
        public int BaseMoneyTypeCode { get; set; }
        public decimal EquivalentToRial { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal DutyPercent { get; set; }
        public decimal DutyPrice { get; set; }
        public string DutyTitle { get; set; }
        public string ExchangeContractNumber { get; set; }
        public DateTime? ExchangeContractDate { get; set; }
        public decimal CurrencyAmount { get; set; }
        public string OtherLegalFundsTitle { get; set; }
        public decimal OtherLegalFundsPercent { get; set; }
        public decimal OtherLegalFundsPrice { get; set; }
        public decimal ConstructionWages { get; set; }
        public decimal SaleProfit { get; set; }
        public decimal BrokerCommission { get; set; }
        public string BrokerContractNumber { get; set; }
        public decimal NetWeight { get; set; }
        public decimal StuffIRRValue { get; set; }
        public decimal StuffCurrencyValue { get; set; }
        public decimal PurchaseSalePriceDifference { get; set; }
        public decimal? Cutie { get; set; }
        public decimal? CurrencyPurchaseRate { get; set; }
        public decimal? SourceOfVat { get; set; }
        public decimal? TotalPriceWithDiscount { get; set; }
        public string Stuffid { get; set; }
        public string StuffTitle { get; set; }
        //public string BaseMoneyTypeISOCode { get; set; }
        public string MoneyISOCode { get; set; }

        // public string HSCode { get; set; }
        public decimal? VatBaseAmount { get; set; }
    }
}
