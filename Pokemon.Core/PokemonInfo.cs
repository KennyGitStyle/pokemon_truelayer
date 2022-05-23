using System.ComponentModel.DataAnnotations;

namespace Pokemon.Core
{
    public class PokemonInfo
    {
        [Required]
        public string PokemonInfoId { get; set; } = string.Empty!;
        [Display(Name = "Pokemon Name")]
        public string Name { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
    }
}
