using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakGET.Models;

namespace ZadatakGET.ViewModel
{
    public class StudentModel
    {
        public int BI { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }

        public string Grad { get; set; }

        public Student Parse()
        {
            return new Student { BI = this.BI, Ime = this.Ime, Prezime = this.Prezime, Adresa = this.Adresa, Grad = this.Grad };

        }

        public static StudentModel ParseInModel(Student s)
        {
            return new StudentModel { BI = s.BI, Ime = s.Ime, Prezime = s.Prezime, Adresa = s.Adresa, Grad = s.Grad };

        }
    }
}