using Pokemon.Core;

namespace Pokemon.Infrastructure.Repository
{
    public interface IPokemonContract
    {
        Task<PokemonInfo> GetPokemonAsync(string pokemonId);
    }
}
