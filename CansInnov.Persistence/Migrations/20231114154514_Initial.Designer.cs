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
    [Migration("20231114154514_Initial")]
    partial class Initial
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
                            Id = new Guid("74f05612-024b-4bb9-88b0-fd8a67dddd74"),
                            DateDebut = new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            DateFin = new DateTime(2023, 10, 15, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "DEscription",
                            EventId = new Guid("8c76e726-dbe9-412e-930c-9d8bc0231b42"),
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
                            Id = new Guid("8c76e726-dbe9-412e-930c-9d8bc0231b42"),
                            DateDebut = new DateTime(2023, 9, 14, 16, 45, 14, 689, DateTimeKind.Local).AddTicks(9696),
                            DateFin = new DateTime(2023, 10, 14, 16, 45, 14, 689, DateTimeKind.Local).AddTicks(9741),
                            Description = "DEscription",
                            Titre = "Titre"
                        });
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

            modelBuilder.Entity("CansInnov.Persistence.Models.Event", b =>
                {
                    b.Navigation("Ateliers");
                });
#pragma warning restore 612, 618
        }
    }
}
