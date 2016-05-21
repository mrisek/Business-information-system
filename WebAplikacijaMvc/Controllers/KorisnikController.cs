using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Configuration;


namespace WebAplikacijaMvc.Controllers
{
    public class KorisnikController : Controller
    {
        //
        // GET: /Korisnik/
        public ActionResult Index()
        {
            return View();
        }


        //ovaj princip funkcionira
        public ActionResult UnosPodataka(WebAplikacijaMvc.Models.Dnevnica model)
        {
            //SqlConnection con = new SqlConnection("Server=tcp:pr4fbh2l9a.database.windows.net,1433;Database=Database;User ID=username_id;Password=password;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");

            SqlConnection con = new SqlConnection(WebConfigurationManager.AppSettings["SqlDatabaseConnectionString"]);

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            //cmd2.CommandText = "select KorisnikID from korisnik where Ime = '" + User.Identity.GetUserName() + "'";

            //insert Korisnik values((select KorisnikID from korisnik where Ime = 'mrisek'),        'fg','fg', 1);

            cmd.CommandText = "insert Dnevnica values((select KorisnikID from korisnik where KorisnickoIme = '"
                + User.Identity.GetUserName() + "'), '"
                + model.Odrediste + "', '"
                + model.Polaziste + "', '"
                + model.VrijemePolaska + "', '"
                + model.VrijemeDolaska + "');";

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();




            //string SQLConectionString = "[YourConnectionString]";

            //using (SqlConnection connection = new SqlConnection("Server=tcp:pr4fbh2l9a.database.windows.net,1433;Database=WebApplicationMvc11475;User ID=username_id;Password={your_password_here};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")) 
            //{
            //    SqlCommand command = new SqlCommand();
            //    command.Connection = connection;

            //    command.CommandType = System.Data.CommandType.Text;
            //    command.CommandText = @"INSERT Table1 VALUES (543, 'Luka', 'Risek');";
            //}

            //String a = model.Ime;
            return View();
        }

    }
}