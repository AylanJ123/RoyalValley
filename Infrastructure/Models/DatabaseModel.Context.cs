﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cobro> Cobro { get; set; }
        public DbSet<Edificio> Edificio { get; set; }
        public DbSet<Incidencia> Incidencia { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<PlanCobro> PlanCobro { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Rubro> Rubro { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
