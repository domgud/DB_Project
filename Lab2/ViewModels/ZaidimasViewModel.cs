using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.ViewModels
{
    public class ZaidimasViewModel
    {
        [DisplayName("Pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("Zanras")]
        public string zanras { get; set; }
        [DisplayName("Marke")]
        public string reitingas { get; set; }
        [DisplayName("Leidimo metai")]
        public int leidimo_metai { get; set; }
        [DisplayName("Ar mokamas")]
        public bool ar_mokamas { get; set; }
        [DisplayName("ID")]
        public int id_ZAIDIMAS { get; set; }
        [DisplayName("Leidejas")]
        public int fk_LEIDEJASid_LEIDEJAS { get; set; }
    }
}