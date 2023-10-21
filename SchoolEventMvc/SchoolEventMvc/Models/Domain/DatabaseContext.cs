using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SchoolEventMvc.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options)
        {
        
        }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<EventGenre> EventGenre { get; set; }
        public DbSet<Event> Event { get; set; }

    }
}
