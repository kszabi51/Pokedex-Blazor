namespace Pokedex.Services
{
    public static class PokemonNameService
    {
        //Map API pokemon names to Correct pokemon names
        private static readonly Dictionary<string, string> CorrectNameMapping = new()
        {
            { "Nidoran-f", "Nidoran♀" },
            { "Nidoran-m", "Nidoran♂" },
            { "Mr-mime", "Mr. Mime" },
            { "Ho-oh", "Ho-Oh" },
            { "Mime-jr", "Mime Jr." },
            { "Porygon-z", "Porygon-Z" },
            { "Type-null", "Type: Null" },
            { "Tapu-koko", "Tapu Koko" },
            { "Tapu-lele", "Tapu Lele" },
            { "Tapu-bulu", "Tapu Bulu" },
            { "Tapu-fini", "Tapu Fini" },
            { "Mr-rime", "Mr. Rime" },
            { "Farfetchd", "Farfetch'd" },
            { "Sirfetchd", "Sirfetch'd" },
        };

        //Transform pokemon names into user-readable format
        public static string? GetPokemonName(string? name)
        {
            //Name must not be null or empty to transform
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            //Name must start with Uppercase
            var returnName = string.Concat(char.ToUpperInvariant(name[0]).ToString(), name.AsSpan(1));

            //Handle special cases
            if (CorrectNameMapping.TryGetValue(returnName, out string? value))
            {
                returnName = value;
            }

            return returnName;
        }
    }
}
