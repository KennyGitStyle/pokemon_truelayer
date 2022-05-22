using Microsoft.EntityFrameworkCore;
using Pokemon.Core;

namespace Pokemon.Infrastructure.PokemonContext
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PokemonInfo> Pokemon { get; set; }        
    }
}