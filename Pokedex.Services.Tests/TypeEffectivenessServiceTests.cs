namespace Pokedex.Tests
{
    [TestFixture]
    public class TypeEffectivenessServiceTests
    {
        [Test]
        public void Types_ContainsAllEighteenTypes()
        {
            // Assert
            Assert.That(TypeEffectivenessService.Types, Has.Length.EqualTo(18));
        }

        [TestCase("Fire", "Grass", ExpectedResult = 2.0)]   // super effective
        [TestCase("Water", "Fire", ExpectedResult = 2.0)]   // super effective
        [TestCase("Fire", "Water", ExpectedResult = 0.5)]   // not very effective
        [TestCase("Electric", "Ground", ExpectedResult = 0.0)] // no effect
        [TestCase("Normal", "Ghost", ExpectedResult = 0.0)] // no effect
        public double GetEffectiveness_KnownMatchups_ReturnsExpectedMultiplier(string attacking, string defending)
        {
            return TypeEffectivenessService.GetEffectiveness(attacking, defending);
        }

        [Test]
        public void GetEffectiveness_NeutralMatchup_ReturnsOne()
        {
            // Normal attacking Normal is not in the chart, so it defaults to 1.0
            Assert.That(TypeEffectivenessService.GetEffectiveness("Normal", "Normal"), Is.EqualTo(1.0));
        }

        [Test]
        public void GetEffectiveness_UnknownType_ReturnsOne()
        {
            Assert.That(TypeEffectivenessService.GetEffectiveness("Unknown", "Fire"), Is.EqualTo(1.0));
        }
    }
}
