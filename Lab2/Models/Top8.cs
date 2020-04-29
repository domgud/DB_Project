using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Top8
    {
        public string atstovautas_regionas { get; set; }
        public int vieta { get; set; }
        public float  laimeti_pinigai { get; set; }
        public int id_TOP8 { get; set; }
        public int fk_KOMANDAid_KOMANDA { get; set; }
        public int fk_TURNYRASid_TURNYRAS { get; set; }
    }
}