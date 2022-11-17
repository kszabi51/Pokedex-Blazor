namespace Pokedex.Services
{
    public static class PokemonWeightService
    {
        public static string? GetPokemonWeight(int weight)
        {
            float weightDouble = (float)weight / 10;
            return string.Concat(weightDouble.ToString()," kg");
        }
    }
}
