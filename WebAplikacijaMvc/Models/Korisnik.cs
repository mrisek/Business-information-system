using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacijaMvc.Models
{
    public class Korisnik
    {
        public string KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Unos { get; set; }
    }
}