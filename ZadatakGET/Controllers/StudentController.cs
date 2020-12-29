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
    public class StudentController : Controller
    {
        public UnitOfWork UnitOfWork = new UnitOfWork(new Zadatak2Context());
        // GET: Student
        public ActionResult Index(int? BI)
        {
            List<Student> studenti = UnitOfWork.Studenti.GetAll() as List<Student>;
            List<Student> lista = new List<Student>();
            if (BI == null) return View(studenti);
            foreach (Student s in studenti)
            {
                if (s.BI == BI) lista.Add(s);
            }
            return View(lista);
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = UnitOfWork.Studenti.FindStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BI,Ime,Prezime,Adresa,Grad")] Student student)
        {
            //List<string> brin = UnitOfWork.Studenti.Find(x => (x.BrojIndexa == student.BrojIndexa)).Select(x => x.BrojIndexa).ToList();
            //if (brin.Count > 0) ModelState.AddModelError("Ime", "Student sa ovim indeksom postoji.");
            if (String.IsNullOrEmpty(student.Ime)) ModelState.AddModelError("Ime", "Obavezno unesite ime.");
            if (String.IsNullOrEmpty(student.Prezime)) ModelState.AddModelError("Prezime", "Obavezno unesite prezime.");
            if (String.IsNullOrEmpty(student.Adresa)) ModelState.AddModelError("Adresa", "Obavezno unesite adresu.");
            if (String.IsNullOrEmpty(student.Grad)) ModelState.AddModelError("Grad", "Obavezno unesite grad.");
            if (ModelState.IsValid)
            {
                UnitOfWork.Studenti.Create(student);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = UnitOfWork.Studenti.FindStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            var stu = new StudentModel { BI = student.BI, Ime = student.Ime, Prezime = student.Prezime, Adresa = student.Adresa, Grad = student.Grad };
            return View(stu);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BI,Ime,Prezime,Adresa,Grad")] StudentModel student)
        {
            if (String.IsNullOrEmpty(student.Ime)) ModelState.AddModelError("Ime", "Obavezno unesite ime.");
            if (String.IsNullOrEmpty(student.Prezime)) ModelState.AddModelError("Prezime", "Obavezno unesite prezime.");
            if (String.IsNullOrEmpty(student.Adresa)) ModelState.AddModelError("Adresa", "Obavezno unesite adresu.");
            if (String.IsNullOrEmpty(student.Grad)) ModelState.AddModelError("Grad", "Obavezno unesite grad.");
            if (ModelState.IsValid)
            {
                var stu = new Student { BI = student.BI, Ime = student.Ime, Prezime = student.Prezime, Adresa = student.Adresa, Grad = student.Grad };
                UnitOfWork.Studenti.Edit(stu);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = UnitOfWork.Studenti.FindStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student s = UnitOfWork.Studenti.FindStudent(id);
            if (s.IspitiStudent.Count > 0)
            {
                TempData["testmsg"] = "Student ima ispite!";
                return View(s);
            }
            UnitOfWork.Studenti.Delete(s);
            UnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteIspit(int? BI, int? PredmetId)
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
        [HttpPost, ActionName("DeleteIspit")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIspitConfirmed(int BI, int PredmetId)
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
