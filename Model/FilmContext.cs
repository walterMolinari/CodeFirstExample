
using Microsoft.EntityFrameworkCore;

namespace FilmsMinimalAPI.Model
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {

        }
        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().ToTable("Film");
        }
       
    }
}
