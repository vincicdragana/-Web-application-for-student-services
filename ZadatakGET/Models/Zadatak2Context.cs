using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ZadatakGET.Models
{
    public class Zadatak2Context : DbContext
    {
        public Zadatak2Context()
            : base("Zadatak2Context")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<Ispit> Ispits { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}