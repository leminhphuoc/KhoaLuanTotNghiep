

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
    }
}