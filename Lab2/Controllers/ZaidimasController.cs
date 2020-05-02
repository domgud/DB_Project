using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Repos;
using Lab2.ViewModels;

namespace Lab2.Controllers
{
    public class ZaidimasController : Controller
    {
        ZaidimasRepository zaidimai = new ZaidimasRepository();
        LeidejasRepository leidejai = new LeidejasRepository();
        // GET: Zaidimas
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(zaidimai.getZaidimai());
        }

        // GET: Zaidimas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Zaidimas/Create
        public ActionResult Create()
        {
            ZaidimasEditViewModel zaidimas = new ZaidimasEditViewModel();
            PopulateSelections(zaidimas);
            return View(zaidimas);
        }

        // POST: Zaidimas/Create
        [HttpPost]
        public ActionResult Create(ZaidimasEditViewModel zaidimas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int zaidimoID = zaidimai.insertZaidimas(zaidimas);

                    if (zaidimoID < 0)
                    {
                        ViewBag.failed = "Nepavyko iterpti";
                        return View(zaidimas);
                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(zaidimas);
                return View();
            }
        }

        // GET: Zaidimas/Edit/5
        public ActionResult Edit(int id)
        {
            ZaidimasEditViewModel zaidimas = zaidimai.getZaidimasID(id);
            PopulateSelections(zaidimas);
            return View(zaidimas);
        }

        // POST: Zaidimas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ZaidimasEditViewModel zaidimas)
        {
            try
            {
                //zaidimas.id_ZAIDIMAS = id;
                zaidimai.updateZaidimas(zaidimas);


                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(zaidimas);
                return View(zaidimas);
            }
        }

        // GET: Zaidimas/Delete/5
        public ActionResult Delete(int id)
        {
            ZaidimasEditViewModel zaidimas = zaidimai.getZaidimasID(id);
            return View(zaidimas);
        }

        // POST: Zaidimas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ZaidimasEditViewModel zaidimas)
        {
            try
            {
                // TODO: Add delete logic here


                zaidimai.deleteZaidimasID(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void PopulateSelections(ZaidimasEditViewModel zaidimas)
        {
            var leidejaiList = leidejai.getLeidejai();

            List<SelectListItem> selectedLeidejai = new List<SelectListItem>();


            foreach (var item in leidejaiList)
            {
                selectedLeidejai.Add(new SelectListItem() { Value = Convert.ToString(item.id_LEIDEJAS), Text = item.pavadinimas });
            }

            zaidimas.LeidejaiList = selectedLeidejai;
        }
    }
}
