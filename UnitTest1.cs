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
        [TestCase(5, 50, 100, 50, 2, 16)]
        [TestCase(5, 50, 100, 50, 1, 5)]
        [TestCase(10, 20, 30, 15, 1, 5)]
        [TestCase(12, 40, 60, 80, 2, 9)]
        [TestCase(25, 80, 120, 60, 1, 40)]
        [TestCase(30, 100, 50, 100, 4, 58)]
        [TestCase(40, 150, 200, 150, 1, 37)]
        [TestCase(50, 128, 200, 100, 1, 58)]
        [TestCase(50, 128, 200, 100, 4, 455)]
        [TestCase(60, 2000, 250, 200, 1, 132)]
        [TestCase(70, 180, 200, 100, 2, 435)]
        [TestCase(80, 90, 45, 90, 1, 33)]
        [TestCase(90, 255, 200, 50, 2, 1554)]
        [TestCase(99, 255, 255, 1, 2, 108206)]
        [TestCase(99, 255, 255, 255, 4, 856)]
        [TestCase(99, 255, 255, 255, 0, 0)]
        [TestCase(99, 255, 1, 255, 1, 2)]
        [TestCase(45, 60, 10, 200, 1, 2)]
        [TestCase(20, 30, 5, 250, 1, 1)]
        [TestCase(2, 10, 1, 255, 1, 1)]
        [TestCase(3, 5, 2, 3, 1, 1)]
        [TestCase(15, 200, 255, 255, 1, 33)]
        [TestCase(16, 200, 255, 254, 1, 34)]
        [TestCase(17, 200, 255, 128, 1, 36)]
        [TestCase(33, 77, 77, 77, 1, 25)]
        [TestCase(48, 33, 99, 11, 4, 508)]
        [TestCase(55, 44, 88, 22, 1, 44)]
        [TestCase(66, 11, 11, 11, 1, 8)]
        [TestCase(77, 123, 200, 100, 2, 326)]
        [TestCase(88, 200, 100, 50, 4, 1197)]
        [TestCase(10, 200, 200, 200, 0, 0)]
        [TestCase(50, 255, 100, 255, 0, 0)]
        [TestCase(75, 180, 255, 180, 0, 0)]
        [TestCase(99, 255, 255, 1, 0, 0)]
        [TestCase(25, 60, 40, 20, 0, 0)]
        [TestCase(60, 100, 255, 128, 1, 40)]
        [TestCase(80, 90, 45, 90, 1, 17)]
        [TestCase(99, 200, 150, 150, 1, 84)]

        public void TestDamageFormula(int level, int movePower, int atk, int def, double mod, int expectedDmg)
        {
            
            var attacker = new Pokemon("Attacker", level, atk, def, 128, 128, PokemonType.Bug);
            var defender = new Pokemon("Defender", level, atk, def, 128, 128, PokemonType.Bug);
            var move = new Move("TestMove", PokemonType.Bug, MoveType.Physical, movePower);
           
            int dmg = DamageCalculator.CalculateDamage(attacker, defender, move, mod);
           
            Assert.That(dmg, Is.EqualTo(expectedDmg));
        }
    }

    [TestFixture]
    public class BasicCreationTests
    {
        [Test]
        public void TestDefaultMovePower()
        {
            Move move1 = new Move("Water Gun", PokemonType.Water, MoveType.Special);

            Assert.That(move1.BasePower, Is.EqualTo(100),
                "El poder base por defecto de un movimiento debería ser 100.");
        }

        [Test]
        public void TestCharmanderCreation()
        {
            // Arrange
            Charmander charmander = new Charmander();

            // Assert
            Assert.That(charmander.Name, Is.EqualTo("Charmander"));
            Assert.That(charmander.Level, Is.EqualTo(1));
            Assert.That(charmander.Attack, Is.EqualTo(50));
            Assert.That(charmander.Defense, Is.EqualTo(53));
            Assert.That(charmander.SpAttack, Is.EqualTo(70));
            Assert.That(charmander.SpDefense, Is.EqualTo(65));
            Assert.That(charmander.Types.Contains(PokemonType.Fire), "Charmander debería ser de tipo Fire.");
        }

        [Test]
        public void TestPikachuCreation()
        {
            var pikachu = new Pikachu();

            Assert.That(pikachu.Name, Is.EqualTo("Pikachu"));
            Assert.That(pikachu.Types.Contains(PokemonType.Electric), "Pikachu deberia ser de tipo Electric.");
            Assert.That(pikachu.Level, Is.EqualTo(1));
            Assert.That(pikachu.Attack, Is.EqualTo(49));
            Assert.That(pikachu.Defense, Is.EqualTo(49));
            Assert.That(pikachu.SpAttack, Is.EqualTo(65));
            Assert.That(pikachu.SpDefense, Is.EqualTo(65));
            Assert.That(pikachu.Moves, Is.Not.Null);
        }

        [Test]
        public void TestSalCreation()
        {
            var sal = new Sal();

            Assert.That(sal.Name, Is.EqualTo("Sal"));
            Assert.That(sal.Types.Contains(PokemonType.Ghost), "Sal deberia ser de tipo Ghost.");
            Assert.That(sal.Level, Is.EqualTo(1));
            Assert.That(sal.Attack, Is.EqualTo(50));
            Assert.That(sal.Defense, Is.EqualTo(50));
            Assert.That(sal.SpAttack, Is.EqualTo(70));
            Assert.That(sal.SpDefense, Is.EqualTo(65));
            Assert.That(sal.Moves, Is.Not.Null);
        }

        [Test]
        public void TestOnixCreation()
        {
            var onix = new Onix();

            Assert.That(onix.Name, Is.EqualTo("Onix"));
            Assert.That(onix.Types.Contains(PokemonType.Electric), "Onix deberia ser tipo Electric.");
            Assert.That(onix.Level, Is.EqualTo(1));
            Assert.That(onix.Attack, Is.EqualTo(40));
            Assert.That(onix.Defense, Is.EqualTo(50));
            Assert.That(onix.SpAttack, Is.EqualTo(65));
            Assert.That(onix.SpDefense, Is.EqualTo(70));
            Assert.That(onix.Moves, Is.Not.Null);
        }

        [Test]
        public void TestPokemonCreation_SingleType()
        {
            Pokemon squirtle = new Pokemon("Squirtle", PokemonType.Water);

            Assert.That(squirtle.Name, Is.EqualTo("Squirtle"));
            Assert.That(squirtle.Level, Is.EqualTo(1));
            Assert.That(squirtle.Attack, Is.EqualTo(10));
            Assert.That(squirtle.Defense, Is.EqualTo(10));
            Assert.That(squirtle.SpAttack, Is.EqualTo(10));
            Assert.That(squirtle.SpDefense, Is.EqualTo(10));

            Assert.That(squirtle.Types.Count, Is.EqualTo(1));
            Assert.That(squirtle.Types[0], Is.EqualTo(PokemonType.Water));

            Assert.That(squirtle.Moves, Is.Not.Null);
        }
    }

        [TestFixture]
        public class BattleTests
        {
            [Test]
            public void CharmanderVsPikachu_FireMove_ShouldDealNeutralDamage()
            {
                // Arrange
                var charmander = new Charmander();
                var pikachu = new Pikachu();

                // Movimiento de tipo Fuego (especial)
                var flamethrower = new Move("Flamethrower", PokemonType.Fire, MoveType.Special, 90);

                // Calcular modificador de tipo
                float modifier = DamageCalculator.GetModifier(flamethrower.Type, pikachu.Types);
                double stab = charmander.Types.Contains(flamethrower.Type) ? 1.5 : 1.0;
                double totalMod = modifier * stab;

                int damage = DamageCalculator.CalculateDamage(charmander, pikachu, flamethrower, totalMod);

                TestContext.WriteLine($"Charmander usó {flamethrower.Name} contra Pikachu: daño: {damage}");
                Assert.That(damage, Is.GreaterThan(0), "El daño debería ser mayor que cero.");
            }
        }

    }
