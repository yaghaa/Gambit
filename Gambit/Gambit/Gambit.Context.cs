﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gambit
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GambitEntities : DbContext
    {
        public GambitEntities()
            : base("name=GambitEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Info> Info { get; set; }
        public virtual DbSet<Kontakt> Kontakt { get; set; }
        public virtual DbSet<Notatka> Notatka { get; set; }
        public virtual DbSet<Telefon> Telefon { get; set; }
        public virtual DbSet<Wydarzenie> Wydarzenie { get; set; }
    }
}