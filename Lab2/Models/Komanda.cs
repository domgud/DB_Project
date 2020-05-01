using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Komanda
    {
        public string pavadinimas { get; set; }
        public int ikurimo_metai { get; set; }
        public string valstybe { get; set; }
        public Savininkas savininkas { get; set; }
        public int id_KOMANDA { get; set; }
    }
}