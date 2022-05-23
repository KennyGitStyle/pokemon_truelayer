using Microsoft.AspNetCore.Mvc;
using Pokemon.Core;
using Pokemon.Infrastructure.Repository;

namespace Pokemon.API.Controllers
{
    public class PokemonController : DefaultController
    {
        private readonly IPokemonContract _pokemonRepo;

        public PokemonController(IPokemonContract pokemonRepo)
        {
            _pokemonRepo = pokemonRepo;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PokemonInfo))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPokemonById(string id){
            var getPokemon = await _pokemonRepo.GetPokemonAsync(id);
            if(getPokemon.PokemonInfoId != id){
                return NotFound("Hmm... Sorry the pokemon you are looking for does not exist!");
            }
            return Ok(getPokemon);
        }
    }
}