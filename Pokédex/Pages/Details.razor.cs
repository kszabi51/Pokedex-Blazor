using Microsoft.AspNetCore.Components;
using Pokédex.Model;
using System.Net.Http.Json;

namespace Pokédex.Pages
{
    public partial class Details
    {
        [Inject]
        public HttpClient? HttpClient { get; set; }

        public PokemonDetails? PokemonDetails { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (HttpClient != null)
            {
                PokemonDetails = await HttpClient.GetFromJsonAsync<PokemonDetails>("https://pokeapi.co/api/v2/pokemon/3");
            }
        }

    }
}
