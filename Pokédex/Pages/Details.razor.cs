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

        private static readonly string[] StatLabels = ["HP", "Attack", "Defense", "Sp. Atk", "Sp. Def", "Speed"];
        private static readonly string[] StatColors =
        [
            "#FF5959", // HP - red
            "#F5AC78", // Attack - orange
            "#FAE078", // Defense - yellow
            "#9DB7F5", // Sp. Atk - blue
            "#A7DB8D", // Sp. Def - green
            "#B57BFF"  // Speed - purple
        ];

        private bool _chartPending = false;

        [Parameter] public string? PokemonId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (HttpClient != null)
            {
                PokemonDetails = await HttpClient.GetFromJsonAsync<PokemonDetails>(
                    $"https://pokeapi.co/api/v2/pokemon/{PokemonId}");
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
