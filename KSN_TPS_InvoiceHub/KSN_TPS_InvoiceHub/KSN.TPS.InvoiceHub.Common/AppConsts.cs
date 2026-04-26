namespace KSN.TPS.InvoiceHub.Common
{
    public static class AppConsts
    {
        public const string SystemBaseInformationName = "SystemBaseInformationGroup";
        public const string SystemBaseInformationTitle = "اطلاعات پایه سیستمی";

        public const string DangerCharRegex = @"\*\*|--|""|\\";
        public const string DangerCharForInvoiceRegex = @"\*\*|--|[@~!#$%\^&()+=|\\?""':,`]";
        public const string DangerCharForNamesRegex = @"[@~!#$%\^&*+=|\\?""':`]";
        public const string AllowedChar = "0123456789zxcvbnmasdfghjklqwertyuiop";
        public const string FiscalidRegex = "^(A|B)[AD-HKM-PRT-Z1-9]{5}";
        public const string HexRegex = "[A-Fa-f0-9]";
        public const string SerialNumberRegex = "^" + HexRegex + "{1,10}$";
    }
}
