using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Pokemon.Core;
using Pokemon.Infrastructure.Data.PokemonContext;

namespace Pokemon.Infrastructure.Repository
{
    public class PokemonImplementation : IPokemonContract
    {
        private readonly PokemonDbContext _context;
        private static ConcurrentDictionary<string, PokemonInfo> pokemonCache;

        public PokemonImplementation(PokemonDbContext context)
        {
            _context = context;
            pokemonCache = new(_context.Pokemons.ToDictionary(p => p.PokemonInfoId));

        }

        public async Task<PokemonInfo> GetPokemonAsync(string pokemonId)
        {
            pokemonId = pokemonId.ToLower();
            var getPokemon = await _context.Pokemons.FirstOrDefaultAsync(p => p.PokemonInfoId == pokemonId);
            return getPokemon != null ? UpdateCache(pokemonId, getPokemon) : null;
        }

        private PokemonInfo UpdateCache(string id, PokemonInfo pokemon){
            PokemonInfo oldPokemon;
            if(pokemonCache.TryGetValue(id, out oldPokemon))
            {
                if(pokemonCache.TryUpdate(id, pokemon, oldPokemon))
                    return pokemon;
            }
            return null;
        }
    }
}
