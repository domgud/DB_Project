using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class STurnyrasViewModel
    {
        public string Turnyras { get; set; }
        public float Pinigai { get; set; }
        public float Minimum { get; set; }
        public float Maximum { get; set; }
        public float BendraSuma { get; set; }
        public int BendrasKiekis { get; set; }
        public DateTime Data { get; set; }
        public string Organizatorius { get; set; }
        public string Zaidimas { get; set; }
        public string Leidejas { get; set; }
        [DisplayName("Komandu skaicius")]
        public int LeidejoMetai { get; set; }
    }
}