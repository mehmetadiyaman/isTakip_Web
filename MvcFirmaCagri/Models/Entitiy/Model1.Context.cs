﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcFirmaCagri.Models.Entitiy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbisTAKİPEntities : DbContext
    {
        public DbisTAKİPEntities()
            : base("name=DbisTAKİPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCagrilar> tblCagrilar { get; set; }
        public virtual DbSet<tblDepartmanlar> tblDepartmanlar { get; set; }
        public virtual DbSet<tblFirmalar> tblFirmalar { get; set; }
        public virtual DbSet<tblGorevDetaylar> tblGorevDetaylar { get; set; }
        public virtual DbSet<tblGorevler> tblGorevler { get; set; }
        public virtual DbSet<tblPersonel> tblPersonel { get; set; }
        public virtual DbSet<tblCagriDetay> tblCagriDetay { get; set; }
        public virtual DbSet<tblMesajlar> tblMesajlar { get; set; }
    }
}
