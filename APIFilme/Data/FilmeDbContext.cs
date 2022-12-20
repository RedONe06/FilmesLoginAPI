using API_Filme.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Filme.Data
{
    public class FilmeDbContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        public FilmeDbContext(DbContextOptions<FilmeDbContext> opt) : base(opt) 
        {

        }
    }
}
