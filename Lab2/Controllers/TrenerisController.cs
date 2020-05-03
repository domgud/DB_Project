using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Repos;
using Lab2.ViewModels;
namespace Lab2.Controllers
{
    public class TrenerisController : Controller
    {
        // GET: Treneris
        TrenerisRepostiry treneriai = new TrenerisRepostiry();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(treneriai.getTreneriai());
        }

        // GET: Treneris/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Treneris/Create
        public ActionResult Create()
        {
            TrenerisEditViewModel treneris = new TrenerisEditViewModel();
            return View(treneris);
        }

        // POST: Treneris/Create
        [HttpPost]
        public ActionResult Create(TrenerisEditViewModel treneris)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int trenerioId = treneriai.addTreneris(treneris);

                    if (trenerioId < 0)
                    {
                        ViewBag.failed = "Nepavyko iterpti";
                        return View(treneris);
                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Treneris/Edit/5
        public ActionResult Edit(int id)
        {
            TrenerisEditViewModel treneris = treneriai.getTreneris(id);
            return View(treneris);
        }

        // POST: Treneris/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TrenerisEditViewModel treneris)
        {
            try
            {
                //zaidimas.id_ZAIDIMAS = id;
                treneriai.updateTreneris(treneris);


                return RedirectToAction("Index");
            }
            catch
            {
                return View(treneris);
            }
        }

        // GET: Treneris/Delete/5
        public ActionResult Delete(int id)
        {
            TrenerisEditViewModel treneris = treneriai.getTreneris(id);
            return View(treneris);
        }

        // POST: Treneris/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TrenerisEditViewModel treneris)
        {
            try
            {
                // TODO: Add delete logic here


                treneriai.deleteTreneris(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
