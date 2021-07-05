using Models.Model;
using System.Collections.Generic;

namespace FonNature
{
    public struct Constant
    {
        public const string HostUrl = "http://localhost:56080/";
        public static readonly string Cart_Sesion = "Cart_Session";
        public static readonly string SignatureSession = "Signature_Session";
        public static readonly List<string> whiteListWebsite = new List<string>()
        {
            "viblo.asia",
            "tutorialsteacher.com"
        };
        public static readonly List<string> HtmlTagWhiteList = new List<string>()
        {
              "p", "h1", "br" , "a"
        };

        public static readonly Dictionary<string, string> MenuLinks = new Dictionary<string, string>()
        {
            { "/" , "Home" },
            { "/service" , "Service" },
            { "/product" , "Product" },
            { "/blog" , "Blog" },
            { "/aboutus" , "About Us" },
            { "/contact" , "Contact" },
        };

        public struct Membership
        {
            public static readonly string IsLoginSession = "IsLoginSession";
            public static readonly string AccountSession = "AccountSession";
        }

        public static readonly Dictionary<int, PeriodTime> TimeRanges = new Dictionary<int, PeriodTime>()
        {
           { 1, new PeriodTime(9,00) },
           { 2, new PeriodTime(10,00) },
           { 3, new PeriodTime(11,00) },
           { 4, new PeriodTime(13,00) },
           { 5, new PeriodTime(14,00) },
           { 6, new PeriodTime(15,00) },
           { 7, new PeriodTime(16,00) },
           { 8, new PeriodTime(17,00) },
           { 9, new PeriodTime(18,00) },
        };

        public static readonly Dictionary<int, string> OrderStatus = new Dictionary<int, string>()
        {
           { 1, "Order Success" },
           { 2, "Payment Success" },
           { 3, "Shipping" },
           { 4, "Paid and Received" },
           { 5, "Canceled" },
        };

        public struct Order
        {
            public const string CODPaymentMethods = "COD";
            public const string BankTransferPaymentMethods = "BankTransfer";
            public const string MoMoPaymentMethods = "MoMo";
            public const string PaypalPaymentMethod = "Paypal";
        }

        public struct Payment
        {
            public struct MoMo
            {
                public const string PartnerCode = "MOMO9CJI20201128";
                public const string AccessCode = "5UBseVYEIavDbdrq";
                public const string RequestType = "captureMoMoWallet";
                public const string SecrectKey = "YUYbDoR1BXDyswG5sKgVgbmSJ6Bk1KEH";
            } 
        }
    }
}