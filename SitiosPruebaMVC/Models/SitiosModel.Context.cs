﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SitiosPruebaMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SitiosPruebaDatabaseEntities : DbContext
    {
        public SitiosPruebaDatabaseEntities()
            : base("name=SitiosPruebaDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Familiare> Familiares { get; set; }
        public virtual DbSet<Informante> Informantes { get; set; }
        public virtual DbSet<Sitio> Sitios { get; set; }
        public virtual DbSet<Testigo> Testigos { get; set; }
        public virtual DbSet<Victima> Victimas { get; set; }
    }
}
