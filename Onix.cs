using Pokemon_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_1
{
    internal class Onix : Pokemon
    {
        public Onix() : base("Onix", PokemonType.Electric)
        {
            Level = 1;
            Attack = 40;
            Defense = 50;
            SpAttack = 65;
            SpDefense = 70;
        }
    }
}
