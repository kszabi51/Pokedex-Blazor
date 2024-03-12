using Pokedex.Services;

namespace Pokedex.Tests
{
    [TestFixture]
    public class PokemonHeightServiceTests
    {
        [TestCase(10, ExpectedResult = "1 m")]
        [TestCase(20, ExpectedResult = "2 m")]
        [TestCase(0, ExpectedResult = "0 m")]
        public string? GetPokemonHeight_ReturnsCorrectHeight(int height)
        {
            return PokemonHeightService.GetPokemonHeight(height);
        }
    }
}
