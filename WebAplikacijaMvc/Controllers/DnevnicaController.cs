using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

namespace WebAplikacijaMvc.Controllers
{
    public class DnevnicaController : Controller
    {
        //
        // GET: /Dnevnica/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnosPodataka(WebAplikacijaMvc.Models.Dnevnica model)
        {
            //SqlConnection con = new SqlConnection("Server=tcp:pr4fbh2l9a.database.windows.net,1433;Database=webappsAFRofs7vo;User ID=username_id;Password=password;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");

            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;

            //cmd.CommandText = "INSERT Dnevnica VALUES ("
            //    + model.DnevnicaID + ", '" 
            //    + model.KorisnikID + "', '" 
            //    + model.Polaziste + "'), '" 
            //    + model.Odrediste + "'), '" 
            //    + model.VrijemePolaska + "'), '" 
            //    + model.VrijemeDolaska + "');";
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();


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