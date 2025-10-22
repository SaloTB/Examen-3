using Pokemon_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_1
{
    internal class Sal : Pokemon
    {
        public Sal() : base("Sal", PokemonType.Ghost)
        {
            Level = 1;
            Attack = 50;
            Defense = 50;
            SpAttack = 70;
            SpDefense = 65;
        }
    }

}
