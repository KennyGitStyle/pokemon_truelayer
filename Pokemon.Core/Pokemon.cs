namespace Pokemon.Core
{
    /*
        Its good practice to create objects with an ID property for identification purposes. Epecially if you are going to be using a database.
        In this case we will be using a database to store our pokemon, with this we will be storing our connection string in development settings as a form of abstraction. Then we will configure our pipeline to accept both our development and production database.
    */
    public class Pokemon
    {
        public string? PokemonId { get; set; }
        public string Name { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
    }
}
