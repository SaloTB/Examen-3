using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pokemon_1;

namespace pokemon_1
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<PokemonType> Types { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public List<Move> Moves { get; set; }

        public Pokemon(string name, int level, int atk, int def, int spAtk, int spDef,PokemonType type1)
        {
            Name = name;
            Level = level;
            Attack = atk;
            Defense = def;
            SpAttack = spAtk;
            SpDefense = spDef;

            Moves = new List<Move>();
            Types = new List<PokemonType> { type1 };
        }

      
        public Pokemon(string name, PokemonType type1, PokemonType? type2 = null)
        {
            Name = name;
            Level = 1;
            Attack = 10;
            Defense = 10;
            SpAttack = 10;
            SpDefense = 10;
            Moves = new List<Move>();
            Types = new List<PokemonType> { type1 };
            if (type2.HasValue) Types.Add(type2.Value);
        }

        public static class PokemonFactory
        {
            public static Pokemon CreateCharmander()
            {
                var charmander = new Pokemon("Charmander", 10, 52, 43, 60, 50, PokemonType.Fire);
                charmander.Moves.Add(new Move("Ember", 40, PokemonType.Fire, MoveType.Special));
                charmander.Moves.Add(new Move("Scratch", 40, PokemonType.Bug, MoveType.Physical));
                return charmander;
            }

            public static Pokemon CreateSquirtle()
            {
                var squirtle = new Pokemon("Squirtle", 10, 48, 65, 50, 64, PokemonType.Water);
                squirtle.Moves.Add(new Move("Water Gun", 40, PokemonType.Water, MoveType.Special));
                squirtle.Moves.Add(new Move("Tackle", 35, PokemonType.Bug, MoveType.Physical));
                return squirtle;
            }

            public static Pokemon CreateBulbasaur()
            {
                var bulbasaur = new Pokemon("Bulbasaur", 10, 49, 49, 65, 65, PokemonType.Grass);
                bulbasaur.Moves.Add(new Move("Vine Whip", 45, PokemonType.Grass, MoveType.Physical));
                bulbasaur.Moves.Add(new Move("Tackle", 35, PokemonType.Bug, MoveType.Physical));
                return bulbasaur;
            }

            public static Pokemon CreatePikachu()
            {
                var pikachu = new Pokemon("Pikachu", 12, 55, 40, 50, 50, PokemonType.Electric);
                pikachu.Moves.Add(new Move("Thunderbolt", 90, PokemonType.Electric, MoveType.Special));
                pikachu.Moves.Add(new Move("Quick Attack", 40, PokemonType.Bug, MoveType.Physical));
                return pikachu;
            }

            public static Pokemon CreateOnix()
            {
                var onix = new Pokemon("Onix", 10, 45, 160, 30, 45, PokemonType.Rock);
                onix.Types.Add(PokemonType.Ground); // doble tipo
                onix.Moves.Add(new Move("Rock Throw", 50, PokemonType.Rock, MoveType.Physical));
                onix.Moves.Add(new Move("Tackle", 35, PokemonType.Bug, MoveType.Physical));
                return onix;
            }
        }

    }
}
