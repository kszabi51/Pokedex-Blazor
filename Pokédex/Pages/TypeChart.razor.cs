using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Pokedex.Services;

namespace Pokédex.Pages
{
    public partial class TypeChart
    {
        [Inject] public IJSRuntime? JS { get; set; }

        public string? SelectedType { get; set; }

        private static readonly Dictionary<string, string> TypeColors = new()
        {
            { "Normal",   "#A8A878" }, { "Fire",     "#F08030" },
            { "Water",    "#6890F0" }, { "Electric", "#F8D030" },
            { "Grass",    "#78C850" }, { "Ice",      "#98D8D8" },
            { "Fighting", "#C03028" }, { "Poison",   "#A040A0" },
            { "Ground",   "#E0C068" }, { "Flying",   "#A890F0" },
            { "Psychic",  "#F85888" }, { "Bug",      "#A8B820" },
            { "Rock",     "#B8A038" }, { "Ghost",    "#705898" },
            { "Dragon",   "#7038F8" }, { "Dark",     "#705848" },
            { "Steel",    "#B8B8D0" }, { "Fairy",    "#EE99AC" }
        };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && JS != null)
            {
                var nodes = TypeEffectivenessService.Types.Select(t => new
                {
                    id = t,
                    label = t,
                    color = TypeColors.TryGetValue(t, out var c) ? c : "#888"
                }).ToArray();

                var edges = new List<object>();
                int edgeId = 0;
                foreach (var atk in TypeEffectivenessService.Types)
                {
                    foreach (var def in TypeEffectivenessService.Types)
                    {
                        var eff = TypeEffectivenessService.GetEffectiveness(atk, def);
                        if (eff == 1.0) continue;

                        edges.Add(new
                        {
                            id = $"e{edgeId++}",
                            source = atk,
                            target = def,
                            edgeColor = eff == 2.0 ? "#4CAF50" : eff == 0.0 ? "#333" : "#F44336",
                            label = eff == 2.0 ? "2×" : eff == 0.0 ? "0" : "½"
                        });
                    }
                }

                await JS.InvokeVoidAsync("typeGraph.init", nodes, edges.ToArray());
            }
        }

        private async Task OnTypeSelected(string type)
        {
            SelectedType = type;
            StateHasChanged();
            await Task.Yield(); // let Blazor render the canvas div first

            var connectedTypeIds = TypeEffectivenessService.Types
                .Where(t => TypeEffectivenessService.GetEffectiveness(type, t) != 1.0
                         || TypeEffectivenessService.GetEffectiveness(t, type) != 1.0)
                .ToHashSet();

            connectedTypeIds.Add(type);

            var nodes = connectedTypeIds.Select(t => new
            {
                id = t,
                label = t,
                color = TypeColors.TryGetValue(t, out var c) ? c : "#888",
                isCenter = t == type
            }).ToArray();

            var edges = new List<object>();
            int edgeId = 0;

            // Outgoing: selected type attacks others
            foreach (var def in TypeEffectivenessService.Types)
            {
                var eff = TypeEffectivenessService.GetEffectiveness(type, def);
                if (eff == 1.0 || def == type) continue;

                edges.Add(new
                {
                    id = $"e{edgeId++}",
                    source = type,
                    target = def,
                    edgeColor = eff == 2.0 ? "#4CAF50" : eff == 0.0 ? "#333" : "#F44336",
                    label = eff == 2.0 ? "2×" : eff == 0.0 ? "0" : "½"
                });
            }

            // Incoming: other types attacking the selected type
            foreach (var atk in TypeEffectivenessService.Types)
            {
                var eff = TypeEffectivenessService.GetEffectiveness(atk, type);
                if (eff == 1.0 || atk == type) continue;

                edges.Add(new
                {
                    id = $"e{edgeId++}",
                    source = atk,
                    target = type,
                    edgeColor = eff == 2.0 ? "#4CAF50" : eff == 0.0 ? "#333" : "#F44336",
                    label = eff == 2.0 ? "2×" : eff == 0.0 ? "0" : "½"
                });
            }

            if (JS != null)
                await JS.InvokeVoidAsync("typeGraph.init", nodes, edges.ToArray());
        }
    }
}