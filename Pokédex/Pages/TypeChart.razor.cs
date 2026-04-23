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

        private async Task OnTypeSelected(string type)
        {
            SelectedType = type;
            StateHasChanged();
            await Task.Yield();

            if (JS == null) return;

            var centerNode = new[]
            {
                new { id = type, label = type, color = TypeColors.GetValueOrDefault(type, "#888"), isCenter = true }
            };

            // --- Attack graph (selected type → others) ---
            var attackEdges = new List<object>();
            var attackNodeIds = new HashSet<string> { type };
            int edgeId = 0;

            foreach (var def in TypeEffectivenessService.Types)
            {
                var eff = TypeEffectivenessService.GetEffectiveness(type, def);
                if (eff == 1.0 || def == type) continue;
                attackNodeIds.Add(def);
                attackEdges.Add(new
                {
                    id = $"a{edgeId++}",
                    source = type,
                    target = def,
                    edgeColor = eff == 2.0 ? "#4CAF50" : eff == 0.0 ? "#333" : "#F44336",
                    label = eff == 2.0 ? "2×" : eff == 0.0 ? "0" : "½"
                });
            }

            var attackNodes = attackNodeIds.Select(t => new
            {
                id = t,
                label = t,
                color = TypeColors.GetValueOrDefault(t, "#888"),
                isCenter = t == type
            }).ToArray();

            await JS.InvokeVoidAsync("typeGraph.init", "typeGraphAttack", attackNodes, attackEdges.ToArray());

            // --- Defense graph (others → selected type) ---
            var defenseEdges = new List<object>();
            var defenseNodeIds = new HashSet<string> { type };
            edgeId = 0;

            foreach (var atk in TypeEffectivenessService.Types)
            {
                var eff = TypeEffectivenessService.GetEffectiveness(atk, type);
                if (eff == 1.0 || atk == type) continue;
                defenseNodeIds.Add(atk);
                defenseEdges.Add(new
                {
                    id = $"d{edgeId++}",
                    source = atk,
                    target = type,
                    edgeColor = eff == 2.0 ? "#4CAF50" : eff == 0.0 ? "#333" : "#F44336",
                    label = eff == 2.0 ? "2×" : eff == 0.0 ? "0" : "½"
                });
            }

            var defenseNodes = defenseNodeIds.Select(t => new
            {
                id = t,
                label = t,
                color = TypeColors.GetValueOrDefault(t, "#888"),
                isCenter = t == type
            }).ToArray();

            await JS.InvokeVoidAsync("typeGraph.init", "typeGraphDefense", defenseNodes, defenseEdges.ToArray());
        }
    }
}