using FluentValidation;
using KSN.TPS.InvoiceHub.Common;
using PDN.TPS.Framework.Extensions;
using PDN.TPS.Framework.TaxUniqueSerial.Extensions;
using PDN.TPS.Framework.Utility;

namespace PDN.TPS.InvoiceHub.Common.Validators
{
    public static class InvoiceValidatorExtensions
    {
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainOneOrMoreItem<T, TElement>(
            this IRuleBuilder<T, IList<TElement>> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new ListMustHasOneOrMoreItemValidator<T, TElement>());
        }

        public static bool IsCorrectValueFormat(this string value)
        {
            return value.Any(t => t != '0' && t != '-');
        }

        public static IRuleBuilderOptions<T, string> IsEmptyOrValidNationalCode<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(code => code.IsNullOrEmpty() || code.IsValidNationalId())
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }
        public static IRuleBuilderOptions<T, string> IsEmptyOrValidPostalcode<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(code => code.IsNullOrEmpty() || (code.IsNumber() && code.IsCorrectValueFormat() && code.Length == 10))
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }
        public static IRuleBuilderOptions<T, string> IsEmptyOrValidEconomicCode<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(code => code.IsNullOrEmpty() || (code.IsNumber() && code.IsCorrectValueFormat() && code.Length >= 11 && code.Length <= 14 && code.IsValidEconomicCode()))
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }

        public static IRuleBuilderOptions<T, string> IsValidEconomicCode<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(code => (code.IsNumber() && code.IsCorrectValueFormat() && code.Length >= 11 && code.Length <= 14 && code.IsValidEconomicCode()))
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }

        public static bool IsRealNationalCode(this string nationalCode)
        {
            return nationalCode != null && nationalCode.Length == 10;
        }

        public static bool IsLegalNationalCode(this string nationalCode)
        {
            return nationalCode != null && nationalCode.Length == 11 && (nationalCode.StartsWith("1") || nationalCode.StartsWith("3"));
        }

        public static bool IsParticipation(this string nationalCode)
        {
            return nationalCode != null && nationalCode.Length >= 10 && nationalCode.Length <= 12;
        }

        public static bool IsForeignNationalCode(this string nationalCode)
        {
            return nationalCode != null && nationalCode.Length == 12;
        }

        public static bool IsValidEconomicCode(this string economicCode)
        {
            return economicCode.IsRealEconomicCode() ||
                economicCode.IsLegalEconomicCode() ||
                economicCode.IsParticipationEconomicCode() ||
                economicCode.IsForeignEconomicCode();
        }

        public static bool IsRealEconomicCode(this string economicCode)
        {
            return economicCode is { Length: 14 } e && e.Substring(10, 1) == "0";
        }

        public static bool IsLegalEconomicCode(this string economicCode)
        {
            return economicCode is { Length: 11 } e && (e.StartsWith("1") || e.StartsWith("3"));
        }

        //public static bool IsFormationEconomicCode(this string economicCode)
        //{
        //    return economicCode is { Length: 11 }  e && e.StartsWith("3");
        //}

        public static bool IsParticipationEconomicCode(this string economicCode)
        {
            return (economicCode is { Length: 11 } e && e.StartsWith("6"));
        }

        public static bool IsForeignEconomicCode(this string economicCode)
        {
            return economicCode != null && economicCode.Length == 14;
        }

        public static IRuleBuilderOptions<T, string> IsValidFiscalid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                 .Must(value => value.IsNullOrEmpty() || value.IsMatch(AppConsts.FiscalidRegex))
                 .WithMessage(" (شش کارکتر و شامل حروف بزرگ انگلیسی و اعداد ۰ تا ۹ و با A یا B آغاز میشود)قالب ورودی {PropertyName} اشتباه است");

        }

        public static IRuleBuilderOptions<T, string> IsValidInternalSerial<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || value.IsMatch(AppConsts.SerialNumberRegex))
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }

        public static IRuleBuilderOptions<T, string> IsNullOrValidTaxid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || (value.IsMatch(AppConsts.TaxidRegex) && value.IsValidTaxUniqueSerial()))
                .WithMessage("{PropertyName} نا معتبر است");

        }

        public static IRuleBuilderOptions<T, string> IsNullOrValidCountryCode<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(code => code.IsNullOrEmpty() || code.Length <= 3)
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }

        public static IRuleBuilderOptions<T, int?> IsNullOrValidCityCode<T>(
            this IRuleBuilder<T, int?> ruleBuilder)
        {
            return ruleBuilder
                .Must(code => code.IsNull() || code <= 99999)
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }

        public static IRuleBuilderOptions<T, string> IsNullOrValidInsurancePolicyNumber<T>(
           this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(code => code == null || (code.Length >= 9 && code.Length <= 12))
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }

        public static IRuleBuilderOptions<T, string> IsNullOrValidInsuranceAttachmentNumber<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(code => code == null || (code.Length >= 9 && code.Length <= 12))
                .WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }


        public static bool IsValidBuyerEconomicType(this string economicCode, int type)
        {
            bool result = type switch
            {
                1 => economicCode.IsRealEconomicCode(),
                2 => economicCode.IsLegalEconomicCode(),
                3 => economicCode.IsParticipationEconomicCode(),
                4 => economicCode.IsForeignEconomicCode(),
                _ => false,
            };

            return result;
        }

        public static bool IsValidBuyerNationalCodeType(this string nationalCode, int type)
        {
            bool result = type switch
            {
                1 => nationalCode.IsRealNationalCode(),
                2 => nationalCode.IsLegalNationalCode(),
                3 => nationalCode.IsParticipation(),
                4 => nationalCode.IsForeignNationalCode(),
                _ => false,
            };

            return result;
        }


        public static bool IsValidTaxSerialNumber(this string taxSerialNumber)
        {
            if (string.IsNullOrWhiteSpace(taxSerialNumber) ||
                taxSerialNumber.Length != 22 ||
                !taxSerialNumber.IsMatch(AppConsts.TaxidRegex) ||
                !taxSerialNumber.IsValidTaxUniqueSerial())
            {
                throw new ArgumentException("شماره مالیاتی نامعتبر است.");
            }

            return true;
        }
        public static bool IsInValidInvoiceDate(this DateTime invoiceDate, TimeSpan invoiceTime, EStatusSub? statusSubId, Guid? sellerUserId, int invoiceValidDifferentialDay)
        {
            var exeptUserId = Guid.Parse("9A180A44-B54E-4DFB-A293-C9CD0DB57C06");
            var today = DateTime.Today;
            var endDate1 = DateTime.Parse("4/14/2026");//"1405/01/25".ToMiladiDate();
            var StartValiddate1 = DateTime.Parse("2/20/2026");//"1404/12/01".ToMiladiDate();

            var endDate2 = DateTime.Parse("5/21/2026");//"1405/02/31".ToMiladiDate();
            var StartValiddate2 = DateTime.Parse("3/21/2026");//"1405/01/01".ToMiladiDate();


            var dateDiff = (int)(today - invoiceDate).TotalDays;

            if (dateDiff > invoiceValidDifferentialDay && ((today < endDate1 && invoiceDate >= StartValiddate1) || (today < endDate2 && invoiceDate >= StartValiddate2)))
                return false;

            return
                (sellerUserId.IsNull() || sellerUserId != exeptUserId) && (statusSubId.IsNull() || statusSubId != EStatusSub.Discrepancy)
                && invoiceValidDifferentialDay.IsPositive()
                && (dateDiff > invoiceValidDifferentialDay || (dateDiff == invoiceValidDifferentialDay && invoiceTime.TotalHours > 20));
        }

        public static IRuleBuilderOptions<T, string> IsEmptyOrValidVatPaymentId<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
              .Must(code => code == null || code.Length <= 13).WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }

        public static IRuleBuilderOptions<T, string> IsEmptyOrValidVatBillId<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
              .Must(code => code == null || code.Length <= 13).WithMessage("'{PropertyName}' وارد شده نامعتبر است");
        }
    }
}