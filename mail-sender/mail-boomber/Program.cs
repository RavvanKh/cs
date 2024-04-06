using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mail_boomber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fromMail = "yourmail@gmail.com";
            string fromPassword = "yourPassword";
            MailMessage message = new MailMessage(); 
            message.From = new MailAddress(fromMail);
            message.Subject = "Test mail from WorkShop";
            message.To.Add(new MailAddress("receiversmail@gmail.com"));
            message.Body = "Test body from WorkShop";


            var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(fromMail, fromPassword);
            smtpClient.EnableSsl = true;
            try
            {
                    smtpClient.Send(message);
                    Console.WriteLine("Message was sent successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
