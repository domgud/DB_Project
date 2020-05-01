using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Repos;
using Lab2.ViewModels;
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
            KomandaEditViewModel kurejas = new KomandaEditViewModel();
            PopulateSelections(kurejas);
            return View(kurejas);
        }

        // POST: Komanda1/Create
        [HttpPost]
        public ActionResult Create(KomandaEditViewModel kurejas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int kurejoID = kurejai.addKurejas(kurejas);

                    if (kurejoID < 0)
                    {
                        ViewBag.failed = "Nepavyko iterpti apdovanojimo";
                        return View(kurejas);
                    }

                    if (kurejas.treniruojaList != null)
                    {
                        foreach (var item in kurejas.treniruojaList)
                        {
                            item.fk_KOMANDAid_KOMANDA = kurejoID;
                            kuriaRepo.addKuriamas(item);
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(kurejas);
                return View();
            }
        }
        // GET: Kurejai/Edit/5
        public ActionResult Edit(int id)
        {
            KomandaEditViewModel kurejas = kurejai.getKurejas(id);
            PopulateSelections(kurejas);
            return View(kurejas);
        }

        // POST: Kurejai/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KomandaEditViewModel kurejas)
        {
            try
            {
                kurejai.updateKurejas(kurejas);
                kuriaRepo.deleteKuria(id);

                if (kurejas.treniruojaList != null)
                {
                    foreach (var item in kurejas.treniruojaList)
                    {
                        item.fk_KOMANDAid_KOMANDA = id;
                        kuriaRepo.addKuriamas(item);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(kurejas);
                return View(kurejas);
            }
        }

        // GET: Komanda1/Edit/5
        public ActionResult Delete(int id)
        {
            KomandaEditViewModel kurejas = kurejai.getKurejas(id);
            return View(kurejas);
        }

        // POST: Kurejai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                kurejai.deleteKurejas(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public void PopulateSelections(KomandaEditViewModel kurejas)
        {
            var savininkas = lytis.getSavininkas();
            var treneriai = tvlaidos.getShows();

            List<SelectListItem> selectListLytis = new List<SelectListItem>();
            List<SelectListItem> selectLaida = new List<SelectListItem>();


            foreach (var item in treneriai)
            {
                selectLaida.Add(new SelectListItem() { Value = Convert.ToString(item.id_TRENERIS), Text = item.pavarde });
            }
            foreach (var item in savininkas)
            {
                selectListLytis.Add(new SelectListItem() { Value = Convert.ToString(item.id_SAVININKAS), Text = item.pavarde });
            }

            kurejas.SavininkaiList = selectListLytis;
            kurejas.TrenerisList = selectLaida;
            kurejas.treniruojaList = kuriaRepo.getKuria(kurejas.id_KOMANDA);
        }
    }
}
