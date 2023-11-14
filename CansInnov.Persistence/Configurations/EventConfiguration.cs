using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CansInnov.Persistence.Configurations
{
    public static class EventConfiguration
    {
        public static void ConfigureEvent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .ToTable("T_EVENEMENT");

            modelBuilder.Entity<Event>()
              .HasKey(x => x.Id);

            modelBuilder.Entity<Event>()
              .Property(x => x.Id)
              .HasColumnName("ID_EVENEMENT");

            modelBuilder.Entity<Event>()
              .Property(x => x.Titre)
              .HasMaxLength(50);

            modelBuilder.Entity<Event>()
              .Property(x => x.Description)
              .HasColumnName("DESCRIPTION_EVENEMENT")
              .HasMaxLength(500)
              .HasDefaultValue("DEscription de base");

            modelBuilder.Entity<Event>()
              .Property(x => x.Visuel)
              .HasColumnName("VISUEL_EVENEMENT")
              .IsRequired(false)
              .HasMaxLength(200);

            modelBuilder.Entity<Event>()
              .Property(x => x.DateDebut)
              .HasColumnName("DATE_DEBUT_EVENEMENT");

            modelBuilder.Entity<Event>()
              .Property(x => x.DateFin)
              .HasColumnName("DATE_FIN_EVENEMENT");
        }
    }
}