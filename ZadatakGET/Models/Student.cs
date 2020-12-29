using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZadatakGET.Models
{
    public class Student
    {
        public Student()
        {
            IspitiStudent = new List<Ispit>();
        }

        [Key]
        public int BI { get; set; }
        [MaxLength(20)]
        public string Ime { get; set; }
        [MaxLength(20)]
        public string Prezime { get; set; }
        [MaxLength(30)]
        public string Adresa { get; set; }
        [MaxLength(20)]
        public string Grad { get; set; }
        public virtual ICollection<Ispit> IspitiStudent { get; set; }
    }
}