using Pokedex.Services;

namespace Pokedex.Model
{
    public class Ability2
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Ability
    {
        public Ability2? ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }

    public class Form
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Version
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Species
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Stat2
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public Stat2? stat { get; set; }
    }

    public class Type2
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Type_
    {
        public int slot { get; set; }
        public Type2? type { get; set; }
    }

    public class PokemonDetails
    {
        //API
        public List<Ability>? abilities { get; set; }
        public int base_experience { get; set; }
        public List<Form>? forms { get; set; }
        public int height { get; set; }
        public int id { get; set; }
        public bool is_default { get; set; }
        public string? location_area_encounters { get; set; }
        public string? name { get; set; }
        public int order { get; set; }
        public Species? species { get; set; }
        public List<Stat>? stats { get; set; }
        public List<Type_>? types { get; set; }
        public int weight { get; set; }

        //UI
        public string? RealName => PokemonNameService.GetPokemonName(name);

        public string? RealWeight => PokemonWeightService.GetPokemonWeight(weight);

        public string? RealHeight => PokemonHeightService.GetPokemonHeight(height);

        public string? Picture => PokemonPictureService.GetPictureUrl(id.ToString());

        public List<string> TypeNames
        {
            get
            {
                List<string> typenames = new();
                if (types != null)
                {
                    foreach (var type in types)
                    {
                        if (type?.type?.name != null)
                        {
                            typenames.Add(type.type.name);
                        }
                    }
                }
                return typenames;
            }
        }

        public List<string>? TypeIcons => PokemonTypeIconService.GetIcons(TypeNames);

        public double[]? Statistics => ProvidePokemonStats(stats);

        private double[]? ProvidePokemonStats(List<Stat>? stats)
        {
            double[] statsArray = new double[6];
            if (stats == null) { return statsArray; }

            int index = 0;
            foreach (Stat stat in stats)
            {
                statsArray[index] = stat.base_stat;
                index++;
            }

            return statsArray;
        }

        public string[] StatNames => ProvideStatNames(stats);

        private string[] ProvideStatNames(List<Stat>? stats)
        {
            string[] statNames = new string[6];
            if (stats == null) { return statNames; }

            int index = 0;
            foreach (Stat stat in stats)
            {
                if (stat.stat?.name != null)
                {
                    statNames[index] = stat.stat.name;
                }

                index++;
            }

            return statNames;
        }
    }
}
