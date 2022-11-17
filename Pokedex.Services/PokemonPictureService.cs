namespace Pokedex.Services
{
    public static class PokemonPictureService
    {
        private static readonly string baseUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/";
        private static readonly string fileExtension = ".png";

        public static string? GetPictureUrl(string? numberString)
        {
            return string.Concat(baseUrl, numberString, fileExtension);
        }
    }
}
