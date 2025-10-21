using NUnit.Framework;
using pokemon_1;
using Pokemon_1;
using System.Collections.Generic;
using static pokemon_1.Pokemon;

namespace Pokemon_1
{
    [TestFixture]
    public class DamageFormulaTests
    {
        [TestCase(1, 1, 1, 1, 0, 0)]
        [TestCase(1, 1, 1, 1, 1, 1)]
        [TestCase(5, 50, 100, 50, 1, 2)]
        [TestCase(10, 20, 30, 15, 1, 8)]
        [TestCase(12, 40, 60, 80, 2, 18)]
        [TestCase(25, 80, 120, 60, 1, 40)]
        [TestCase(30, 100, 150, 100, 2, 55)]
        [TestCase(40, 150, 200, 150, 1, 37)]
        [TestCase(50, 128, 200, 100, 4, 455)]
        [TestCase(60, 200, 250, 200, 1, 52)]
        [TestCase(70, 180, 250, 100, 2, 436)]
        [TestCase(80, 90, 45, 90, 1, 17)]
        [TestCase(90, 255, 200, 50, 2, 1554)]
        [TestCase(99, 255, 255, 1, 2, 108206)]
        [TestCase(99, 255, 255, 255, 4, 856)]
        [TestCase(99, 255, 255, 255, 0, 0)]
        [TestCase(99, 255, 1, 1, 1, 2)]
        [TestCase(99, 255, 1, 1, 1, 2)]
        [TestCase(45, 60, 10, 200, 1, 2)]
        [TestCase(20, 30, 5, 250, 1, 1)]
        [TestCase(2, 10, 1, 255, 1, 1)]
        [TestCase(3, 5, 2, 3, 1, 1)]
        [TestCase(15, 200, 255, 255, 1, 33)]
        [TestCase(16, 200, 255, 254, 1, 34)]
        [TestCase(17, 200, 255, 128, 1, 36)]
        [TestCase(33, 77, 77, 77, 1, 25)]
        [TestCase(48, 33, 99, 31, 4, 508)]
        [TestCase(55, 44, 88, 22, 1, 44)]
        [TestCase(77, 123, 200, 100, 2, 326)]
        [TestCase(88, 200, 100, 50, 4, 1197)]
        [TestCase(10, 200, 200, 200, 0, 0)]
        [TestCase(50, 255, 100, 255, 0, 0)]
        [TestCase(75, 180, 255, 180, 0, 0)]
        [TestCase(99, 255, 255, 1, 0, 0)]
        [TestCase(25, 60, 40, 20, 1, 4)]
        [TestCase(60, 100, 255, 128, 1, 40)]
        [TestCase(80, 90, 45, 90, 1, 17)]
        [TestCase(99, 200, 150, 150, 1, 84)]
        public void TestDamageFormula(int level, int movePower, int atk, int def, double mod, int expectedDmg)
        {
            
            var attacker = new Pokemon("Attacker", level, atk, def, 128, 128, PokemonType.Bug);
            var defender = new Pokemon("Defender", level, atk, def, 128, 128, PokemonType.Bug);
            var move = new Move("TestMove", movePower, PokemonType.Bug, MoveType.Physical);
           
            int dmg = DamageCalculator.CalculateDamage(attacker, defender, move, mod);
           
            Assert.That(dmg, Is.EqualTo(expectedDmg));
        }
    }

    [TestFixture]
    public class ModifierTests
    {
        [Test]
        public void Charmander_UsesEmber_On_Bulbasaur_ShouldBeSuperEffective()
        {
            // Arrange
            var charmander = PokemonFactory.CreateCharmander();
            var bulbasaur = PokemonFactory.CreateBulbasaur();
            var ember = charmander.Moves.First(m => m.Name == "Ember");

            // Act
            float modifier = DamageCalculator.GetModifier(ember.Type, bulbasaur.Types);

            // Assert
            Assert.That(modifier, Is.EqualTo(2f),
                "Fire debe ser súper efectivo contra Grass (2x)");
        }

        [Test]
        public void Squirtle_UsesWaterGun_On_Charmander_ShouldBeSuperEffective()
        {
            var squirtle = PokemonFactory.CreateSquirtle();
            var charmander = PokemonFactory.CreateCharmander();
            var waterGun = squirtle.Moves.First(m => m.Name == "Water Gun");

            float modifier = DamageCalculator.GetModifier(waterGun.Type, charmander.Types);

            Assert.That(modifier, Is.EqualTo(2f),
                "Water debe ser súper efectivo contra Fire (2x)");
        }

        [Test]
        public void Bulbasaur_UsesVineWhip_On_Onix_ShouldBeFourTimesEffective()
        {
            var bulbasaur = PokemonFactory.CreateBulbasaur();
            var onix = PokemonFactory.CreateOnix();
            var vineWhip = bulbasaur.Moves.First(m => m.Name == "Vine Whip");

            float modifier = DamageCalculator.GetModifier(vineWhip.Type, onix.Types);

            Assert.That(modifier, Is.EqualTo(4f),
                "Grass debe ser 4x efectivo contra Rock/Ground");
        }

        [Test]
        public void Pikachu_UsesThunderbolt_On_Squirtle_ShouldBeSuperEffective()
        {
            var pikachu = PokemonFactory.CreatePikachu();
            var squirtle = PokemonFactory.CreateSquirtle();
            var thunderbolt = pikachu.Moves.First(m => m.Name == "Thunderbolt");

            float modifier = DamageCalculator.GetModifier(thunderbolt.Type, squirtle.Types);

            Assert.That(modifier, Is.EqualTo(2f),
                "Electric debe ser súper efectivo contra Water (2x)");
        }

        [Test]
        public void Pikachu_UsesThunderbolt_On_Onix_ShouldHaveNoEffect()
        {
            var pikachu = PokemonFactory.CreatePikachu();
            var onix = PokemonFactory.CreateOnix();
            var thunderbolt = pikachu.Moves.First(m => m.Name == "Thunderbolt");

            float modifier = DamageCalculator.GetModifier(thunderbolt.Type, onix.Types);

            Assert.That(modifier, Is.EqualTo(0f),
                "Electric no debe afectar a Ground (0x)");
        }
    }

}
