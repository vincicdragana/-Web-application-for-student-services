using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakGET.Models;

namespace ZadatakGET.Data
{
    public class SeedClass
    {
        public static List<Student> GetStudents()
        {
            List<Student> studenti = new List<Student>
            {
                new Student()
                {
                    Ime = "Dragana",
                    Prezime = "Vincic",
                    Adresa = "Antifasisticke borbe 22",
                    Grad = "Beograd"
                },
                new Student()
                {
                    Ime = "Mirjana",
                    Prezime = "Vincic",
                    Adresa = "Antifasisticke borbe 22",
                    Grad = "Beograd"
                },
                new Student()
                {
                    Ime = "Marko",
                    Prezime = "Peric",
                    Adresa = "Bulevar Yorana Djinjdjica 12",
                    Grad = "Beograd"
                },
                new Student()
                {
                    Ime = "Srdjan",
                    Prezime = "ViSimicncic",
                    Adresa = "Goce Delceva 3",
                    Grad = "Beograd"
                }
            };

            return studenti;
        }

        public static List<Ispit> GetIspitsTest()
        {
            List<Ispit> ispiti = new List<Ispit>
            {
                new Ispit()
                {
                    BI = 1,
                    PredmetId = 1,
                    Oena = 7
                },
                new Ispit()
                {
                    BI = 1,
                    PredmetId = 2,
                    Oena = 8
                },
                new Ispit()
                {
                    BI = 1,
                    PredmetId = 3,
                    Oena = 6
                },
                new Ispit()
                {
                    BI = 2,
                    PredmetId = 3,
                    Oena = 10
                }
            };
            return ispiti;
        }

        public static List<Predmet> GetPredmets()
        {
            List<Predmet> predmeti = new List<Predmet>
            {
                new Predmet()
                {
                    Naziv = "OIKT"
                },
                new Predmet()
                {
                    Naziv = "AROS"
                },
                new Predmet()
                {
                    Naziv = "P2"
                },
                new Predmet()
                {
                    Naziv = "UIS"
                }
            };
            return predmeti;
        }

        public static IEnumerable<Ispit> GetIspits(Zadatak2Context context)
        {
            List<Ispit> ispiti = new List<Ispit>
            {
                new Ispit()
                {
                    BI = context.Students.Find(1).BI,
                    PredmetId = context.Predmets.Find(1).PredmetId,
                    Oena = 7
                },
                new Ispit()
                {
                    BI = context.Students.Find(2).BI,
                    PredmetId = context.Predmets.Find(2).PredmetId,
                    Oena = 8
                },
                new Ispit()
                {
                    BI = context.Students.Find(3).BI,
                    PredmetId = context.Predmets.Find(1).PredmetId,
                    Oena = 6
                }
            };
            return ispiti;
        }


        public static List<Student> GetStudentsTest()
        {
            List<Student> studenti = new List<Student>
            {
                new Student()
                {
                    BI=1,
                    Ime = "Dragana",
                    Prezime = "Vincic",
                    Adresa = "Antifasisticke borbe 22",
                    Grad = "Beograd"
                },
                new Student()
                {
                    BI=2,
                    Ime = "Mirjana",
                    Prezime = "Vincic",
                    Adresa = "Antifasisticke borbe 22",
                    Grad = "Beograd"
                },
                new Student()
                {
                    BI=3,
                    Ime = "Marko",
                    Prezime = "Peric",
                    Adresa = "Bulevar Yorana Djinjdjica 12",
                    Grad = "Beograd"
                },
                new Student()
                {
                    BI=4,
                    Ime = "Srdjan",
                    Prezime = "ViSimicncic",
                    Adresa = "Goce Delceva 3",
                    Grad = "Beograd"
                }
            };

            return studenti;
        }
    }
}