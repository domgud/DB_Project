using Lab2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.ViewModels
{
    public class ZaidimasEditViewModel
    {
        [DisplayName("Pavadinimas")]
        public string pavadinimas { get; set; }
        [DisplayName("Zanras")]
        public string zanras { get; set; }
        [DisplayName("Marke")]
        public string reitingas { get; set; }
        [DisplayName("Leidimo metai")]
        public int leidimo_metai { get; set; }

        [DisplayName("ID")]
        public int id_ZAIDIMAS { get; set; }

        public int fk_LEIDEJASid_LEIDEJAS { get; set; }
        public IList<SelectListItem> LeidejaiList { get; set; }
        public List<Leidejas> treniruojaList { get; set; }

    }
}