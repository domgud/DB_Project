using Lab2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class LeidejasEditViewModel
    {
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("tipas")]
        [Required]
        public string tipas { get; set; }
        [DisplayName("Ikurimo metai")]
        [Required]
        public int ikurimo_metai { get; set; }
        [DisplayName("bustine")]
        [Required]
        public string bustine { get; set; }
        [DisplayName("valstybe")]
        [Required]
        public string valstybe { get; set; }
        [DisplayName("ID")]
        public int id_LEIDEJAS { get; set; }
        public List<ZaidimasEditViewModel> zaidimai { get; set; }

    }
}