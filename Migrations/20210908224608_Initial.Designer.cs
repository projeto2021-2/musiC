﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using musiC.Models;

namespace musiC.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20210908224608_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("musiC.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BibliotecaId")
                        .HasColumnType("int");

                    b.Property<int?>("artistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("criadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecaId");

                    b.HasIndex("artistaId");

                    b.ToTable("albuns");
                });

            modelBuilder.Entity("musiC.Models.Amigos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("amigos");
                });

            modelBuilder.Entity("musiC.Models.Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("artistas");
                });

            modelBuilder.Entity("musiC.Models.Biblioteca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("usuarioId");

                    b.ToTable("bibliotecas");
                });

            modelBuilder.Entity("musiC.Models.Integrantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Integrantes");
                });

            modelBuilder.Entity("musiC.Models.Musica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int?>("artistaId")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("artistaId");

                    b.ToTable("musicas");
                });

            modelBuilder.Entity("musiC.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BibliotecaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("criadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecaId");

                    b.HasIndex("usuarioId");

                    b.ToTable("playlists");
                });

            modelBuilder.Entity("musiC.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("amigosId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("amigosId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("musiC.Models.Album", b =>
                {
                    b.HasOne("musiC.Models.Biblioteca", null)
                        .WithMany("albuns")
                        .HasForeignKey("BibliotecaId");

                    b.HasOne("musiC.Models.Artista", "artista")
                        .WithMany("albuns")
                        .HasForeignKey("artistaId");

                    b.Navigation("artista");
                });

            modelBuilder.Entity("musiC.Models.Biblioteca", b =>
                {
                    b.HasOne("musiC.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("musiC.Models.Integrantes", b =>
                {
                    b.HasOne("musiC.Models.Artista", null)
                        .WithMany("integrantes")
                        .HasForeignKey("ArtistaId");
                });

            modelBuilder.Entity("musiC.Models.Musica", b =>
                {
                    b.HasOne("musiC.Models.Album", null)
                        .WithMany("musicas")
                        .HasForeignKey("AlbumId");

                    b.HasOne("musiC.Models.Playlist", null)
                        .WithMany("musicas")
                        .HasForeignKey("PlaylistId");

                    b.HasOne("musiC.Models.Artista", "artista")
                        .WithMany("musicas")
                        .HasForeignKey("artistaId");

                    b.Navigation("artista");
                });

            modelBuilder.Entity("musiC.Models.Playlist", b =>
                {
                    b.HasOne("musiC.Models.Biblioteca", null)
                        .WithMany("playlists")
                        .HasForeignKey("BibliotecaId");

                    b.HasOne("musiC.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("musiC.Models.Usuario", b =>
                {
                    b.HasOne("musiC.Models.Amigos", "amigos")
                        .WithMany("amigos")
                        .HasForeignKey("amigosId");

                    b.Navigation("amigos");
                });

            modelBuilder.Entity("musiC.Models.Album", b =>
                {
                    b.Navigation("musicas");
                });

            modelBuilder.Entity("musiC.Models.Amigos", b =>
                {
                    b.Navigation("amigos");
                });

            modelBuilder.Entity("musiC.Models.Artista", b =>
                {
                    b.Navigation("albuns");

                    b.Navigation("integrantes");

                    b.Navigation("musicas");
                });

            modelBuilder.Entity("musiC.Models.Biblioteca", b =>
                {
                    b.Navigation("albuns");

                    b.Navigation("playlists");
                });

            modelBuilder.Entity("musiC.Models.Playlist", b =>
                {
                    b.Navigation("musicas");
                });
#pragma warning restore 612, 618
        }
    }
}
