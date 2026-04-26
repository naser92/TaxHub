using FluentValidation;
using PDN.TPS.Framework.Extensions;
using PDN.TPS.Framework.TaxUniqueSerial.Extensions;

namespace PDN.TPS.InvoiceHub.Common.Validators
{
    public static class CustomeRuleValidator
    {
        public static IRuleBuilderOptions<T, string> IsCorrectValueFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrWhiteSpace() || value.IsCorrectValueFormat())
                .WithMessage("ساختار {PropertyName} صحیح نیست.");
        }


        public static IRuleBuilderOptions<T, string> HasDangerChar<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrWhiteSpace() || !value.HasDangerChar())
                .WithMessage("{PropertyName} دارای کاراکتر غیر مجاز است");
        }
        public static IRuleBuilderOptions<T, string> HasDangerCharForInvoice<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrWhiteSpace() || !value.HasDangerCharForInvoice())
                .WithMessage("{PropertyName} دارای کاراکتر غیر مجاز است");
        }
        public static IRuleBuilderOptions<T, string> HasDangerCharForNames<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrWhiteSpace() || !value.HasDangerCharForNames())
                .WithMessage("{PropertyName} دارای کاراکتر غیر مجاز است");
        }
        public static IRuleBuilderOptions<T, string> IsNumeric<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrWhiteSpace() || value.IsDigit())
                .WithMessage("{PropertyName} باید بصورت عددی وارد شود");
        }

        public static IRuleBuilderOptions<T, string> IsNullOrValidBillid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrWhiteSpace() || (value.Length >= 2 && value.Length <= 19))
                .WithMessage("طول {PropertyName} باید بزرگتر یا مساوی  2 و کوچکتر یا مساوی ۱۹ باشد");
        }
        public static IRuleBuilderOptions<T, string> IsNotNumeric<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((string value) => value.IsNullOrWhiteSpace() || !value.IsDigit()).WithMessage("{PropertyName} باید بصورت حروف وارد شود");
        }

        public static IRuleBuilderOptions<T, string> IsValidInvoiceNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .IsCorrectValueFormat()
                .HasDangerCharForInvoice();
        }

        public static IRuleBuilderOptions<T, string> IsValidJalaliDate<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || value.IsTruePersianDate())
                .WithMessage("ساختار {PropertyName} درست نمی‌باشد");
        }
        public static IRuleBuilderOptions<T, string> IsJalaliDateBigerThanToday<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || (value.IsTruePersianDate() && DateTime.Now.CompareTo(value.ToMiladiDate()) > 0))
                .WithMessage("{PropertyName} نباید بزرگتر از تاریخ جاری باشد");
        }
        public static IRuleBuilderOptions<T, DateTime> IsDateBigerThanToday<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => (value - DateTime.Now).TotalMilliseconds < 0)
                .WithMessage("{PropertyName} نباید بزرگتر از تاریخ جاری باشد");
        }
        public static IRuleBuilderOptions<T, DateTime?> IsDateBigerThanToday<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => !value.IsNullOrEmpty() && DateTime.Now.CompareTo(value.Value) >= 0)
                .WithMessage("{PropertyName} نباید بزرگتر از تاریخ جاری باشد");
        }
        public static IRuleBuilderOptions<T, DateTime> IsDateNullOrBigerThanToday<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsEmpty() || DateTime.Now.CompareTo(value) >= 0)
                .WithMessage("{PropertyName} نباید بزرگتر از تاریخ جاری باشد");
        }
        public static IRuleBuilderOptions<T, DateTime?> IsDateNullOrBigerThanToday<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || DateTime.Now.CompareTo(value.Value) >= 0)
                .WithMessage("{PropertyName} نباید بزرگتر از تاریخ جاری باشد");
        }
        public static IRuleBuilderOptions<T, string> IsValidInvoiceDate<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .IsValidJalaliDate();

        }
        public static IRuleBuilderOptions<T, string> IsValidInvoiceDateNotBigerthanNow<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .IsValidJalaliDate()
                .IsJalaliDateBigerThanToday();

        }
        public static IRuleBuilderOptions<T, string> IsEmptyOrValidPassportNumber<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || value.IsMatch(@"^[A-Za-z][0-9]{8}$"))
                .WithMessage("{PropertyName} '{PropertyValue}'  نامعتبر می‌باشد");
        }
        public static IRuleBuilderOptions<T, string> IsValidTaxSerialNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNotNullOrEmpty() && value.Length == 22 && value.IsValidTaxUniqueSerial())
                .WithMessage("{PropertyName} نا معتبر می‌باشد");

        }
        public static IRuleBuilderOptions<T, string> IsNullOrValidTaxSerialNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || (value.Length == 22 && value.IsValidTaxUniqueSerial()))
                .WithMessage("{PropertyName} نا معتبر می‌باشد");

        }
        public static IRuleBuilderOptions<T, string> IsNullOrValidSellerContractRegistrationNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrWhiteSpace() || (value.Length == 12 && value.IsMatch("^(1|2)")))
                .WithMessage("{PropertyName} نا معتبر است");

        }
        public static IRuleBuilderOptions<T, string> IsNullOrValidCommodityServiceTitle<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || !value.IsMatch("[\\\"]"))
                .WithMessage("{PropertyName} دارای کاراکتر غیر مجاز(\\یا \") است");

        }

        public static IRuleBuilderOptions<T, string> IsValidCommodityServiceTitle<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => !value.IsMatch("[\\\"]"))
                .WithMessage("{PropertyName} دارای کاراکتر غیر مجاز(\\یا \") است");

        }

        public static IRuleBuilderOptions<T, string> IsNullOrValidStuffid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || (value.Length == 13 && value.StartsWith('2')))
                .WithMessage("{PropertyName} نا معتبر می‌باشد");

        }

        public static IRuleBuilderOptions<T, string> IsValidStuffid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNotNullOrEmpty() && value.Length == 13 && value.StartsWith('2'))
                .WithMessage("{PropertyName} نا معتبر می‌باشد");

        }

        public static IRuleBuilderOptions<T, string> IsNullOrValidSalesAnnouncementNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => value.IsNullOrEmpty() || (value.Length >= 9 && value.Length <= 30))//&& value.StartsWith('1')
                .WithMessage("{PropertyName} نا معتبر می‌باشد");

        }

        //// TODO: Replace with framework
        //public static IRuleBuilderOptions<T, decimal> DecimalPointMaxLength<T>(this IRuleBuilder<T, decimal> ruleBuilder, int length)
        //{
        //    return ruleBuilder
        //        .Must((rootObject, value, context) => {
        //            context.MessageFormatter.AppendArgument("MaxDecimalPointLength", (length == 0 ? "صفر" : length.ToString()));
        //            return value.DecimalPointMaxLength(length);
        //        })
        //        .WithMessage("{PropertyName} نمی تواند شامل بیشتر از {MaxDecimalPointLength} .رقم اعشار باشد");
        //}
        //public static IRuleBuilderOptions<T, decimal?> DecimalPointMaxLength<T>(this IRuleBuilder<T, decimal?> ruleBuilder, int length)
        //{
        //    return ruleBuilder
        //        .Must((rootObject, value, context) => {
        //            context.MessageFormatter.AppendArgument("MaxDecimalPointLength", (length == 0 ? "صفر" : length.ToString()));
        //            return value.DecimalPointMaxLength(length);
        //        })
        //        .WithMessage("{PropertyName} نمی تواند شامل بیشتر از {MaxDecimalPointLength} .رقم اعشار باشد");
        //}

    }
}
