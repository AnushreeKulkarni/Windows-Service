using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace WindowsServiceAssignment.SMTPDemo
{
   public class SendMail
    {
      
        public void SendEmail(string subject , string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("xyz@gmail.com");
                mail.To.Add("pqr@gmail.com");
                mail.To.Add("qwerty@gmail.com");
                mail.Subject = subject;
                mail.Body = body;
                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com",587))
                {
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("xyz@gmail.com", "");
                    SmtpServer.Send(mail);
                }
                Console.WriteLine("Mail Sent");
            }
            catch(Exception ex)
            {
               
            }
        }
        }
    }

