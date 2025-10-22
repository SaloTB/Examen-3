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

    }
}
