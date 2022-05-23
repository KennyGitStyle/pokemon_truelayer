using System.ComponentModel.DataAnnotations;

namespace Pokemon.Core
{
    public class PokemonInfo
    {
        
        public string PokemonInfoId { get; set; } = string.Empty!;
        public string Name { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
    }
}
