using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.ViewModels
{
    public class TrenerisViewModel
    {

        [DisplayName("ID")]
        public int id_TRENERIS { get; set; }
        [DisplayName("Vardas")]
        public string vardas { get; set; }
        [DisplayName("Pavarde")]
        public string pavarde { get; set; }
        [DisplayName("amzius")]
        public int amzius { get; set; }
        [DisplayName("slapyvardis")]
        public string slapyvadis { get; set; }

    }
}