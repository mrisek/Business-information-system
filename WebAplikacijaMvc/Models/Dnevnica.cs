using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//validacija
using System.ComponentModel.DataAnnotations;

namespace WebAplikacijaMvc.Models
{
    public class Dnevnica
    {
        [Required(ErrorMessage = "Unesite mjesto polaska.")]
        [Display(Name = "Polazište")]
        public string Polaziste { get; set; }

        [Required(ErrorMessage = "Unesite mjesto odredišta.")]
        [Display(Name = "Odredište")]
        public string Odrediste { get; set; }

        [Required(ErrorMessage = "Unesite vrijeme polaska.")]
        [Display(Name = "Vrijeme polaska")]
        public string VrijemePolaska { get; set; }

        [Required(ErrorMessage = "Unesite vrijeme dolaska.")]
        [Display(Name = "Vrijeme dolaska")]
        public string VrijemeDolaska { get; set; }
    }
}


