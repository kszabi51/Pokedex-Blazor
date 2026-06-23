namespace Pokedex.Tests
{
    [TestFixture]
    public class PokemonNameServiceTests
    {
        [TestCase("pikachu", ExpectedResult = "Pikachu")]
        [TestCase("bulbasaur", ExpectedResult = "Bulbasaur")]
        [TestCase("CHARIZARD", ExpectedResult = "CHARIZARD")]
        public string? GetPokemonName_CapitalizesFirstLetter(string name)
        {
            return PokemonNameService.GetPokemonName(name);
        }

        // Unicode escapes keep this source file ASCII-safe regardless of editor encoding.
        [TestCase("nidoran-f", ExpectedResult = "Nidoran\u2640")]
        [TestCase("nidoran-m", ExpectedResult = "Nidoran\u2642")]
        [TestCase("mr-mime", ExpectedResult = "Mr. Mime")]
        [TestCase("ho-oh", ExpectedResult = "Ho-Oh")]
        [TestCase("farfetchd", ExpectedResult = "Farfetch'd")]
        [TestCase("type-null", ExpectedResult = "Type: Null")]
        public string? GetPokemonName_AppliesSpecialCaseMapping(string name)
        {
            return PokemonNameService.GetPokemonName(name);
        }

        [Test]
        public void GetPokemonName_NullName_ReturnsNull()
        {
            // Act
            var result = PokemonNameService.GetPokemonName(null);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetPokemonName_EmptyName_ReturnsEmptyWithoutThrowing()
        {
            // Act & Assert - guards the empty-string crash fix
            Assert.That(PokemonNameService.GetPokemonName(string.Empty), Is.EqualTo(string.Empty));
        }
    }
}
