using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public static class PokemonNameService
    {
        //Map API pokemon names to Correct pokemon names
        private static readonly Dictionary<string, string> CorrectNameMapping = new Dictionary<string, string>()
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

        //Transfor pokemon names into user-readable format
        public static string? GetPokemonName(string? name)
        {
            string? returnName = string.Empty;

            //Name must start with Uppercase
            if (name != null)
            {
                returnName = string.Concat(name[0].ToString().ToUpper(), name.AsSpan(1));
            }

            //Handle special cases
            if (CorrectNameMapping.TryGetValue(returnName, out string? value))
            {
                returnName = value;
            }

            return returnName;
        }
    }
}
