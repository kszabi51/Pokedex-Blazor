namespace Pokedex.Services
{
    public static class PokemonHeightService
    {
        public static string GetPokemonHeight(int height) => MeasurementFormatter.Format(height, "m");
    }
}
