﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using imobiliariaCivitas_api.Data;

#nullable disable

namespace imobiliariaCivitas_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240825181655_TabelaUsuarioAcesso2")]
    partial class TabelaUsuarioAcesso2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("imobiliariaCivitas_shared.Model.tb_acesso", b =>
                {
                    b.Property<int>("cd_acesso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cd_acesso"));

                    b.Property<string>("tipo_acesso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("cd_acesso");

                    b.ToTable("tb_acesso");
                });

            modelBuilder.Entity("imobiliariaCivitas_shared.Model.tb_imagem", b =>
                {
                    b.Property<int>("cd_imagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cd_imagem"));

                    b.Property<int>("cd_imovel")
                        .HasColumnType("integer");

                    b.Property<string>("imageBase64")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("imageBase64");

                    b.HasKey("cd_imagem");

                    b.HasIndex("cd_imovel");

                    b.ToTable("tb_imagem", (string)null);
                });

            modelBuilder.Entity("imobiliariaCivitas_shared.Model.tb_imovel", b =>
                {
                    b.Property<int>("cd_imovel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cd_imovel"));

                    b.Property<DateTime>("criadoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("descricao");

                    b.HasKey("cd_imovel");

                    b.ToTable("tb_imovel", (string)null);
                });

            modelBuilder.Entity("imobiliariaCivitas_shared.Model.tb_usuario", b =>
                {
                    b.Property<int>("cd_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cd_usuario"));

                    b.Property<int>("cd_acesso")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("email");

                    b.Property<string>("nome_usuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("nome_usuario");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("password");

                    b.HasKey("cd_usuario");

                    b.HasIndex("cd_acesso");

                    b.ToTable("tb_usuario", (string)null);
                });

            modelBuilder.Entity("imobiliariaCivitas_shared.Model.tb_imagem", b =>
                {
                    b.HasOne("imobiliariaCivitas_shared.Model.tb_imovel", "imovel")
                        .WithMany("imagens")
                        .HasForeignKey("cd_imovel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("imovel");
                });

            modelBuilder.Entity("imobiliariaCivitas_shared.Model.tb_usuario", b =>
                {
                    b.HasOne("imobiliariaCivitas_shared.Model.tb_acesso", "acesso")
                        .WithMany("usuarios")
                        .HasForeignKey("cd_acesso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("acesso");
                });

            modelBuilder.Entity("imobiliariaCivitas_shared.Model.tb_acesso", b =>
                {
                    b.Navigation("usuarios");
                });

            modelBuilder.Entity("imobiliariaCivitas_shared.Model.tb_imovel", b =>
                {
                    b.Navigation("imagens");
                });
#pragma warning restore 612, 618
        }
    }
}
