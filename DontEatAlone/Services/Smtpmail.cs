using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;

namespace DontEatAlone.Services
{
    public class Smtpmail
    {
        public void SendEmail(string Name, string Email, string Message)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(Email, Name));

                // From
                mailMsg.From = new MailAddress("donteatalone@dea.com", "Admin");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "Confirm your email address";
                string text = Message;
                string html = @"<p>html body</p>";

                mailMsg.AlternateViews.Add(
                        AlternateView.CreateAlternateViewFromString(text,
                                null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(
                        AlternateView.CreateAlternateViewFromString(html,
                        null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient
                = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials
                = new System.Net.NetworkCredential("timetrapper",
                                                   ":sG]5[2sWKkLNDXY");
                smtpClient.Credentials = credentials;
                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
