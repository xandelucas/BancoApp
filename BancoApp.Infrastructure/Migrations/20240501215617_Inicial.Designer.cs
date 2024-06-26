﻿// <auto-generated />
using System;
using BancoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BancoApp.Infrastructure.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240501215617_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BancoApp.Domain.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoDoBanco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeDoBanco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PercentualDeJuros")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("BancoApp.Domain.Boleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BancoId")
                        .HasColumnType("integer");

                    b.Property<string>("CPF_CNPJDoBeneficiario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CPF_CNPJDoPagador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataDeVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NomeDoBeneficiario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeDoPagador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("BancoApp.Domain.Boleto", b =>
                {
                    b.HasOne("BancoApp.Domain.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });
#pragma warning restore 612, 618
        }
    }
}
