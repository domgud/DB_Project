using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab2.ViewModels
{
    public class KomandaViewModel
    {
        [DisplayName("Pavadinimas")]

        public string pavadinimas { get; set; }
        [DisplayName("Ikurimo_metai")]

        public int ikurimo_metai { get; set; }
        [DisplayName("Valstybe")]

        public string valstybe { get; set; }
        [DisplayName("Savininkas")]

        public string savininkas { get; set; }
        [DisplayName("ID")]

        public int id_KOMANDA { get; set; }
    }
}