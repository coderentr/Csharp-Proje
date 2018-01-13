namespace PublicUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class midra1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Calisans", "DepartmanID", "dbo.Departmen");
            AddColumn("dbo.Calisans", "Departman_ID", c => c.Int());
            CreateIndex("dbo.Calisans", "Departman_ID");
            AddForeignKey("dbo.Calisans", "Departman_ID", "dbo.Departmen", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calisans", "Departman_ID", "dbo.Departmen");
            DropIndex("dbo.Calisans", new[] { "Departman_ID" });
            DropColumn("dbo.Calisans", "Departman_ID");
            AddForeignKey("dbo.Calisans", "DepartmanID", "dbo.Departmen", "ID");
        }
    }
}
