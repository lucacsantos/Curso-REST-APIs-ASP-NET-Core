using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventsDbContext : DbContext
    {
        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {
           
        }
        public DbSet<DevEvent> DevEvents { get; set; }
        public DbSet<DevEventSpeak> DevEventSpeakers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvent>(e =>
            {
                e.HasKey(de => de.Id);

                e.Property(de => de.Title).IsRequired(false);

                e.Property(de => de.Description)
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

                e.Property(de => de.StartDate)
                .HasColumnName("StartDate");

                e.Property(de => de.EndDate)
                .HasColumnName("EndDate");

                e.HasMany(de => de.Speakers)
                .WithOne()
                .HasForeignKey(s => s.DevEventId);

            });

            builder.Entity<DevEventSpeak>(e =>
            {
                e.HasKey(de => de.Id);
            });
            
        
        }



    }
}