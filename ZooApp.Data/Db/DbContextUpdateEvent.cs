using Microsoft.EntityFrameworkCore;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Db
{
    public class DbContextUpdateEvent : DbContext
    {
        public DbContextUpdateEvent(DbContextOptions<DbContextUpdateEvent> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("event_id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.StartDateTime)
                    .HasColumnName("start_time")
                    .IsRequired();

                entity.Property(e => e.EndDateTime)
                    .HasColumnName("end_time")
                    .IsRequired();

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.MaxParticipants)
                    .HasColumnName("max_participants")
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at");

                entity.Ignore(e => e.CurrentParticipants);
            });
        }
    }
}