﻿using System;
using Hotel.LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.Cabania", b =>
                {
                    b.Property<int>("NumeroHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCabania")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroHabitacion"));

                    b.Property<int>("CantMaxPersonas")
                        .HasColumnType("int")
                        .HasColumnName("CantMaxPersonas")
                        .HasColumnOrder(4);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descripcion")
                        .HasColumnOrder(3);

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(7);

                    b.Property<bool>("HabilitadaReservas")
                        .HasColumnType("bit")
                        .HasColumnName("HabilitadaParaReservas")
                        .HasColumnOrder(5);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(2);

                    b.Property<string>("NombreTipoCabania")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IdTipoCabania")
                        .HasColumnOrder(1);

                    b.Property<bool>("TieneJacuzzi")
                        .HasColumnType("bit")
                        .HasColumnName("TieneJacuzzi")
                        .HasColumnOrder(6);

                    b.HasKey("NumeroHabitacion");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("NombreTipoCabania");

                    b.HasIndex("NumeroHabitacion")
                        .IsUnique();

                    b.ToTable("Cabanias");
                });

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.Configuracion", b =>
                {
                    b.Property<string>("Atributo")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("NombreAtributo")
                        .HasColumnOrder(0);

                    b.Property<int>("LimiteInferior")
                        .HasColumnType("int");

                    b.Property<int>("LimiteSuperior")
                        .HasColumnType("int");

                    b.HasKey("Atributo");

                    b.ToTable("Configuraciones");
                });

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdMantenimiento")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabaniaId")
                        .HasColumnType("int")
                        .HasColumnName("IdCabania")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<string>("NombreFuncionario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NombreDelFunc")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("CabaniaId");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.TipoCabania", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IdTipoCabania")
                        .HasColumnOrder(0);

                    b.HasKey("Nombre");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("TipoDeCabania");
                });

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdUsuario")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Contrasenia")
                        .HasColumnOrder(2);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.Funcionario", b =>
                {
                    b.HasBaseType("Hotel.LogicaNegocio.Entidades.Usuario");

                    b.HasDiscriminator().HasValue("Funcionario");
                });

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.Cabania", b =>
                {
                    b.HasOne("Hotel.LogicaNegocio.Entidades.TipoCabania", "Tipo")
                        .WithMany()
                        .HasForeignKey("NombreTipoCabania")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.Mantenimiento", b =>
                {
                    b.HasOne("Hotel.LogicaNegocio.Entidades.Cabania", "Cabania")
                        .WithMany()
                        .HasForeignKey("CabaniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Hotel.LogicaNegocio.Entidades.CostoMantenimiento", "Costo", b1 =>
                        {
                            b1.Property<int>("MantenimientoId")
                                .HasColumnType("int");

                            b1.Property<double>("Valor")
                                .HasColumnType("float")
                                .HasColumnName("Costo_Valor")
                                .HasColumnOrder(4);

                            b1.HasKey("MantenimientoId");

                            b1.ToTable("Mantenimientos");

                            b1.WithOwner()
                                .HasForeignKey("MantenimientoId");
                        });

                    b.OwnsOne("Hotel.LogicaNegocio.Entidades.DescripcionMantenimiento", "Descripcion", b1 =>
                        {
                            b1.Property<int>("MantenimientoId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Descripcion_Valor")
                                .HasColumnOrder(3);

                            b1.HasKey("MantenimientoId");

                            b1.ToTable("Mantenimientos");

                            b1.WithOwner()
                                .HasForeignKey("MantenimientoId");
                        });

                    b.Navigation("Cabania");

                    b.Navigation("Costo")
                        .IsRequired();

                    b.Navigation("Descripcion")
                        .IsRequired();
                });

            modelBuilder.Entity("Hotel.LogicaNegocio.Entidades.TipoCabania", b =>
                {
                    b.OwnsOne("Hotel.LogicaNegocio.Entidades.CostoTipoCabania", "Costo", b1 =>
                        {
                            b1.Property<string>("TipoCabaniaNombre")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<double>("Valor")
                                .HasColumnType("float")
                                .HasColumnName("Costo_Valor")
                                .HasColumnOrder(2);

                            b1.HasKey("TipoCabaniaNombre");

                            b1.ToTable("TipoDeCabania");

                            b1.WithOwner()
                                .HasForeignKey("TipoCabaniaNombre");
                        });

                    b.OwnsOne("Hotel.LogicaNegocio.Entidades.DescripcionTipoCabania", "Descripcion", b1 =>
                        {
                            b1.Property<string>("TipoCabaniaNombre")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Descripcion_Valor")
                                .HasColumnOrder(1);

                            b1.HasKey("TipoCabaniaNombre");

                            b1.ToTable("TipoDeCabania");

                            b1.WithOwner()
                                .HasForeignKey("TipoCabaniaNombre");
                        });

                    b.Navigation("Costo")
                        .IsRequired();

                    b.Navigation("Descripcion")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
