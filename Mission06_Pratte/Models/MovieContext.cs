using Microsoft.EntityFrameworkCore;

namespace Mission06_Pratte.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            // leave blank for now
        }

        public DbSet<Movie> Movies { get; set; } // Movies is the name of the table in the database, and Movie is the name of the model class that represents the data in that table.
    }
}
