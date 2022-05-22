using Pokemon.Core;

namespace Pokemon.Infrastructure.Repository
{
    public interface IPokemonContract
    {
        Task<PokemonInfo> GetAsync(string pokemonId);
    }
}
