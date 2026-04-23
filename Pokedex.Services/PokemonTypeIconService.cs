namespace Pokedex.Services
{
    public static class PokemonTypeIconService
    {
        public static List<string> GetIcons(List<string> typeNames)
        {
            return typeNames
                .Select(t => $"images/types/{t.ToLower()}.png")
                .ToList();
        }
    }
}
