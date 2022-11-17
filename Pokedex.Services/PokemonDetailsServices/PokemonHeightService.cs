using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public static class PokemonHeightService
    {
        public static string? GetPokemonHeight(int height)
        {
            float heightDouble = (float)height / 10;
            return string.Concat(heightDouble.ToString(), " m");
        }
    }
}
