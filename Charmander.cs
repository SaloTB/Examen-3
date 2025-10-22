using Pokemon_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_1
{
    internal class Charmander : Pokemon
    {
        public Charmander() : base("Charmander", PokemonType.Fire)
        {
            Level = 1;
            Attack = 50;
            Defense = 53;
            SpAttack = 70;
            SpDefense = 65;
        }
    }
}
