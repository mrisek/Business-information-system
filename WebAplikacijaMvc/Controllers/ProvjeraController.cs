using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using Microsoft.Exchange.WebServices.Data;
using System.Security.Policy;
using T = System.Threading.Tasks;

namespace WebAplikacijaMvc.Controllers
{
    public class ProvjeraController : AsyncController
    {
        public ActionResult Provjera()
        {
            T.Task.Factory.StartNew(() => ProvjeraDnevnica.pokreniProvjeru());
            return View();
        }

        public class ProvjeraDnevnica
        {
            public static void pokreniProvjeru()
            {
                StringBuilder poruka = new StringBuilder();
                List<String> popis = new List<string>();

                SqlConnection con = new SqlConnection("Server=tcp:pr4fbh2l9a.database.windows.net,1433;Database=webappsAFRofs7vo;User ID=username_id;Password=password;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //ispis svih e-mail adresa na koje se šalje mail
                cmd.CommandText = "SELECT Korisnik.Email FROM Korisnik where Unos = '0';";
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        popis.Add(reader.GetString(0));
                    }
                }
                con.Close();

            }
        }

        #region private methods

        /// <summary>
        /// Method for sending e-mail by using Office 365 and Exchange Server 2013
        /// </summary>
        /// <param name="Receiver">Receiver of the e-mail</param>
        /// <param name="Body">Body of the e-mail</param>
        /// <param name="Subject">Subject of the e-mail</param>
        private static void sendExchangeServiceEmail(string Receiver, string Body, string Subject)
        {
            try
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013);
                service.Credentials = new WebCredentials("e-mail@address.com", "password");
                service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
                service.AutodiscoverUrl("e-mail@address.com",
                    RedirectionUrlValidationCallback);

                //Create a new HTML message
                EmailMessage message = new EmailMessage(service);
                message.Subject = Subject;

                var MailBody = new MessageBody(BodyType.HTML, Body);
                message.Body = Body;
                message.ToRecipients.Add(Receiver);
                message.SendAndSaveCopy();

            }
            catch (Exception err)
            {
                throw new InvalidOperationException("Failed to send an email!", err);
            }
        }

        /// <summary>
        /// Method for redirection url validation callback
        /// </summary>
        /// <param name="redirectionUrl">Boolean if the redirection is validated or not</param>
        /// <returns>Boolean redirectionUrl</returns>
        private static bool RedirectionUrlValidationCallback(String redirectionUrl)
        {
            bool redirectionValidated = false;
            if (redirectionUrl.Equals(
                "https://autodiscover-s.outlook.com/autodiscover/autodiscover.xml"))
                redirectionValidated = true;

            return redirectionValidated;
        }

        #endregion
    }
}