﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using System.Net.Mail;
using SendGrid.Helpers.Mail;
using System.Text.Encodings.Web;
using System.Net.Mime;

namespace DontEatAlone.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        //public Task SendEmailAsync(string email, string subject, string message)
        //{
        //    return Task.CompletedTask;
        //}

        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(email, "To Name"));

                // From
                mailMsg.From = new MailAddress("emailaddress@home.com", "From Name");

                // Subject and multipart/alternative Body
                mailMsg.Subject = subject;


                // You can send text instead of HTML if you prefer.
                // mailMsg.AlternateViews.Add(
                //         AlternateView.CreateAlternateViewFromString(message, 
                //         null, MediaTypeNames.Text.Plain));

                // Use this technique to add HTML tags if you need.  
                // string html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(
                        AlternateView.CreateAlternateViewFromString(message,
                        null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient
                = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

                System.Net.NetworkCredential credentials
                = new System.Net.NetworkCredential("timetrapper", ":sG]5[2sWKkLNDXY");

                smtpClient.Credentials = credentials;
                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}