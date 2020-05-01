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
    public class TrenerisEditViewModel
    {
        [DisplayName("ID")]
        [Required]
        public int id_TRENERIS { get; set; }
        [DisplayName("Vardas")]
        [Required]
        public string vardas { get; set; }
        [DisplayName("Pavarde")]
        [Required]
        public string pavarde { get; set; }
        [DisplayName("amzius")]
        [Required]
        public int amzius { get; set; }
        [DisplayName("slapyvardis")]
        [Required]
        public string slapyvadis { get; set; }
    }
}