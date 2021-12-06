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

        //Url from API
        public string? url { get; set; }

        //Pokédex number split from the url
        public int Number => int.Parse(url.Split('/').ElementAt(6));

        //Picture from guthub repo using pokédex number
        public string? Picture => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + Number.ToString() + ".png";

    }

    public class PokémonList
    {
        public int count { get; set; }
        public object? next { get; set; }
        public object? previous { get; set; }
        public List<Result>? results { get; set; }
    }

    public class PokemonListDataModel
    {
        public string? name { get; set; }
        public string? url { get; set; }
        public int number { get; set; }
        public List<Type>? types { get; set; }
        public string? picture { get; set; }
    }
}
