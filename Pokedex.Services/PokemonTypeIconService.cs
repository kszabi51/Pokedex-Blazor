namespace Pokedex.Services
{
    public static class PokemonTypeIconService
    {
        public static List<string> GetIcons(IEnumerable<string>? typeNames)
        {
            if (typeNames is null)
            {
                return new List<string>();
            }

            return typeNames
                .Select(t => $"images/types/{t.ToLowerInvariant()}.png")
                .ToList();
        }
    }
}
