using Microsoft.EntityFrameworkCore;

namespace Mission06_Tew.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base (options) 
        {
        }

        public DbSet<Application> Applications { get; set; }
    }
}
