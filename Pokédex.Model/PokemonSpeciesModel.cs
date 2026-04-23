namespace Pokedex.Model
{
    public class FlavorTextEntry
    {
        public string? flavor_text { get; set; }
        public Language? language { get; set; }
        public Version? version { get; set; }
    }

    public class Language
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class PokemonSpecies
    {
        public List<FlavorTextEntry>? flavor_text_entries { get; set; }

        public string? EnglishEntry =>
            flavor_text_entries?
                .FirstOrDefault(f => f.language?.name == "en")
                ?.flavor_text
                ?.Replace("\n", " ")
                .Replace("\f", " ");
    }
}