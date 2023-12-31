﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Prueba_Inceptio.Context;

#nullable disable

namespace Prueba_Inceptio.Migrations
{
    [DbContext(typeof(tallerContext))]
    partial class tallerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Prueba_Inceptio.Models.Data.proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("proveedor_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("proveedor", (string)null);
                });

            modelBuilder.Entity("Prueba_Inceptio.Models.Data.refaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("refaccion_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cantidad")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("cantidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Precio_unit")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("precio_unit");

                    b.Property<int>("Proveedor_id")
                        .HasColumnType("integer")
                        .HasColumnName("proveedor_id");

                    b.Property<int>("Vehiculo_id")
                        .HasColumnType("integer")
                        .HasColumnName("moto_id");

                    b.HasKey("Id");

                    b.HasIndex("Proveedor_id");

                    b.HasIndex("Vehiculo_id");

                    b.ToTable("refaccion", (string)null);
                });

            modelBuilder.Entity("Prueba_Inceptio.Models.Data.vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("moto_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Año")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("ahno");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("modelo");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.ToTable("vehiculo", (string)null);
                });

            modelBuilder.Entity("Prueba_Inceptio.Models.Data.refaccion", b =>
                {
                    b.HasOne("Prueba_Inceptio.Models.Data.proveedor", "proveedor")
                        .WithMany("Refacciones")
                        .HasForeignKey("Proveedor_id")
                        .IsRequired();

                    b.HasOne("Prueba_Inceptio.Models.Data.vehiculo", "vehiculo")
                        .WithMany("Refacciones")
                        .HasForeignKey("Vehiculo_id")
                        .IsRequired();

                    b.Navigation("proveedor");

                    b.Navigation("vehiculo");
                });

            modelBuilder.Entity("Prueba_Inceptio.Models.Data.proveedor", b =>
                {
                    b.Navigation("Refacciones");
                });

            modelBuilder.Entity("Prueba_Inceptio.Models.Data.vehiculo", b =>
                {
                    b.Navigation("Refacciones");
                });
#pragma warning restore 612, 618
        }
    }
}
