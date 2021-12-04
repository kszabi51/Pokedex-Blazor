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


        protected async override Task OnInitializedAsync()
        {
            if (HttpClient != null)
            {
            PokemonList = await HttpClient.GetFromJsonAsync<PokémonList>("https://pokeapi.co/api/v2/pokemon?limit=1200");

            }
        }
    }
}
