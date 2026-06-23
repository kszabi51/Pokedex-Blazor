namespace Pokedex.Tests
{
    [TestFixture]
    public class PokemonTypeIconServiceTests
    {
        [Test]
        public void GetIcons_BuildsLowercaseInvariantPaths()
        {
            // Arrange
            var types = new List<string> { "Fire", "WATER", "Grass" };

            // Act
            var result = PokemonTypeIconService.GetIcons(types);

            // Assert
            Assert.That(result, Is.EqualTo(new[]
            {
                "images/types/fire.png",
                "images/types/water.png",
                "images/types/grass.png"
            }));
        }

        [Test]
        public void GetIcons_EmptyInput_ReturnsEmptyList()
        {
            // Act
            var result = PokemonTypeIconService.GetIcons(new List<string>());

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetIcons_NullInput_ReturnsEmptyListWithoutThrowing()
        {
            // Act & Assert - guards the null-guard fix
            Assert.That(PokemonTypeIconService.GetIcons(null), Is.Empty);
        }
    }
}
