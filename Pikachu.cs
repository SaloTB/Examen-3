using Pokemon_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_1
{
    internal class Pikachu: Pokemon
    {
        public Pikachu() : base("Pikachu", PokemonType.Water)
        {
            Level = 1;
            Attack = 49;
            Defense = 49;
            SpAttack = 65;
            SpDefense = 65;
        }
    }
}
