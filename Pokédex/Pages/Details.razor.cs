using Microsoft.AspNetCore.Components;
using MudBlazor;
using Pokedex.Model;
using System.Net.Http.Json;

namespace Pokédex.Pages
{
    public partial class Details
    {
        [Inject]
        public HttpClient? HttpClient { get; set; }

        public PokemonDetails? PokemonDetails { get; set; }

        public List<ChartSeries> Series = new List<ChartSeries>();

        [Parameter]
        public string? PokemonId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (HttpClient != null)
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{PokemonId}";
                PokemonDetails = await HttpClient.GetFromJsonAsync<PokemonDetails>(url);
                if (PokemonDetails?.Statistics != null && PokemonDetails.Statistics.Length>5)
                {
                    Series = new List<ChartSeries>
                    {
                    new ChartSeries(){Name="HP", Data=new double[]{PokemonDetails.Statistics.ElementAt(0), 0, 0, 0, 0, 0 } },
                    new ChartSeries(){Name="Attack", Data=new double[]{0, PokemonDetails.Statistics.ElementAt(1), 0, 0, 0, 0 } },
                    new ChartSeries(){Name="Defense", Data=new double[]{0, 0, PokemonDetails.Statistics.ElementAt(2), 0, 0,0 } },
                    new ChartSeries(){Name="Special Attack", Data=new double[]{0, 0, 0, PokemonDetails.Statistics.ElementAt(3), 0, 0 } },
                    new ChartSeries(){Name="Special Defense", Data=new double[]{0, 0, 0, 0, PokemonDetails.Statistics.ElementAt(4), 0 } },
                    new ChartSeries(){Name="Speed", Data=new double[]{ 0, 0, 0, 0, 0, PokemonDetails.Statistics.ElementAt(5) } },
                    };
                }            
            }
        }
    }
}
