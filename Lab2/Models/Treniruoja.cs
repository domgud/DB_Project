using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Treniruoja
    {
        [DisplayName("Komanda")]
        [Required]
        public int fk_KOMANDAid_KOMANDA { get; set; }
        [DisplayName("Trenerius")]
        [Required]
        public int fk_TRENERISid_TRENERIS { get; set; }
    }
}