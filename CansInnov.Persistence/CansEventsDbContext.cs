using CansInnov.Application.Contracts;
using CansInnov.Domain.Common;
using CansInnov.Domain.Entities;
using CansInnov.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CansInnov.Persistence
{
    public class CansEventsDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public CansEventsDbContext(DbContextOptions<CansEventsDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<Atelier> Atelier { get; set; } = default!;

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

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
                    Visuel = "https://cdn-icons-png.flaticon.com/512/25/25231.png",
                    DateDebut = new DateTime(2023, 11, 20, 9, 00, 00),
                    DateFin = new DateTime(2023, 11, 24, 18, 00, 00),
                    CreatedBy = "cmuller",
                    CreatedDate = DateTime.Now
                });

            modelBuilder.Entity<Atelier>()
                .HasData(new Atelier
                {
                    Id = Guid.NewGuid(),
                    EventId = eventId,
                    Titre = "Atelier 1",
                    Description = "DEscription",
                    DateDebut = new DateTime(2023, 11, 20, 9, 00, 00),
                    DateFin = new DateTime(2023, 11, 20, 12, 0, 0),
                    Lieu = "lieu",
                    NbParticipantMax = 10,
                    NomIntervenant = "Intervenant",
                    Type = TypeAtelier.Presentiel,
                    CreatedBy = "cmuller",
                    CreatedDate = DateTime.Now
                });
            modelBuilder.Entity<Atelier>()
                .HasData(new Atelier
                {
                    Id = Guid.NewGuid(),
                    EventId = eventId,
                    Titre = "Atelier 2",
                    Description = "DEscription",
                    DateDebut = new DateTime(2023, 11, 20, 14, 00, 00),
                    DateFin = new DateTime(2023, 11, 20, 18, 0, 0),
                    Lieu = "lieu",
                    NbParticipantMax = 10,
                    NomIntervenant = "Intervenant",
                    Type = TypeAtelier.Presentiel,
                    CreatedBy = "cmuller",
                    CreatedDate = DateTime.Now
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}