using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailService.MailSystem
{
    public class Email 
    {
        public void SendMail(string receiverEmail, string senderEmail, string senderEmailPassword, string mailBody, string pathAttachments, string mailSubject, string host, int port)
        {
            using (var message = new MailMessage(senderEmail, receiverEmail))
            {
                if (!string.IsNullOrEmpty(pathAttachments))
                {
                    message.Attachments.Add(new Attachment(pathAttachments));
                }

                var bodyBuilder = new StringBuilder(mailBody);
                message.Subject = mailSubject;
                message.Body = bodyBuilder.ToString();
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient(host, port))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderEmailPassword);

                    try
                    {
                         client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception here or log it
                        throw ex;
                    }
                }
            }
        }

    }
}