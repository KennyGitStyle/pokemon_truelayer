using System.Reflection;
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

        public DbSet<PokemonInfo> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
