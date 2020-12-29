using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakGET.Models;

namespace ZadatakGET.Repository
{
    public class PredmetRepository : Repository<Predmet>, IPredmetRepository
    {
        public PredmetRepository(Zadatak2Context db)
                 : base(db)
        {
        }

        public Zadatak2Context IspitContext
        {
            get { return DB as Zadatak2Context; }
        }

        public Predmet FindPredmet(int? PredmetId)
        {
            return set.Find(PredmetId);
        }
    }
}