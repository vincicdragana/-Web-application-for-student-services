namespace ZadatakGET.Migrations.Zadatak2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZadatakGET.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<ZadatakGET.Models.Zadatak2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Zadatak2";
        }

        protected override void Seed(ZadatakGET.Models.Zadatak2Context context)
        {
            context.Predmets.AddOrUpdate
                 (
                 p => p.PredmetId, SeedClass.GetPredmets().ToArray()
                 );
            context.SaveChanges();

            context.Students.AddOrUpdate
                (
                p => p.BI, SeedClass.GetStudents().ToArray()
                );
            context.SaveChanges();

            context.Ispits.AddOrUpdate
                (
                p => new { p.BI, p.PredmetId }, SeedClass.GetIspits(context).ToArray()
                );
            context.SaveChanges();
        }
    }
}
