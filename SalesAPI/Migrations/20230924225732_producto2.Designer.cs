﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesAPI.Data;

#nullable disable

namespace SalesAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230924225732_producto2")]
    partial class producto2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalesShared.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("NombreCategoria")
                        .IsUnique();

                    b.ToTable("CategoriasProductos");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.ClasificacionProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("NombreClasificacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("NombreClasificacion")
                        .IsUnique();

                    b.HasIndex("ProductoId");

                    b.ToTable("ClasificacionProductos");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("ClasificacionProductoId")
                        .HasColumnType("int");

                    b.Property<int>("ClaveProducto")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Precio")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Stock")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ClasificacionProductoId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.ProductoImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("ImgProductos");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.ClasificacionProducto", b =>
                {
                    b.HasOne("SalesShared.Entities.Productos.Categoria", "Categoria")
                        .WithMany("ClasificacionProductos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesShared.Entities.Productos.Producto", null)
                        .WithMany("ProductosClasificacion")
                        .HasForeignKey("ProductoId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.Producto", b =>
                {
                    b.HasOne("SalesShared.Entities.Productos.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesShared.Entities.Productos.ClasificacionProducto", "ClasificacionProducto")
                        .WithMany("Productos")
                        .HasForeignKey("ClasificacionProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("ClasificacionProducto");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.ProductoImg", b =>
                {
                    b.HasOne("SalesShared.Entities.Productos.Producto", "Producto")
                        .WithMany("ProductoImagenes")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.Categoria", b =>
                {
                    b.Navigation("ClasificacionProductos");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.ClasificacionProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("SalesShared.Entities.Productos.Producto", b =>
                {
                    b.Navigation("ProductoImagenes");

                    b.Navigation("ProductosClasificacion");
                });
#pragma warning restore 612, 618
        }
    }
}
