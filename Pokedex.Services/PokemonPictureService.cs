namespace Pokedex.Services
{
    public static class PokemonPictureService
    {
        private const string BaseUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/";
        private const string FileExtension = ".png";

        public static string GetPictureUrl(string? pokemonId) => string.Concat(BaseUrl, pokemonId, FileExtension);
    }
}
