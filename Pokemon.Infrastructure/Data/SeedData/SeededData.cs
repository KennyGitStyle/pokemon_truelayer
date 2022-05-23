using Pokemon.Core;
using Pokemon.Infrastructure.Data.PokemonContext;

namespace Pokemon.Infrastructure.Data.SeedData
{
    public class SeededData
    {
        public static async Task InitializeDb(PokemonDbContext context)
        {
            if (context.Pokemons.Any()) return;

            var pokemonInfo = new PokemonInfo()
            {
                PokemonInfoId = "ch",
                Name = "charizard",
                Description = "Charizard flies 'round the sky in search of powerful opponents. \'t breathes fire of such most wonderous heat yond \'t melts augh. However, \'t nev\'r turns its fiery breath on any opponent weaker than itself"
            };
            await context.Pokemons.AddAsync(pokemonInfo);
            await context.SaveChangesAsync();
        }
    }
}
