using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CansInnov.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CansInnov.Persistence.Configurations
{
    public static class ParticipantAtelierConfiguration
    {
        public static void ConfigureParticipantAtelier(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantAtelier>()
                .ToTable("T_PARTICIPANT_ATELIER")
                .HasKey(x => x.Id);

            modelBuilder.Entity<ParticipantAtelier>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<ParticipantAtelier>()
                .Property(x => x.AtelierId)
                .HasColumnName("ID_ATELIER");

            modelBuilder.Entity<ParticipantAtelier>()
                .Property(x => x.Matricule)
                .HasColumnName("MATRICULE")
                .HasColumnType("CHAR")
                .HasMaxLength(7);

        }
    }
}