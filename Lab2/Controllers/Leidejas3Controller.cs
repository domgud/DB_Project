using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;
using Lab2.Repos;
using Lab2.ViewModels;
namespace Lab2.Controllers
{
    public class Leidejas3Controller : Controller
    {

        LeidejasRepository leidejasRepository = new LeidejasRepository();
        ZaidimasRepository zaidimasRepository = new ZaidimasRepository();
        // GET: Leidejas3
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(leidejasRepository.getLeidejai());
        }

        // GET: TvLaidos/Create
        public ActionResult Create()
        {
            LeidejasEditViewModel leidejas = new LeidejasEditViewModel();
            UpdateTables(leidejas);
            //Užpildomi pasirinkimų sąrašai duomenimis iš duomenų saugyklų
            return View(leidejas);
        }

        // POST: TvLaidos/Create
        [HttpPost]
        public ActionResult Create(LeidejasEditViewModel leidejas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int laidos_id = leidejasRepository.insertPaslauga(leidejas);

                    if (laidos_id < 0)
                    {
                        ViewBag.failed = "Nepavyko iterpti apdovanojimo";
                        return View(leidejas);
                    }

                    if (leidejas.zaidimai != null)
                    {
                        foreach (var item in leidejas.zaidimai)
                        {
                            if (item.fk_LEIDEJASid_LEIDEJAS == 0)
                            {
                                item.fk_LEIDEJASid_LEIDEJAS = laidos_id;
                                zaidimasRepository.insertZaidimas(item);
                            }
                        }
                    }
                }
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                //PopulateSelections(leidejas);
                UpdateTables(leidejas);
                return View(leidejas);
            }
        }

        public ActionResult Edit(int id)
        {
            LeidejasEditViewModel leidejas = leidejasRepository.getLeidejasViewModel(id);
            leidejas.zaidimai = zaidimasRepository.getZaidimas(id);
            UpdateTables(leidejas);
            return View(leidejasRepository.getLeidejasViewModel(id));
        }

        // POST: Leidejas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LeidejasEditViewModel collection)
        {
            try
            {
                leidejasRepository.updateLeidejas(collection);
                zaidimasRepository.deleteZaidimas(id);
                UpdateTables(leidejasRepository.getLeidejasViewModel(id));
                // atnajina markes informacija
                if (collection.zaidimai != null)
                {
                    foreach (var item in collection.zaidimai)
                    {
                        item.fk_LEIDEJASid_LEIDEJAS= id;
                        zaidimasRepository.insertZaidimas(item);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                UpdateTables(leidejasRepository.getLeidejasViewModel(id));
                return View(collection);
            }
        }

        public ActionResult Delete(int id)
        {
            var leidejas = leidejasRepository.getLeidejas(id);
            return View(leidejasRepository.getLeidejas(id));
        }

        // POST: Leidejas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                leidejasRepository.deleteLeidejas(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void UpdateTables(LeidejasEditViewModel leidejas)
        {
            leidejas.zaidimai = zaidimasRepository.getZaidimas(leidejas.id_LEIDEJAS);
        }
    }
}
