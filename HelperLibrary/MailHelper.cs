using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace HelperLibrary
{
    public class MailHelper
    {
        public void SendMail(string toEmailAdress, string subject, string content)
        {
            // Lấy trong app setting
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();


            bool enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

            string body = content;
            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAdress)); // Gửi message
            message.Subject = subject; // subject = subject
            message.IsBodyHtml = true; // Được gửi html
            message.Body = body; // Body = content truyền vào

            var client = new SmtpClient(); // Config khách hàng 
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost; // gán hot
            client.EnableSsl = enabledSsl; // Bật ssl
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0; // gán port
            client.Send(message); // Gửi mail
        }
    }
}
