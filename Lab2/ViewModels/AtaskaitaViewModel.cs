using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class AtaskaitaViewModel
    {
        public List<STurnyrasViewModel> sutartys { get; set; }
        public float visoSuma { get; set; }
        public int visoKiekis { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? nuo { get; set; }
        public int? nuoLeidejoMetai { get; set; }
        public float? nuoTurnyroPinigai { get; set; }

    }
}