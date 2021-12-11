using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Model
{
    public class Result
    {
        //Name from API
        public string? name { get; set; }

        public string? RealName => GetPokemonName();

        //Url from API
        public string? url { get; set; }

        //Pokédex number split from the url
        public int Number
        {
            get
            {
                if (url != null)
                {
                    return int.Parse(url.Split('/').ElementAt(6));
                }

                //To avoid crashes, return first pokemon
                return 1;
            }
        }

        //Picture from github repo using pokédex number
        public string? Picture => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + Number.ToString() + ".png";

        //Transfor pokemon names into user-readable format
        private string? GetPokemonName()
        {
            string? returnName = string.Empty;
            if (name != null)
            {
                returnName = string.Concat(name[0].ToString().ToUpper(), name.AsSpan(1));
            }
            return returnName;
        }
    }

    public class PokémonList
    {
        public int count { get; set; }
        public object? next { get; set; }
        public object? previous { get; set; }
        public List<Result>? results { get; set; }
    }
}
