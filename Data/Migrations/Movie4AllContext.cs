using Microsoft.EntityFrameworkCore;
using Movie4All.Data;

namespace Movie4All.Data
{
    public class Movie4AllContext : DbContext
    {
        public Movie4AllContext(DbContextOptions<Movie4AllContext> options) : base(options)
        {
        }

        public DbSet<Movie4All.Data.Movie> Movies { get; set; }
    }
}
