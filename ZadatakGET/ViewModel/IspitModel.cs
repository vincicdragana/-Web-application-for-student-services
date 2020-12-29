using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakGET.Models;

namespace ZadatakGET.ViewModel
{
    public class IspitModel
    {
        public IspitModel()
        {

        }
        public int BI { get; set; }
        public int PredmetId { get; set; }

        public int Oena { get; set; }

        public virtual Student Student { get; set; }
        public virtual Predmet Predmet { get; set; }

        public Ispit Parse()
        {
            return new Ispit { BI = this.BI, PredmetId = this.PredmetId, Oena = this.Oena, Student = this.Student, Predmet = this.Predmet };
        }

        public static IspitModel ParseInModel(Ispit i)
        {
            return new IspitModel { BI = i.BI, PredmetId = i.PredmetId, Oena = i.Oena, Student = i.Student, Predmet = i.Predmet };
        }
    }
}