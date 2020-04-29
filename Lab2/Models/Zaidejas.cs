using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Zaidejas
    {
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public string pozicija { get; set; }
        public string slapyvardis { get; set; }
        public string pilietybe { get; set; }
        public int prisijunge_nuo { get; set; }
        public int id_ZAIDEJAS { get; set; }
        public int fk_KOMANDAid_KOMANDA { get; set; }
    }
}