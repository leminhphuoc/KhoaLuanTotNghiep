

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
    }
}