using RogueSharp.DiceNotation;
using RogueSharp.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Core.Monsters
{
    public class Kobold : Monster
    {
        public static Kobold Create(int level) 
        {
            return new Kobold
            {
                Attack = 10 + level / 4,
                Defense = 5 + level / 3,
                Gold = 20 + Dice.Roll("1D10"),
                Color = Colors.KoboldColor,
                Health = 30 + level / 2,
                MaxHealth = 30 + level/2,
                Name = "Kobold",
                Speed = 3,
                Symbol = 'k',
                Awareness = 10,
            };
        }
    }
}
