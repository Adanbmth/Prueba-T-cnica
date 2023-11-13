using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Prueba_Inceptio.Models.Data;

namespace Prueba_Inceptio.Context
{
    public partial class tallerContext : DbContext
    {
        public tallerContext(){}
        public tallerContext(DbContextOptions<tallerContext> options): base(options){}
        public DbSet<proveedor> proveedors { get; set; }

        public DbSet<refaccion> refaccions { get; set; }

        public DbSet<vehiculo> vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Username=postgres;Password=password;Host=localhost;Port=5432;Database=Taller;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<proveedor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("proveedor");

                entity.Property(e => e.Id).HasColumnName("proveedor_id");

                entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

                entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");

                entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            });

            modelbuilder.Entity<vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("vehiculo");

                entity.Property(e => e.Id).HasColumnName("moto_id");

                entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");

                entity.Property(e => e.Año)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ahno");

                entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
            });

            modelbuilder.Entity<refaccion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("refaccion");

                entity.Property(e => e.Id).HasColumnName("refaccion_id");

                entity.Property(e => e.Proveedor_id).HasColumnName("proveedor_id");

                entity.Property(e => e.Moto_id).HasColumnName("moto_id");

                entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Precio_unit).HasColumnName("precio_unit");

                entity.HasOne(d => d.proveedor).WithMany(p => p.Refacciones)
                .HasForeignKey(d => d.Proveedor_id)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.vehiculo).WithMany(p => p.Refacciones)
                .HasForeignKey(d => d.Moto_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelbuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelbuilder);
    }
}
