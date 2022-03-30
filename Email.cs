using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ValidaPluCafes
{

    internal class Email
    {

        public void sendEmail(String text)
        {
            SmtpClient client = new SmtpClient("10.128.10.32", 25);
            client.Credentials = new NetworkCredential("juarezo@sanborns.com.mx", "Cogo7454");

            MailAddress from = new MailAddress("juarezo@sanborns.com.mx", "Oscar Juarez");
            MailAddress to = new MailAddress("SappsiSoporte@sanborns.net");
            MailMessage message = new MailMessage(from, to);

            message.Body = text;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "Cantidad de articulos de tienda en Sanborns Cafe";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            try
            {
                client.Send(message);
                Console.WriteLine("Mail send successfull!");
                Log.writeLog("Mail send successfull!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Log.writeLog($"Error: {ex.Message}");
            }

            message.Dispose();
            client.Dispose();
            Console.WriteLine("Goodbye.");
            Log.writeLog("Goodbye.");
        }

        public void sendEmailOutlook(String text)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.Credentials = new NetworkCredential("oscar.jv@outlook.com", "tese_0073");
            client.EnableSsl = true;

            MailAddress from = new MailAddress("oscar.jv@outlook.com", "Oscar Juarez (outlook)");
            MailAddress to = new MailAddress("juarezo@sanborns.com.mx");
            MailMessage message = new MailMessage(from, to);

            message.Body = text;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "Cantidad de articulos de tienda en Sanborns Cafe";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            try
            {
                client.Send(message);
                Console.WriteLine("Mail send successfull!");
                Log.writeLog("Mail send successfull!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Log.writeLog($"Error: {ex.Message}");
            }

            message.Dispose();
            client.Dispose();
            Console.WriteLine("Goodbye.");
            Log.writeLog("Goodbye.");
        }
    }
}
