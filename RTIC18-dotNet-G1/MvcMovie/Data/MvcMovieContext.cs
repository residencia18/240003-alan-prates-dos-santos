using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }
        
        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        
    }
}