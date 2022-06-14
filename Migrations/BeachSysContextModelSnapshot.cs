﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace beach_sys.Migrations
{
    [DbContext(typeof(BeachSysContext))]
    partial class BeachSysContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("beach_sys.Models.Armario", b =>
                {
                    b.Property<int>("ArmarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ArmarioId");

                    b.ToTable("Armario");
                });

            modelBuilder.Entity("beach_sys.Models.Compartimento", b =>
                {
                    b.Property<int>("CompartimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Aberto")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ArmarioId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CompartimentoId");

                    b.HasIndex("ArmarioId");

                    b.ToTable("Compartimento");
                });

            modelBuilder.Entity("beach_sys.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CompartimentoId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CompartimentoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("beach_sys.Models.Compartimento", b =>
                {
                    b.HasOne("beach_sys.Models.Armario", "Armario")
                        .WithMany("Compartimentos")
                        .HasForeignKey("ArmarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("beach_sys.Models.Usuario", b =>
                {
                    b.HasOne("beach_sys.Models.Compartimento", "Compartimento")
                        .WithMany()
                        .HasForeignKey("CompartimentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
