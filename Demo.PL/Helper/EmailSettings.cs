using Demo.DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace Demo.PL.Helper
{
    public  static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.sendgrid.net", 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("apikey", "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");
            Client.Send("samarelgammal19122000@gmail.com", email.To, email.Title, email.Body);

        }


    }
}
