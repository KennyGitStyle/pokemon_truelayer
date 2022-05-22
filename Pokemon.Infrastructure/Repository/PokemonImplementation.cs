using Pokemon.Core;

namespace Pokemon.Infrastructure.Repository
{
    public class PokemonImplementation : IPokemonContract
    {
        public PokemonImplementation()
        {
        }

        public Task<PokemonInfo> GetAsync(string pokemonId)
        {
            throw new NotImplementedException();
        }
    }
}
