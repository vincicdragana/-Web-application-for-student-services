namespace ZadatakGET.Migrations.Zadatak2
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ispit",
                c => new
                    {
                        BI = c.Int(nullable: false),
                        PredmetId = c.Int(nullable: false),
                        Oena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BI, t.PredmetId })
                .ForeignKey("dbo.Predmet", t => t.PredmetId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.BI, cascadeDelete: true)
                .Index(t => t.BI)
                .Index(t => t.PredmetId);
            
            CreateTable(
                "dbo.Predmet",
                c => new
                    {
                        PredmetId = c.Int(nullable: false, identity: true),
                        Naziv = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.PredmetId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        BI = c.Int(nullable: false, identity: true),
                        Ime = c.String(maxLength: 20),
                        Prezime = c.String(maxLength: 20),
                        Adresa = c.String(maxLength: 30),
                        Grad = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.BI);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ispit", "BI", "dbo.Student");
            DropForeignKey("dbo.Ispit", "PredmetId", "dbo.Predmet");
            DropIndex("dbo.Ispit", new[] { "PredmetId" });
            DropIndex("dbo.Ispit", new[] { "BI" });
            DropTable("dbo.Student");
            DropTable("dbo.Predmet");
            DropTable("dbo.Ispit");
        }
    }
}
