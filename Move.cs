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

        public Move(string name, int basePower, PokemonType type, MoveType moveType)
        {
            Name = name;
            BasePower = basePower;
            Type = type;
            MoveType = moveType;
        }

        public Move()
        {
            Name = "Default Move";
            BasePower = 100;   
        }
    }

    public enum MoveType
    {
        Physical,
        Special
    }
}

