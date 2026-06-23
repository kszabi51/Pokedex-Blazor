namespace Pokedex.Services
{
    public static class PokemonWeightService
    {
        public static string GetPokemonWeight(int weight) => MeasurementFormatter.Format(weight, "kg");
    }
}
