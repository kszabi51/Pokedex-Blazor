using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Pokedex.Model;
using System.Net.Http.Json;

namespace Pokédex.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient? HttpClient { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public ILogger<Index>? Logger { get; set; }

        public PokémonList? PokemonList { get; set; }

        public string? SearchString { get; set; }

        public bool LoadFailed { get; private set; }

        protected async override Task OnInitializedAsync()
        {
            if (HttpClient == null)
            {
                return;
            }

            try
            {
                PokemonList = await HttpClient.GetFromJsonAsync<PokémonList>("https://pokeapi.co/api/v2/pokemon?limit=1025");
            }
            catch (Exception ex)
            {
                LoadFailed = true;
                Logger?.LogError(ex, "Failed to load Pokémon list from the API.");
            }
        }

        /// <summary>
        /// Navigates to the details page of the selected Pokemon
        /// </summary>
        /// <param name="pokemonId">The id of the selected Pokemon</param>
        public void PokemonSelected(int pokemonId = 1) => NavigationManager?.NavigateTo($"Details/{pokemonId}");
    }
}
