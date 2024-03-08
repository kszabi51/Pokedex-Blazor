using Microsoft.AspNetCore.Components;
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

        public PokémonList? PokemonList { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (HttpClient != null)
            {
                PokemonList = await HttpClient.GetFromJsonAsync<PokémonList>("https://pokeapi.co/api/v2/pokemon?limit=1025");
            }
        }

        /// <summary>
        /// Navigates to the details page of the selected Pokemon
        /// </summary>
        /// <param name="pokemonId">The id of the selected Pokemon</param>
        public void PokemonSelected(int pokemonId = 1) => NavigationManager?.NavigateTo($"Details/{pokemonId}");
    }
}
