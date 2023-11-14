using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CansInnov.Persistence.Configurations
{
    public static class AtelierConfiguration
    {
        public static void ConfigureAtelier(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atelier>()
                .ToTable("T_ATELIER")
                .HasKey("Id");

            modelBuilder.Entity<Atelier>()
              .HasOne(x => x.Event)
              .WithMany(x => x.Ateliers)
              .HasForeignKey(x => x.EventId)
              .HasPrincipalKey(x => x.Id)
              .HasConstraintName("FK_CUSTOM_ATELIER_EVENT");

            modelBuilder.Entity<Atelier>()
              .Property(x => x.Id)
              .HasColumnName("ID_ATELIER");

            modelBuilder.Entity<Atelier>()
              .Property(x => x.EventId)
              .HasColumnName("ID_EVENEMENT");

            modelBuilder.Entity<Atelier>()
              .Property(x => x.Titre)
              .HasColumnName("TITRE_ATELIER")
              .HasMaxLength(50);

            modelBuilder.Entity<Atelier>()
              .Property(x => x.Description)
              .HasColumnName("DESCRIPTION_ATELIER")
              .HasMaxLength(500);

            modelBuilder.Entity<Atelier>()
              .Property(x => x.Type)
              .HasColumnName("TYPE_ATELIER")
              .HasMaxLength(50)
              .HasConversion<EnumToStringConverter<TypeAtelier>>();

            modelBuilder.Entity<Atelier>()
              .Property(x => x.NomIntervenant)
              .HasColumnName("NOM_INTERVENANT")
              .HasMaxLength(250);

            modelBuilder.Entity<Atelier>()
              .Property(x => x.Lieu)
              .HasColumnName("LIEU_ATELIER")
              .HasMaxLength(250)
              .IsRequired(false);

            modelBuilder.Entity<Atelier>()
              .Property(x => x.LienReunion)
              .HasColumnName("LIEN_REUNION")
              .IsRequired(false);

            modelBuilder.Entity<Atelier>()
              .Property(x => x.NbParticipantMax)
              .HasColumnName("NOMBRE_PARTICIPANT_MAX")
              .HasDefaultValue(0);

            modelBuilder.Entity<Atelier>()
              .Property(x => x.DateDebut)
              .HasColumnName("DATE_DEBUT_ATELIER");

            modelBuilder.Entity<Atelier>()
              .Property(x => x.DateFin)
              .HasColumnName("DATE_FIN_ATELIER");
        }
    }
}