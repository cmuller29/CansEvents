﻿// <auto-generated />
using System;
using CansInnov.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CansInnov.Persistence.Migrations
{
    [DbContext(typeof(CansEventsDbContext))]
    [Migration("20231116134725_AddParticipant2")]
    partial class AddParticipant2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CansInnov.Persistence.Models.Atelier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_ATELIER");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_DEBUT_ATELIER");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_FIN_ATELIER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("DESCRIPTION_ATELIER");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_EVENEMENT");

                    b.Property<string>("LienReunion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LIEN_REUNION");

                    b.Property<string>("Lieu")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("LIEU_ATELIER");

                    b.Property<int>("NbParticipantMax")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("NOMBRE_PARTICIPANT_MAX");

                    b.Property<string>("NomIntervenant")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("NOM_INTERVENANT");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TITRE_ATELIER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TYPE_ATELIER");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("T_ATELIER", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("054144c8-5744-4441-a685-6e19313b996e"),
                            DateDebut = new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DateFin = new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "DEscription",
                            EventId = new Guid("6d8faf40-3165-4a50-ba4a-fa0fb50312eb"),
                            LienReunion = "lien",
                            Lieu = "lieu",
                            NbParticipantMax = 10,
                            NomIntervenant = "Intervenant",
                            Titre = "Titre",
                            Type = "Presentiel"
                        });
                });

            modelBuilder.Entity("CansInnov.Persistence.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_EVENEMENT");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_DEBUT_EVENEMENT");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_FIN_EVENEMENT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("DEscription de base")
                        .HasColumnName("DESCRIPTION_EVENEMENT");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Visuel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("VISUEL_EVENEMENT");

                    b.HasKey("Id");

                    b.ToTable("T_EVENEMENT", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6d8faf40-3165-4a50-ba4a-fa0fb50312eb"),
                            DateDebut = new DateTime(2023, 9, 16, 14, 47, 25, 261, DateTimeKind.Local).AddTicks(2891),
                            DateFin = new DateTime(2023, 10, 16, 14, 47, 25, 261, DateTimeKind.Local).AddTicks(2938),
                            Description = "DEscription",
                            Titre = "Titre"
                        });
                });

            modelBuilder.Entity("CansInnov.Persistence.Models.ParticipantAtelier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("AtelierId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_ATELIER");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("CHAR(7)")
                        .HasColumnName("MATRICULE");

                    b.HasKey("Id");

                    b.HasIndex("AtelierId");

                    b.ToTable("T_PARTICIPANT_ATELIER", (string)null);
                });

            modelBuilder.Entity("CansInnov.Persistence.Models.Atelier", b =>
                {
                    b.HasOne("CansInnov.Persistence.Models.Event", "Event")
                        .WithMany("Ateliers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CUSTOM_ATELIER_EVENT");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("CansInnov.Persistence.Models.ParticipantAtelier", b =>
                {
                    b.HasOne("CansInnov.Persistence.Models.Atelier", "Atelier")
                        .WithMany("Participants")
                        .HasForeignKey("AtelierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atelier");
                });

            modelBuilder.Entity("CansInnov.Persistence.Models.Atelier", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("CansInnov.Persistence.Models.Event", b =>
                {
                    b.Navigation("Ateliers");
                });
#pragma warning restore 612, 618
        }
    }
}