using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Lab2.Models;

namespace Lab2.ViewModels
{
    public class KomandaEditViewModelList
    {
        [DisplayName("Pavadinimas")]
        [MaxLength(50)]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Ikurimo_metai")]
        [MaxLength(50)]
        [Required]
        public int ikurimo_metai { get; set; }
        [DisplayName("Valstybe")]
        [MaxLength(50)]
        [Required]
        public string valstybe { get; set; }
        [DisplayName("Savininkas")]
        [MaxLength(50)]
        [Required]
        public int savininkas { get; set; }
        [DisplayName("ID")]
        [MaxLength(50)]
        [Required]
        public int id_KOMANDA { get; set; }
      

        public List<Treniruoja> treniruojaList { get; set; }
        public List<SelectListItem> TrenerisList { get; set; }

        public IList<SelectListItem> SavininkaiList { get; set; }
    }
}