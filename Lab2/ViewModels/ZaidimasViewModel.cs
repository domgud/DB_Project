using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;
namespace Lab2.ViewModels
{
    public class ZaidimasViewModel
    {

        [DisplayName("Pavadinimas")]

        public string pavadinimas { get; set; }
        [DisplayName("Zanras")]

        public string zanras { get; set; }
        [DisplayName("reitingas")]

        public string reitingas { get; set; }
        [DisplayName("Leidimo metai")]

        public int leidimo_metai { get; set; }

        public int id_ZAIDIMAS { get; set; }
        [DisplayName("Leidejas")]
        public string leidejas { get; set; }
        
    }
}