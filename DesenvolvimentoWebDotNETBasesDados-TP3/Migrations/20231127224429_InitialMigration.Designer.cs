﻿// <auto-generated />
using System;
using DesenvolvimentoWebDotNETBasesDados_TP3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesenvolvimentoWebDotNETBasesDados_TP3.Migrations
{
    [DbContext(typeof(AventureiroContext))]
    [Migration("20231127224429_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DesenvolvimentoWebDotNETBasesDados_TP3.Models.Aventureiro", b =>
                {
                    b.Property<int>("AventureiroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AventureiroID"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AventureiroID");

                    b.ToTable("Aventureiro", (string)null);
                });

            modelBuilder.Entity("DesenvolvimentoWebDotNETBasesDados_TP3.Models.Especialidade", b =>
                {
                    b.Property<int>("EspecialidadeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialidadeID"), 1L, 1);

                    b.Property<string>("AreaConhecimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EspecialidadeID");

                    b.ToTable("Especialidade", (string)null);
                });

            modelBuilder.Entity("DesenvolvimentoWebDotNETBasesDados_TP3.Models.Investidura", b =>
                {
                    b.Property<int>("InvestiduraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvestiduraID"), 1L, 1);

                    b.Property<int>("AventureiroID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInvestidura")
                        .HasColumnType("datetime2");

                    b.Property<int>("EspecialidadeID")
                        .HasColumnType("int");

                    b.HasKey("InvestiduraID");

                    b.HasIndex("AventureiroID");

                    b.HasIndex("EspecialidadeID");

                    b.ToTable("Investidura", (string)null);
                });

            modelBuilder.Entity("DesenvolvimentoWebDotNETBasesDados_TP3.Models.Investidura", b =>
                {
                    b.HasOne("DesenvolvimentoWebDotNETBasesDados_TP3.Models.Aventureiro", "Aventureiro")
                        .WithMany("Investiduras")
                        .HasForeignKey("AventureiroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesenvolvimentoWebDotNETBasesDados_TP3.Models.Especialidade", "Especialidade")
                        .WithMany("Investiduras")
                        .HasForeignKey("EspecialidadeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aventureiro");

                    b.Navigation("Especialidade");
                });

            modelBuilder.Entity("DesenvolvimentoWebDotNETBasesDados_TP3.Models.Aventureiro", b =>
                {
                    b.Navigation("Investiduras");
                });

            modelBuilder.Entity("DesenvolvimentoWebDotNETBasesDados_TP3.Models.Especialidade", b =>
                {
                    b.Navigation("Investiduras");
                });
#pragma warning restore 612, 618
        }
    }
}
