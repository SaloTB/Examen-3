using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pokemon_1;
using pokemon_1;
using static pokemon_1.Move;

namespace Pokemon_1
{
    public static class DamageCalculator
    {
        // Tabla tipo contra tipo
        private static readonly Dictionary<PokemonType, Dictionary<PokemonType, float>> typeChart =
            new Dictionary<PokemonType, Dictionary<PokemonType, float>>
        {
            { PokemonType.Rock, new Dictionary<PokemonType, float> {
                { PokemonType.Ground, 0.5f }, { PokemonType.Water, 1f }, { PokemonType.Electric, 1f },
                { PokemonType.Fire, 2f }, { PokemonType.Grass, 0.5f }, { PokemonType.Bug, 2f }
            }},

            { PokemonType.Ground, new Dictionary<PokemonType, float> {
                { PokemonType.Rock, 2f }, { PokemonType.Fire, 2f }, { PokemonType.Electric, 2f },
                { PokemonType.Grass, 0.5f }, { PokemonType.Bug, 0.5f }
            }},

            { PokemonType.Water, new Dictionary<PokemonType, float> {
                { PokemonType.Rock, 2f }, { PokemonType.Ground, 2f }, { PokemonType.Fire, 2f },
                { PokemonType.Water, 0.5f }, { PokemonType.Grass, 0.5f }
            }},

            { PokemonType.Electric, new Dictionary<PokemonType, float> {
                { PokemonType.Water, 2f }, { PokemonType.Ground, 0f }, { PokemonType.Electric, 0.5f },
                { PokemonType.Grass, 0.5f }
            }},

            { PokemonType.Fire, new Dictionary<PokemonType, float> {
                { PokemonType.Rock, 0.5f }, { PokemonType.Water, 0.5f }, { PokemonType.Grass, 2f },
                { PokemonType.Bug, 2f }
            }},

            { PokemonType.Grass, new Dictionary<PokemonType, float> {
                { PokemonType.Rock, 2f }, { PokemonType.Water, 2f }, { PokemonType.Fire, 0.5f },
                { PokemonType.Grass, 0.5f },  { PokemonType.Ground, 2f }
            }},
        };

        public static float GetModifier(PokemonType attackType, List<PokemonType> defenderTypes)
        {
            float multiplier = 1f;

            foreach (var defType in defenderTypes)
            {
                if (typeChart.ContainsKey(attackType) && typeChart[attackType].ContainsKey(defType))
                {
                    multiplier *= typeChart[attackType][defType];
                }
                else
                {
                    multiplier *= 1f; // Neutro
                }
            }

            return multiplier;
        }

        public static int CalculateDamage(Pokemon attacker, Pokemon defender, Move move, double mod)
        {
            if (attacker == null || defender == null || move == null)
                throw new ArgumentNullException("Attacker, defender y move no pueden ser nulos.");

            int atkStat = (move.MoveType == MoveType.Physical) ? attacker.Attack : attacker.SpAttack;
            int defStat = (move.MoveType == MoveType.Physical) ? defender.Defense : defender.SpDefense;

            if (defStat <= 0) defStat = 1;

            double levelFactor = (2.0 * attacker.Level / 5.0) + 2.0;
            double baseTerm = levelFactor * move.BasePower * ((double)atkStat / defStat);
            double dmgBeforeDivide = baseTerm / 50.0 + 2.0;

            double dmg = dmgBeforeDivide * mod;


            return (int)Math.Floor(dmg);
        }

    }

}

