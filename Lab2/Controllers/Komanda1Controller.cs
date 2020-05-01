using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Repos;

namespace Lab2.Controllers
{
    public class Komanda1Controller : Controller
    {
        // GET: Komanda1
        KomandaRepository kurejai = new KomandaRepository();
        SavininkasRepository lytis = new SavininkasRepository();
        TrenerisRepostiry tvlaidos = new TrenerisRepostiry();
        TreniruojaRepository kuriaRepo = new TreniruojaRepository();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(kurejai.getKurejai());
        }

        // GET: Komanda1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Komanda1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Komanda1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Komanda1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Komanda1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Komanda1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Komanda1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
