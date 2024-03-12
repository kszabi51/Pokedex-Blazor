namespace Pokedex.Tests
{
    public class PokemonPictureServiceTests
    {
        [Test]
        public void GetPictureUrl_ValidId_ReturnsCorrectUrl()
        {
            // Arrange
            var pokemonId = "25";

            // Act
            var result = PokemonPictureService.GetPictureUrl(pokemonId);

            // Assert
            Assert.That(result, Is.EqualTo("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/25.png"));
        }

        [Test]
        public void GetPictureUrl_NullId_ReturnsBaseUrl()
        {
            // Arrange
            string? pokemonId = null;

            // Act
            var result = PokemonPictureService.GetPictureUrl(pokemonId);

            // Assert
            Assert.That(result, Is.EqualTo("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/.png"));
        }
    }
}
