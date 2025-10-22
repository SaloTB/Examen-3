using Pokemon_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemon_1
{
    public class Move
    {
        public string Name { get; set; }
        public int BasePower { get; set; }
        public PokemonType Type { get; set; }
        public MoveType MoveType { get; set; }

        public Move(string name, PokemonType type, MoveType moveType, int basePower = 100)
        {
            Name = name;
            Type = type;
            MoveType = moveType; 

            if (basePower < 1)
                BasePower = 1;
            else if (basePower > 255)
                BasePower = 255;
            else
                BasePower = basePower;
        }
    }

    public enum MoveType
    {
        Physical,
        Special
    }
}
