using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    public class KATYAEmail
    {
        public MailAddress From { get; set; }
        public MailAddress To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public object Attachment { get; set; }
        private string SMTPServer = "";
        private MailMessage Email { get; set; }
        SmtpClient EmailClient { get; set; }
        private NetworkCredential EmailClientCredentials { get; set; }
        public KATYAEmail(string From, string To, string Subject, string Body)
        {
            this.From = new MailAddress(From);
            this.To = new MailAddress(To);
            this.Email = new MailMessage(this.From, this.To);
            this.Email.Subject = Subject;
            this.Email.Body = Body;
            this.EmailClient = new SmtpClient("smtp.gmail.com", 587);
            EmailClient.Credentials = new NetworkCredential("shawn25n92fb@gmail.com","Marines_54");
            
        }
        public StatusObject Send()
        {
            StatusObject SO = new StatusObject();
            try
            {
                
                
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "EMAIL_SEND");
            }
            return SO;
        }
        public StatusObject SetEmailClientCredentials(string UsernameOrEmail, string Password)
        {
            StatusObject SO = new StatusObject();
            try
            {
                this.EmailClientCredentials = new NetworkCredential(UsernameOrEmail, Password);
            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
