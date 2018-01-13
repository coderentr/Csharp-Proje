namespace PublicUI.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PublicUI.DBContext.RehberDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PublicUI.DBContext.RehberDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Admin.AddOrUpdate(
                a => a.KullaniciAdi, new Admin { KullaniciAdi = "Admin",Sifre="Admin" }
                );



        }
    }
}
