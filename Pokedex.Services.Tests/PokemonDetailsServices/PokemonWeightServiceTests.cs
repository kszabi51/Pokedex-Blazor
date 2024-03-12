namespace Pokedex.Tests
{
    [TestFixture]
    public class PokemonWeightServiceTests
    {
        [TestCase(10, ExpectedResult = "1 kg")]
        [TestCase(20, ExpectedResult = "2 kg")]
        [TestCase(0, ExpectedResult = "0 kg")]
        public string? GetPokemonWeight_ReturnsCorrectWeight(int weight)
        {
            return PokemonWeightService.GetPokemonWeight(weight);
        }
    }
}
