using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Zaidimas
    {
        public string Pavadinimas { get; set; }
        public string zanras { get; set; }
        public string reitingas { get; set; }
        public int leidimo_metai { get; set; }
        public int id_ZAIDIMAS { get; set; }
        public int fk_LEIDEJAS { get; set; }
    }
}