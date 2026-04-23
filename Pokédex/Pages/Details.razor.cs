using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Pokedex.Model;
using System.Net.Http.Json;

namespace Pokédex.Pages
{
    public partial class Details
    {
        [Inject] public HttpClient? HttpClient { get; set; }
        [Inject] public IJSRuntime? JS { get; set; }

        public PokemonDetails? PokemonDetails { get; set; }
        public PokemonSpecies? PokemonSpecies { get; set; }

        private static readonly string[] StatLabels = ["HP", "Attack", "Defense", "Sp. Atk", "Sp. Def", "Speed"];
        private static readonly string[] StatColors =
        [
            "#FF5959", "#F5AC78", "#FAE078", "#9DB7F5", "#A7DB8D", "#B57BFF"
        ];

        private bool _chartPending = false;

        [Parameter] public string? PokemonId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (HttpClient != null)
            {
                PokemonDetails = await HttpClient.GetFromJsonAsync<PokemonDetails>(
                    $"https://pokeapi.co/api/v2/pokemon/{PokemonId}");

                if (PokemonDetails != null)
                {
                    PokemonSpecies = await HttpClient.GetFromJsonAsync<PokemonSpecies>(
                        $"https://pokeapi.co/api/v2/pokemon-species/{PokemonDetails.id}");
                }

                _chartPending = true;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (_chartPending && PokemonDetails?.Statistics != null && JS != null)
            {
                _chartPending = false;
                await JS.InvokeVoidAsync("pokemonChart.render",
                    StatLabels,
                    PokemonDetails.Statistics.Take(6).ToArray(),
                    StatColors);
            }
        }
    }
}
