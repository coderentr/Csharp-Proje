﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kütüphane.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KutuphaneEntities : DbContext
    {
        public KutuphaneEntities()
            : base("name=KutuphaneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Islem> Islem { get; set; }
        public DbSet<Kitap> Kitap { get; set; }
        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<Yazar> Yazar { get; set; }
    }
}
