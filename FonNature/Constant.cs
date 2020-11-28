

using Models.Entity;
using Models.Model;
using System.Collections.Generic;

namespace FonNature
{
    public struct Constant
    {
        public static readonly string Cart_Sesion = "Cart_Session";
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

        public static readonly Dictionary<int, TimeRange> TimeRanges = new Dictionary<int, TimeRange>()
        {
           { 1, new TimeRange(9,00) },
           { 2, new TimeRange(9,30) },
           { 3, new TimeRange(10,00) },
           { 4, new TimeRange(10,30) },
           { 5, new TimeRange(11,00) },
           { 6, new TimeRange(11,30) },
           { 7, new TimeRange(12,00) },
           { 8, new TimeRange(12,30) },
           { 9, new TimeRange(13,00) },
           { 10, new TimeRange(13,30) },
           { 11, new TimeRange(14,00) },
           { 12, new TimeRange(14,30) },
           { 13, new TimeRange(15,00) },
           { 14, new TimeRange(15,30) },
           { 15, new TimeRange(16,00) },
           { 16, new TimeRange(16,30) },
           { 17, new TimeRange(17,00) },
           { 18, new TimeRange(17,30) },
           { 19, new TimeRange(18,00) },
           { 20, new TimeRange(18,30) },
           { 21, new TimeRange(19,00) }
        };

        public static readonly Dictionary<int, string> OrderStatus = new Dictionary<int, string>()
        {
           { 1, "Order Success" },
           { 2, "Shipping" },
           { 3, "Paid and Received" },
           { 4, "Canceled" },
        };

        public struct Order
        {
            public const string CODPaymentMethods = "COD";
            public const string BankTransferPaymentMethods = "BankTransfer";
            public const string MoMoPaymentMethods = "MoMo";
        }
    }
}