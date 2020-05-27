using Lab2.Repos;
using Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class AtaskaitaController : Controller
    {
        AtaskaitaRepo ataskaitos = new AtaskaitaRepo();
        // GET: Ataskaita
        public ActionResult Index(DateTime? nuo, int? nuoLeidejoMetai, float? nuoTurnyroPinigai)
        {
            AtaskaitaViewModel ataskaita = new AtaskaitaViewModel();
            ataskaita.nuo = nuo == null ? null : nuo;
            ataskaita.nuoLeidejoMetai = nuoLeidejoMetai == null ? null : nuoLeidejoMetai;
            ataskaita.nuoTurnyroPinigai = nuoTurnyroPinigai == null ? null : nuoTurnyroPinigai; 
            ataskaita.sutartys = ataskaitos.getAtaskaitaSutartciu(ataskaita.nuo, ataskaita.nuoLeidejoMetai, ataskaita.nuoTurnyroPinigai);
            foreach (var item in ataskaita.sutartys)
            {
                ataskaita.visoSuma += item.Pinigai;
                
            }
            ataskaita.visoKiekis = ataskaita.sutartys.Count;
            return View(ataskaita);
        }
    }
}