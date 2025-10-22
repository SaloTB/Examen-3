using Pokemon_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_1
{

    internal class Chikorita : Pokemon
    {
        public Chikorita() : base("Chikorita", PokemonType.Grass)
        {
            Level = 1;
            Attack = 45;
            Defense = 70;
            SpAttack = 50;
            SpDefense = 65;
        }
    }

}
