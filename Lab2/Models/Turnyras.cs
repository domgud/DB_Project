using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Turnyras
    {
        public string pavadinimas { get; set; }
        public string vieta { get; set; }
        public string tipas { get; set; }
        public float prizu_fondo_dydis { get; set; }
        public int komandu_skaicius { get; set; }
        public string nugaletojas { get; set; }
        public string svetaine { get; set; }
        public int data { get; set; } //tik metai del to int
        public int id_TURNYRAS { get; set; }
        public int fk_ORGANIZATORIUSid_ORGANIZATORIUS { get; set; }
        public int fk_ZAIDIMASid_ZAIDIMAS { get; set; }
    }
}