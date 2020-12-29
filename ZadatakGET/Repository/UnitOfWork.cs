using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakGET.Models;

namespace ZadatakGET.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Zadatak2Context db;
        public UnitOfWork(Zadatak2Context context)
        {
            db = context;
            Studenti = new StudentRepository(db);
            Ispiti = new IspitRepository(db);
            Predmeti = new PredmetRepository(db);
        }
        public IStudentRepository Studenti { get; set; }
        public IIspitRepository Ispiti { get; set; }
        public IPredmetRepository Predmeti { get; set; }

        public virtual void Dispose()
        {
            db.Dispose();
        }

        public virtual int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}