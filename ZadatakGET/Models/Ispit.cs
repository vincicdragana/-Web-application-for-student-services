using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZadatakGET.Models
{
    public class Ispit
    {
        public Ispit()
        {

        }
        [Key, Column(Order = 0)]
        public int BI { get; set; }
        [Key, Column(Order = 1)]
        public int PredmetId { get; set; }

        public int Oena { get; set; }

        public virtual Student Student { get; set; }
        public virtual Predmet Predmet { get; set; }
    }
}