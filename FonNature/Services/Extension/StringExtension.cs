using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FonNature.Services.Extension
{
    public static class StringExtension
    {
        public static string RemoveAreaCode(this string mobilePhone)
        {
            if(string.IsNullOrWhiteSpace(mobilePhone))
            {
                return string.Empty;
            }

            var areaCodeRegexPattern1 = @"(0[5|3|7|8|9])+([0-9]{8})\b";
            var areaCodeRegexPattern2 = @"(84[5|3|7|8|9])+([0-9]{8})\b";
            var areaCodeRegexPattern3 = @"(\+84[5|3|7|8|9])+([0-9]{8})\b";
            var regexFormat1 = new Regex(areaCodeRegexPattern1);
            var regexFormat2 = new Regex(areaCodeRegexPattern2);
            var regexFormat3 = new Regex(areaCodeRegexPattern3);

            if(regexFormat1.IsMatch(mobilePhone))
            {
                return mobilePhone;
            }

            if (regexFormat2.IsMatch(mobilePhone))
            {
                var mobilePhoneWithoutAreaCode = mobilePhone.Substring(2);
                return mobilePhoneWithoutAreaCode.Insert(0,"0");
            }

            if (regexFormat3.IsMatch(mobilePhone))
            {
                var mobilePhoneWithoutAreaCode = mobilePhone.Substring(3);
                return mobilePhoneWithoutAreaCode.Insert(0, "0");
            }

            return string.Empty;
        }

        public static string GenerateToken()
        {
            var time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            var key = Guid.NewGuid().ToByteArray();

            return Convert.ToBase64String(time.Concat(key).ToArray());
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}