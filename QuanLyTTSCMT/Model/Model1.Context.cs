﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTTSCMT.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_QuanLyTTSCMTEntities : DbContext
    {
        public DB_QuanLyTTSCMTEntities()
            : base("name=DB_QuanLyTTSCMTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LapTop> LapTops { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
    }
}
