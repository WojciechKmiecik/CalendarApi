using CalendarApi.Dal.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CalendarApi.Dal
{
    internal class CalendarContext : DbContext
    {
        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options)
        { }
        private static bool created = false;
        public CalendarContext()
        {
            if (!created)
            {
                Database.EnsureCreated();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventsEntity>().ToTable("Events");
            modelBuilder.Entity<EventMembersEntity>().ToTable("EventMemebers");
            modelBuilder.Entity<LocationsEntity>().ToTable("Locations");
            modelBuilder.Entity<PeopleEntity>().ToTable("People");

            modelBuilder.Entity<EventMembersEntity>().HasKey(em => new { em.EventId, em.PeopleId });
            modelBuilder.Entity<EventMembersEntity>().HasOne(em => em.Event).WithMany(e => e.EventsMembers)
                                                    .HasForeignKey(em => em.EventId);
            modelBuilder.Entity<EventMembersEntity>().HasOne(em => em.People).WithMany(p => p.EventMembers)
                                                    .HasForeignKey(em => em.PeopleId);

            modelBuilder.Entity<EventsEntity>().Property(p => p.CreatedDateTime).HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<EventsEntity>().HasOne(x => x.Location).WithMany(x => x.Events);

            modelBuilder.Entity<EventsEntity>().HasOne(x => x.Organizer).WithMany(x => x.Events);


            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=CalendarApi;Trusted_Connection=True;ConnectRetryCount=0");
        }

        public DbSet<EventsEntity> Events { get; set; }
        public DbSet<EventMembersEntity> EventMembers { get; set; }
        public DbSet<LocationsEntity> Locations { get; set; }
        public DbSet<PeopleEntity> Peoples { get; set; }

    }
}
