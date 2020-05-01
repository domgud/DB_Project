using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Lab2.Models;

namespace Lab2.ViewModels
{
    public class KomandaEditViewModel
    {

        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }

        [DisplayName("Ikurimo metai")]
        [Required]
        public int ikurimo_metai { get; set; }

        [DisplayName("Valstybe")]
        [Required]
        public string valstybe { get; set; }

        [DisplayName("Savininkas")]
        [Required]
        public int savininkas { get; set; }

        [DisplayName("ID")]
        [Required]
        public int id_KOMANDA { get; set; }
      

        public List<Treniruoja> treniruojaList { get; set; }
        public List<SelectListItem> TrenerisList { get; set; }

        public IList<SelectListItem> SavininkaiList { get; set; }
    }
}