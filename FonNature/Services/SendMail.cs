using HelperLibrary;
using System.Configuration;

namespace FonNature.Services
{
    public static class SendMail
    {
        public static bool SendMailFromCustomer(string name, string email, string message)
        {
            if (email != null )
            {
                string content = System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Asset/Client/Mail/Message.html"));
                content = content.Replace("{{customer}}", name);
                content = content.Replace("{{email}}", email);
                content = content.Replace("{{message}}", message);
                new MailHelper().SendMail(ConfigurationManager.AppSettings["ToEmailAddress"].ToString(), "Mail from customer", content);
                return true;

            }
            return false;
        }

        public static bool SendMailSubcribe(string email)
        {
            if (email != null)
            {
                string content = System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Asset/Client/Mail/Subscribe.html"));
                content = content.Replace("{{email}}", email);
                new MailHelper().SendMail(email, "Mail Subcribe ", content);
                return true;

            }
            return false;
        }
    }
}