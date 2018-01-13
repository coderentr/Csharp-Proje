namespace PublicUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modellereklendii : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Calisans", "DepartmanID", "dbo.Departmen");
            DropForeignKey("dbo.Calisans", "YoneticiID", "dbo.Yoneticis");
            DropIndex("dbo.Calisans", new[] { "DepartmanID" });
            DropIndex("dbo.Calisans", new[] { "YoneticiID" });
            AddColumn("dbo.Calisans", "Yonetici_YoneticiID", c => c.Int());
            AlterColumn("dbo.Calisans", "DepartmanID", c => c.Int());
            AlterColumn("dbo.Calisans", "YoneticiID", c => c.Int());
            CreateIndex("dbo.Calisans", "DepartmanID");
            CreateIndex("dbo.Calisans", "YoneticiID");
            CreateIndex("dbo.Calisans", "Yonetici_YoneticiID");
            AddForeignKey("dbo.Calisans", "DepartmanID", "dbo.Departmen", "ID");
            AddForeignKey("dbo.Calisans", "YoneticiID", "dbo.Yoneticis", "YoneticiID");
            AddForeignKey("dbo.Calisans", "Yonetici_YoneticiID", "dbo.Yoneticis", "YoneticiID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calisans", "Yonetici_YoneticiID", "dbo.Yoneticis");
            DropForeignKey("dbo.Calisans", "YoneticiID", "dbo.Yoneticis");
            DropForeignKey("dbo.Calisans", "DepartmanID", "dbo.Departmen");
            DropIndex("dbo.Calisans", new[] { "Yonetici_YoneticiID" });
            DropIndex("dbo.Calisans", new[] { "YoneticiID" });
            DropIndex("dbo.Calisans", new[] { "DepartmanID" });
            AlterColumn("dbo.Calisans", "YoneticiID", c => c.Int(nullable: false));
            AlterColumn("dbo.Calisans", "DepartmanID", c => c.Int(nullable: false));
            DropColumn("dbo.Calisans", "Yonetici_YoneticiID");
            CreateIndex("dbo.Calisans", "YoneticiID");
            CreateIndex("dbo.Calisans", "DepartmanID");
            AddForeignKey("dbo.Calisans", "YoneticiID", "dbo.Yoneticis", "YoneticiID", cascadeDelete: true);
            AddForeignKey("dbo.Calisans", "DepartmanID", "dbo.Departmen", "ID", cascadeDelete: true);
        }
    }
}
