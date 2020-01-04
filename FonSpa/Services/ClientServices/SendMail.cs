using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services.ClientServices
{
    public class SendMail
    {
        public static bool SendMailFromCustomer(string name, string email, string message)
        {
            if (email != null )
            {
                string content = System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Asset/Client/Mail/Message.html"));
                content = content.Replace("{{customer}}", name);
                content = content.Replace("{{email}}", email);
                content = content.Replace("{{message}}", message);
                new MailHelper().SendMail("kevinle021097@gmail.com", "Mail from customer", content);
                return true;

            }
            return false;
        }
    }
}