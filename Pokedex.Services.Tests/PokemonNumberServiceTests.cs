namespace Pokedex.Tests
{
    public class PokemonNumberServiceTests
    {
        [Test]
        public void GetPokemonNumber_ValidUrl_ReturnsCorrectNumber()
        {
            // Arrange
            var url = "https://pokeapi.co/api/v2/pokemon/25/";

            // Act
            var result = PokemonNumberService.GetPokemonNumber(url);

            // Assert
            Assert.That(result, Is.EqualTo(25));
        }

        [Test]
        public void GetPokemonNumber_InvalidUrl_ReturnsDefaultNumber()
        {
            // Arrange
            var url = "https://pokeapi.co/api/v2/pokemon/";

            // Act
            var result = PokemonNumberService.GetPokemonNumber(url);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetPokemonNumber_NullUrl_ReturnsDefaultNumber()
        {
            // Arrange
            string? url = null;

            // Act
            var result = PokemonNumberService.GetPokemonNumber(url);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
