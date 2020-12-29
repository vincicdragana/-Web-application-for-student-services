using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZadatakGET.Models;
using ZadatakGET.Repository;
using ZadatakGET.ViewModel;

namespace ZadatakGET.Controllers
{
    public class IspitController : Controller
    {
        public UnitOfWork UnitOfWork = new UnitOfWork(new Zadatak2Context());

        // GET: Ispit
        public ActionResult Index(string naziv)
        {
            List<Ispit> ispits = UnitOfWork.Ispiti.GetAll() as List<Ispit>;
            var lista = new List<Ispit>();
            if (String.IsNullOrEmpty(naziv)) return View(ispits.ToList());
            foreach (Ispit i in ispits)
            {
                i.Predmet = UnitOfWork.Predmeti.FindPredmet(i.PredmetId);
                i.Student = UnitOfWork.Studenti.FindStudent(i.BI);
            }
            foreach (Ispit i in ispits)
            {
                if ((i.Predmet.Naziv.Contains(naziv)) || (i.Predmet.Naziv.Contains(naziv.ToUpper())))
                {
                    lista.Add(i);
                }
            }
            return View(lista);
        }

        // GET: Ispit/Details/5
        public ActionResult Details(int? BI, int? PredmetId)
        {
            if (BI == null || PredmetId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = UnitOfWork.Ispiti.FindIspit(BI, PredmetId);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // GET: Ispit/Create
        public ActionResult Create()
        {
            ViewBag.PredmetId = new SelectList(UnitOfWork.Predmeti.GetAll() as List<Predmet>, "PredmetId", "Naziv");
            ViewBag.BI = new SelectList(UnitOfWork.Studenti.GetAll() as List<Student>, "BI", "BI");

            return View();
        }

        // POST: Ispit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BI,PredmetId,Oena")] Ispit ispit)
        {
            List<Ispit> lista = UnitOfWork.Ispiti.GetAll() as List<Ispit>;
            foreach (Ispit i in lista)
            {
                if (i.PredmetId == ispit.PredmetId && i.BI == ispit.BI)
                {

                    ModelState.AddModelError("PredmetId", "Student je polozio izabrani ispit.");
                }
            }
            if (ModelState.IsValid)
            {
                UnitOfWork.Ispiti.Create(ispit);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PredmetId = new SelectList(UnitOfWork.Predmeti.GetAll() as List<Predmet>, "PredmetId", "Naziv", ispit.PredmetId);
            ViewBag.BI = new SelectList(UnitOfWork.Studenti.GetAll() as List<Student>, "BI", "BI", ispit.BI);
            return View(ispit);
        }

        // GET: Ispit/Edit/5
        public ActionResult Edit(int? BI, int? PredmetId)
        {
            if (BI == null || PredmetId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = UnitOfWork.Ispiti.FindIspit(BI, PredmetId);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            ViewBag.PredmetId = new SelectList(UnitOfWork.Predmeti.GetAll() as List<Predmet>, "PredmetId", "Naziv", ispit.PredmetId);
            ViewBag.BI = new SelectList(UnitOfWork.Studenti.GetAll() as List<Student>, "BI", "Ime", ispit.BI);
            return View(ispit);
        }

        // POST: Ispit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BI,PredmetId,Oena")] IspitModel ispit)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Ispiti.Edit(ispit.Parse());
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PredmetId = new SelectList(UnitOfWork.Predmeti.GetAll() as List<Predmet>, "PredmetId", "Naziv", ispit.PredmetId);
            ViewBag.BI = new SelectList(UnitOfWork.Studenti.GetAll() as List<Student>, "BI", "Ime", ispit.BI);

            return View();
        }

        // GET: Ispit/Delete/5
        public ActionResult Delete(int? BI, int? PredmetId)
        {
            if (BI == null || PredmetId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = UnitOfWork.Ispiti.FindIspit(BI, PredmetId);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // POST: Ispit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int BI, int PredmetId)
        {
            Ispit ispit = UnitOfWork.Ispiti.FindIspit(BI, PredmetId);
            UnitOfWork.Ispiti.Delete(ispit);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
