using Microsoft.Extensions.Logging;
using Pokemon.Core;
using Pokemon.Infrastructure.Data.PokemonContext;

namespace Pokemon.Infrastructure.SeedData
{
    public class DataSeed
    {
        public static async Task DbInitializer(PokemonDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(context.Pokemons.Any()) return;

                var pokemon = new PokemonInfo()
                {
                    PokemonInfoId = "ch",
                    Name = "charizard",
                    Description = "Charizard flies 'round the sky in search of powerful opponents. 't breathes fire of such most wonderous heat yond 't melts augh. However, 't nev'r turns its fiery breath on any opponent weaker than itself"
                };
                await context.AddAsync(pokemon);
                await context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataSeed>();
                logger.LogError("DbInitializer error whilst store data...", ex.Message);
            }
        }
    }
}
