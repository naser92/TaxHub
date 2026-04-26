using KSN.TPS.InvoiceHub.Common;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace PDN.TPS.InvoiceHub.Common
{
    public static class StringExtension
    {
        public static string GetLast(this string source, int tailLength)
        {
            return tailLength < source.Length ? source.Substring(source.Length - tailLength) : source;
        }



        public static bool HasDangerChar(this string value)
        {
            //return value.Any(c => AppConsts.DangerChar.Contains(c));
            return Regex.IsMatch(value, AppConsts.DangerCharRegex);

        }

        public static bool HasDangerCharForInvoice(this string value)
        {
            //return value.Any(c => AppConsts.DangerChar.Contains(c));
            return Regex.IsMatch(value, AppConsts.DangerCharForInvoiceRegex);

        }

        public static bool HasDangerCharForNames(this string value)
        {
            return Regex.IsMatch(value, AppConsts.DangerCharForNamesRegex);
        }

        public static bool IsAllowedChars(this string value)
        {
            return value.All(c => AppConsts.AllowedChar.Contains(c));
        }
        public static string RemoveInvalidChar(this string value)
        {
            return Regex.Replace(value, @"(\r\n?|\n)", " ");
        }
        public static int TryParseInt(this string value)
        {
            int result;
            return int.TryParse(value, out result) ? result : 0;
        }
        public static T DeserializeObject<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}