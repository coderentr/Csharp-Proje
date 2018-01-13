namespace PublicUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modellereklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        KullaniciAdi = c.String(nullable: false, maxLength: 128),
                        Sifre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KullaniciAdi);
            
            CreateTable(
                "dbo.Calisans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        DepartmanID = c.Int(nullable: false),
                        YoneticiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departmen", t => t.DepartmanID, cascadeDelete: true)
                .ForeignKey("dbo.Yoneticis", t => t.YoneticiID, cascadeDelete: true)
                .Index(t => t.DepartmanID)
                .Index(t => t.YoneticiID);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Yoneticis",
                c => new
                    {
                        YoneticiID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.YoneticiID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calisans", "YoneticiID", "dbo.Yoneticis");
            DropForeignKey("dbo.Calisans", "DepartmanID", "dbo.Departmen");
            DropIndex("dbo.Calisans", new[] { "YoneticiID" });
            DropIndex("dbo.Calisans", new[] { "DepartmanID" });
            DropTable("dbo.Yoneticis");
            DropTable("dbo.Departmen");
            DropTable("dbo.Calisans");
            DropTable("dbo.Admins");
        }
    }
}
