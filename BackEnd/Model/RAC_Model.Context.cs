﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RentaCarEntities : DbContext
    {
        public RentaCarEntities()
            : base("name=RentaCarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Cliente> Tbl_Cliente { get; set; }
        public virtual DbSet<Tbl_Empleado> Tbl_Empleado { get; set; }
        public virtual DbSet<Tbl_Imagen> Tbl_Imagen { get; set; }
        public virtual DbSet<Tbl_Persona> Tbl_Persona { get; set; }
        public virtual DbSet<Tbl_Reserva> Tbl_Reserva { get; set; }
        public virtual DbSet<Tbl_Usuario> Tbl_Usuario { get; set; }
        public virtual DbSet<Tbl_Vehiculo> Tbl_Vehiculo { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}