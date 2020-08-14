﻿// <auto-generated />
using System;
using MiPrimeraApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MiPrimeraApi.Migrations
{
    [DbContext(typeof(CatalogoDbContext))]
    partial class CatalogoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MiPrimeraApi.Model.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUCreo")
                        .HasColumnType("int");

                    b.Property<int>("IdUModifico")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria","Cat");
                });

            modelBuilder.Entity("MiPrimeraApi.Model.Region", b =>
                {
                    b.Property<int>("IdRegion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUCreo")
                        .HasColumnType("int");

                    b.Property<int>("IdUModifico")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdRegion");

                    b.ToTable("Region","Reg");
                });

            modelBuilder.Entity("MiPrimeraApi.Model.Tipo", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("FechaCreo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUCreo")
                        .HasColumnType("int");

                    b.Property<int>("IdUModifico")
                        .HasColumnType("int");

                    b.HasKey("IdTipo");

                    b.ToTable("Tipo","Tip");
                });
#pragma warning restore 612, 618
        }
    }
}
