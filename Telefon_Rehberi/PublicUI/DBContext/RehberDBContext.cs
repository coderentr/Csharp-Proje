using PublicUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PublicUI.DBContext
{
    public class RehberDBContext : DbContext
    {
        public RehberDBContext() : base("RehberConnection2") { }
        public DbSet<Calisan> Calisan { get; set; }
        public DbSet<Yonetici> Yonetici { get; set; }
        public DbSet<Departman> Departman { get; set; }
        public DbSet<Admin> Admin { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calisan>()
                .HasOptional<Yonetici>(s => s.Yonetici)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Calisan>()
                .HasOptional<Departman>(s => s.Departman)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}