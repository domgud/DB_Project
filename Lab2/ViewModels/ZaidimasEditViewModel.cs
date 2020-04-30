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
        [MaxLength(50)]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Zanras")]
        [MaxLength(20)]
        [Required]
        public string zanras { get; set; }
        [DisplayName("Marke")]
        [MaxLength(20)]
        [Required]
        public string reitingas { get; set; }
        [DisplayName("Leidimo metai")]
        [MaxLength(4)]
        [Required]
        public int leidimo_metai { get; set; }
        [DisplayName("Ar mokamas")]
        [Required]
        public bool ar_mokamas { get; set; }
        [DisplayName("ID")]
        [Required]
        public int id_ZAIDIMAS { get; set; }
        [DisplayName("Leidejas")]
        [Required]
        public int fk_LEIDEJASid_LEIDEJAS { get; set; }
        public IList<SelectListItem> LeidejaiList { get; set; }
    }
}