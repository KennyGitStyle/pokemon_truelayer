using Microsoft.EntityFrameworkCore;
using Pokemon.Core;

namespace Pokemon.Infrastructure.Data.PokemonContext
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<PokemonInfo> Pokemon { get; set; }
    }
}
