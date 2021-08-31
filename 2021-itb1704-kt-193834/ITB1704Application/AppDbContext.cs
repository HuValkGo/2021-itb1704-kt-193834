using ITB1704Application.Model;
using Microsoft.EntityFrameworkCore;

namespace ITB1704Application
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteStop> RouteStops { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}