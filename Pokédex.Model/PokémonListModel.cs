using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Model
{
    public class Result
    {
        public string? name { get; set; }
        public string? url { get; set; }
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
