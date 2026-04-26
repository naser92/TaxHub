using Newtonsoft.Json;

namespace KSN.TPS.InvoiceHub.ApplicationService.Contract.Models.Invoice
{
    public class InvoiceImportFromApiVM
    {
        public string TaxSerialNumber { get; set; }
        public int? RowIndex { get; set; }
        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public TimeSpan? InvoiceTime { get; set; }

        [JsonProperty("saleType")]
        public int? BaseSaleTypeId { get; set; }

        public string ReferenceTaxSerialNumber { get; set; }

        [JsonProperty("invoicePattern")]
        public int BaseInvoicePatternCode { get; set; }
        //[JsonIgnore]
        //public EInvoicePattern BaseInvoicePatternId { get; set; }

        [JsonProperty("invoiceType")]
        public int BaseInvoiceTypeId { get; set; }

        [JsonProperty("invoiceSubject")]
        public int BaseInvoiceSubjectId { get; set; }

        [JsonProperty("paymentType")]
        public int BasePaymentTypeId { get; set; }

        [JsonProperty("uniqueId")]
        public Guid ApiUniqueId { get; set; }
        public string SellerBranch { get; set; }

        [JsonProperty("buyerType")]
        public int? BaseBuyerTypeId { get; set; }

        private string _buyerCompanyName;
        public string BuyerCompanyName
        {
            get => _buyerCompanyName;
            set => _buyerCompanyName = value.Replace('"', ' ');
        }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public string BuyerNationalCode { get; set; }
        public string BuyerEconomicCode { get; set; }
        public string BuyerPassportNumber { get; set; }
        public string BuyerPostalCode { get; set; }
        public string BuyerBranch { get; set; }

        [JsonProperty("buyerPhoneNumber")]
        public string BuyerPhoneOrMobileNumber { get; set; }

        public string SellerCustomsDeclarationNumber { get; set; }
        public string SellerCustomsLicenseNumber { get; set; }
        public string SellerContractRegistrationNumber { get; set; }
        public string AgencyEconomicCode { get; set; }

        [JsonProperty("flightType")]
        public int? BaseFlightTypeId { get; set; }
        public decimal CreditPaymentAmount { get; set; }
        public string PassengerNationalCode { get; set; }
        public string PassengerPassportNumber { get; set; }
        public string BillId { get; set; }
        public decimal? Tax17 { get; set; }
        public string CustomsDeclarationCottageNumber { get; set; }
        public DateTime? CustomsDeclarationCottageDate { get; set; }
        public string CooperationCode { get; set; }

        public string Description { get; set; }

        public bool IsUpdate { get; set; }
        public string SalesAnnouncementNumber { get; set; }
        public DateTime? SalesAnnouncementDate { get; set; }
        [JsonIgnore]
        public string SellerEconomicCode { get; set; }
        public string SellerFiscalid { get; set; }
        public DateTime? InvoiceSecondDate { get; set; }

        private string _buyerBusinessName;
        public string BuyerBusinessName
        {
            get => _buyerBusinessName;
            set => _buyerBusinessName = value.Replace('"', ' ');
        }

        public decimal? CashPaymentAmount { get; set; }
        public string LadingNumber { get; set; }
        public decimal? TotalNetWeight { get; set; }
        [JsonProperty("ladingType")]
        public int? BaseLadingTypeId { get; set; }
        public string CarrierNumber { get; set; }
        public string TransmitterNationalCode { get; set; }
        public string ReceiverNationalCode { get; set; }
        public string DriverNationalCode { get; set; }
        public string OriginCountryCode { get; set; }
        public int? OriginCityCode { get; set; }
        public string DestinationCountryCode { get; set; }
        public int? DestinationCityCode { get; set; }
        public string ReferenceLadingNumber { get; set; }


        public string InsurancePolicyNumber { get; set; }
        public string InsuranceAttachmentNumber { get; set; }


        public List<InvoiceItemImportFromApiVM> InvoiceItems { get; set; }
        public List<InvoiceShippedGoodsImportFromApiVM> InvoiceShippedGoods { get; set; }
        public List<InvoicePaymentImportFromApiVM> InvoicePayments { get; set; }
    }
}
