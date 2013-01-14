using System.Data.Entity;

namespace SportSecond.Models
{
    public class SportContext : DbContext
    {
        public SportContext()
            : base("Sport")
        {
        }

        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Sportsman> Sportsmans { get; set; }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}