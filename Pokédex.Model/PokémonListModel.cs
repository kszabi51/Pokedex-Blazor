using Pokedex.Services;
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

        //Pokemon Name transformed to be readable on the UI
        public string? RealName => PokemonNameService.GetPokemonName(name);

        //Pokédex number split from the url
        public int Number => PokemonNumberService.GetPokemonNumber(url);

        //Picture from github repo using pokédex number
        public string? Picture => PokemonPictureService.GetPictureUrl(Number.ToString());
    }

    public class PokémonList
    {
        public int count { get; set; }
        public object? next { get; set; }
        public object? previous { get; set; }
        public List<Result>? results { get; set; }
    }
}
