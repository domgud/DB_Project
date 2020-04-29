using Lab2.Models;
using Lab2.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class LeidejasController : Controller
    {
        // GET: Leidejas
        LeidejasRepository leidejasRepository = new LeidejasRepository();
        public ActionResult Index()
        {
            return View(leidejasRepository.getLeidejai());
        }

        // GET: Leidejas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Leidejas/Create
        public ActionResult Create()
        {
            Zaidimas leidejas = new Zaidimas();
            return View(leidejas);
        }

        // POST: Leidejas/Create
        [HttpPost]
        public ActionResult Create(Zaidimas collection)
        {
            try
            {
                // išsaugo nauja markę duomenų bazėje
                if (ModelState.IsValid)
                {
                    leidejasRepository.addLeidejas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Leidejas/Edit/5
        public ActionResult Edit(int id)
        {
            return View(leidejasRepository.getLeidejas(id));
        }

        // POST: Leidejas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Zaidimas collection)
        {
            try
            {
                // atnajina markes informacija
                if (ModelState.IsValid)
                {
                    leidejasRepository.updateLeidejas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Leidejas/Delete/5
        public ActionResult Delete(int id)
        {
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
    }
}
