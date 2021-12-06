using Microsoft.AspNetCore.Components;
using Pokédex.Model;
using System.Net.Http.Json;

namespace Pokédex.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient? HttpClient { get; set; }

        public PokémonList? PokemonList { get; set; }

        public List<PokemonListDataModel>? PokemonListDataModel { get; set; }


        protected async override Task OnInitializedAsync()
        {
            //PokemonListDataModel = new List<PokemonListDataModel>();

            if (HttpClient != null)
            {
                PokemonList = await HttpClient.GetFromJsonAsync<PokémonList>("https://pokeapi.co/api/v2/pokemon?limit=1200");
                //if (PokemonList?.results != null)
                //{
                //    foreach (var pokemon in PokemonList.results)
                //    {
                //        if(pokemon?.url != null)
                //        {
                //            PokemonDetails? pokemonDetails = await HttpClient.GetFromJsonAsync<PokemonDetails>(pokemon.url);
                //            int numberFromUrl = int.Parse(pokemon.url.Split('/').ElementAt(6));
                //            PokemonListDataModel.Add(new PokemonListDataModel
                //            {
                //                name = pokemon.name,
                //                url = pokemon.url,
                //                number = numberFromUrl,
                //                types = pokemonDetails?.types,
                //                picture = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/" + numberFromUrl.ToString() +".png",
                //            });
                //        }
                //    }
                //}               
            }
        }
    }
}
