using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakGET.Models;

namespace ZadatakGET.Repository
{
    public class IspitRepository : Repository<Ispit>, IIspitRepository
    {
        public IspitRepository(Zadatak2Context db)
            : base(db)
        {
        }

        public Zadatak2Context IspitContext
        {
            get { return DB as Zadatak2Context; }
        }

        public virtual Ispit FindIspit(int? BI, int? PredmetId)
        {
            return set.Find(BI, PredmetId);
        }

    }
}