using Microsoft.EntityFrameworkCore;
using VolleyballStatistics.Domain.Entities;

namespace VolleyballStatistics.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipation> EventsParticipations { get; set; }
        public DbSet<PlayerStatistics> PlayerStatistics { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Set> Sets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
