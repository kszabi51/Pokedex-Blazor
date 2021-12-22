using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
