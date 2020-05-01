using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Repos;
namespace Lab2.Controllers
{
    public class ZaidimasController : Controller
    {
        ZaidimasRepository zaidimai = new ZaidimasRepository();
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
            return View();
        }

        // POST: Zaidimas/Create
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

        // GET: Zaidimas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Zaidimas/Edit/5
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

        // GET: Zaidimas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Zaidimas/Delete/5
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
