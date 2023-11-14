using System.Reflection.Emit;
using CansInnov.Persistence.Configurations;
using CansInnov.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CansInnov.Persistence
{
    public class CansEventsDbContext : DbContext
    {
        public CansEventsDbContext(DbContextOptions<CansEventsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Atelier> Atelier { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureEvent();
            modelBuilder.ConfigureAtelier();
            
            Guid eventId = Guid.NewGuid();
            modelBuilder.Entity<Event>()
                .HasData(new Event
                {
                    Id = eventId,
                    Titre = "Titre",
                    Description = "DEscription",
                    DateDebut = DateTime.Now.AddMonths(-2),
                    DateFin = DateTime.Now.AddMonths(-1)
                });

            modelBuilder.Entity<Atelier>()
                .HasData(new Atelier
                {
                    Id = Guid.NewGuid(),
                    EventId = eventId,
                    Titre = "Titre",
                    Description = "DEscription",
                    DateDebut = new DateTime(2023, 10, 15, 9, 0, 0),
                    DateFin = new DateTime(2023, 10, 15, 18, 0, 0),
                    LienReunion = "lien",
                    Lieu = "lieu",
                    NbParticipantMax = 10,
                    NomIntervenant = "Intervenant",
                    Type = TypeAtelier.Presentiel
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}