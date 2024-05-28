namespace Pokedex.Services
{
    public static class PokemonTypeIconService
    {
        public static List<string>? GetIcons(List<string> typeNames)
        {
            List<string>? iconpaths = new List<string>();

            foreach (var type in typeNames)
            {
                switch (type)
                {
                    case "normal":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/9/95/Normal_icon_SwSh.png");
                        break;
                    case "fire":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/a/ab/Fire_icon_SwSh.png");
                        break;
                    case "water":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/8/80/Water_icon_SwSh.png");
                        break;
                    case "electric":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/7/7b/Electric_icon_SwSh.png");
                        break;
                    case "grass":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/a/a8/Grass_icon_SwSh.png");
                        break;
                    case "ice":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/1/15/Ice_icon_SwSh.png");
                        break;
                    case "fighting":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/3/3b/Fighting_icon_SwSh.png");
                        break;
                    case "poison":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/8/8d/Poison_icon_SwSh.png");
                        break;
                    case "ground":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/2/27/Ground_icon_SwSh.png");
                        break;
                    case "flying":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/b/b5/Flying_icon_SwSh.png");
                        break;
                    case "psychic":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/7/73/Psychic_icon_SwSh.png");
                        break;
                    case "bug":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/9/9c/Bug_icon_SwSh.png");
                        break;
                    case "rock":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/1/11/Rock_icon_SwSh.png");
                        break;
                    case "ghost":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/0/01/Ghost_icon_SwSh.png");
                        break;
                    case "dragon":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/7/70/Dragon_icon_SwSh.png");
                        break;
                    case "dark":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/d/d5/Dark_icon_SwSh.png");
                        break;
                    case "steel":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/0/09/Steel_icon_SwSh.png");
                        break;
                    case "fairy":
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/c/c6/Fairy_icon_SwSh.png");
                        break;
                    default:
                        iconpaths.Add("https://archives.bulbagarden.net/media/upload/d/df/UnknownIC_Stad2.png");
                        break;
                }
            }

            return iconpaths;
        }
    }
}
