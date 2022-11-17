namespace Pokedex.Services
{
    public static class PokemonNumberService
    {
        public static int GetPokemonNumber(string? url)
        {
            //Split the number from the url
            if (url != null)
            {
                return int.Parse(url.Split('/').ElementAt(6));
            }

            //To avoid crashes, return first pokemon
            return 1;
        }
    }
}
