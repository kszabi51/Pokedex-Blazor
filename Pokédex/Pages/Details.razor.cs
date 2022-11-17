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

        [Parameter]
        public string? PokemonId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (HttpClient != null)
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{PokemonId}";
                PokemonDetails = await HttpClient.GetFromJsonAsync<PokemonDetails>(url);
            }
        }

    }
}
