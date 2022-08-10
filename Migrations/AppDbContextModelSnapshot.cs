﻿// <auto-generated />
using System;
using CrudSimplesApiFiis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudSimplesApiFiis.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("CategoriaFundoImobiliario", b =>
                {
                    b.Property<int>("CategoriasId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FundosImobiliariosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoriasId", "FundosImobiliariosId");

                    b.HasIndex("FundosImobiliariosId");

                    b.ToTable("CategoriaFundoImobiliario", (string)null);
                });

            modelBuilder.Entity("CrudSimplesApiFiis.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CrudSimplesApiFiis.Models.FundoImobiliario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Administradora")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ativo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("VARCHAR(1)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)");

                    b.Property<int>("CotasEmitidas")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataIpo")
                        .IsRequired()
                        .HasColumnType("DATE");

                    b.Property<string>("NomeFundo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Papel")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<decimal?>("PatrimonioLiquido")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<string>("PublicoAlvo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal?>("TaxaAdministracao")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<decimal>("ValorPatrimonial")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("Id");

                    b.ToTable("FundosImobiliarios");
                });

            modelBuilder.Entity("CategoriaFundoImobiliario", b =>
                {
                    b.HasOne("CrudSimplesApiFiis.Models.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrudSimplesApiFiis.Models.FundoImobiliario", null)
                        .WithMany()
                        .HasForeignKey("FundosImobiliariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
