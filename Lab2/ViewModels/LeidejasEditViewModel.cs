using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class LeidejasEditViewModel
    {
        public Leidejas leidejas { get; set; }
        public List<ZaidimasViewModel> zaidimai { get; set; }
    }
}