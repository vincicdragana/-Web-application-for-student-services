using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZadatakGET.Models
{
    public class Predmet
    {
        public Predmet()
        {
            IspitiPredmet = new List<Ispit>();
        }

        public int PredmetId { get; set; }
        [MaxLength(30)]
        public string Naziv { get; set; }

        public virtual ICollection<Ispit> IspitiPredmet { get; set; }
    }
}