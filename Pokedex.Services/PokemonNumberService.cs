namespace Pokedex.Services
{
    public static class PokemonNumberService
    {
        private const int DefaultPokemonNumber = 1;
        private const int PokemonNumberPositionInUrl = 6;

        public static int GetPokemonNumber(string? url)
        {
            //Split the number from the url
            if (url != null)
            {
                var urlSegments = url.Split('/');
                if (urlSegments.Length > PokemonNumberPositionInUrl)
                {
                    if (int.TryParse(urlSegments[PokemonNumberPositionInUrl], out int pokemonNumber))
                    {
                        return pokemonNumber;
                    }
                }
            }

            // To avoid crashes, return first pokemon
            return DefaultPokemonNumber;
        }
    }
}
