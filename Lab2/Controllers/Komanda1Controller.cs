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
        KomandaRepository komandos = new KomandaRepository();
        SavininkasRepository savininkai = new SavininkasRepository();
        TrenerisRepostiry treneriai = new TrenerisRepostiry();
        TreniruojaRepository treniruojaRepo = new TreniruojaRepository();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(komandos.getKomandos());
        }

        // GET: Komanda1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Komanda1/Create
        public ActionResult Create()
        {
            KomandaEditViewModel komanda = new KomandaEditViewModel();
            PopulateSelections(komanda);
            return View(komanda);
        }

        // POST: Komanda1/Create
        [HttpPost]
        public ActionResult Create(KomandaEditViewModel kurejas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int komandosID = komandos.addKomanda(kurejas);

                    if (komandosID < 0)
                    {
                        ViewBag.failed = "Nepavyko iterpti apdovanojimo";
                        return View(kurejas);
                    }

                    if (kurejas.treniruojaList != null)
                    {
                        foreach (var item in kurejas.treniruojaList)
                        {
                            item.fk_KOMANDAid_KOMANDA = komandosID;
                            treniruojaRepo.addTreniruojamas(item);
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
            KomandaEditViewModel komanda = komandos.getKomanda(id);
            PopulateSelections(komanda);
            return View(komanda);
        }

        // POST: Kurejai/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KomandaEditViewModel kurejas)
        {
            try
            {
                komandos.updateKomanda(kurejas);
                treniruojaRepo.deleteKuria(id);

                if (kurejas.treniruojaList != null)
                {
                    foreach (var item in kurejas.treniruojaList)
                    {
                        item.fk_KOMANDAid_KOMANDA = id;
                        treniruojaRepo.addTreniruojamas(item);
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
            KomandaEditViewModel komanda = komandos.getKomanda(id);
            return View(komanda);
        }

        // POST: Kurejai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                komandos.deleteKomanda(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public void PopulateSelections(KomandaEditViewModel kurejas)
        {
            var savininkas = savininkai.getSavininkas();
            var treneriai = this.treneriai.getTreneriai();

            List<SelectListItem> selectedSavininkai = new List<SelectListItem>();
            List<SelectListItem> selectedTreneriai = new List<SelectListItem>();


            foreach (var item in treneriai)
            {
                selectedTreneriai.Add(new SelectListItem() { Value = Convert.ToString(item.id_TRENERIS), Text = item.pavarde });
            }
            foreach (var item in savininkas)
            {
                selectedSavininkai.Add(new SelectListItem() { Value = Convert.ToString(item.id_SAVININKAS), Text = item.pavarde });
            }

            kurejas.SavininkaiList = selectedSavininkai;
            kurejas.TrenerisList = selectedTreneriai;
            kurejas.treniruojaList = treniruojaRepo.getTreniruoja(kurejas.id_KOMANDA);
        }
    }
}
