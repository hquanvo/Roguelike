using RLNET;
using Roguelike.Interfaces;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Core
{
    public class Actor : IActor, IDrawable
    {
        public string Name { get; set; }
        public int Awareness { get; set; }
        public RLColor Color { get; set; }
        public char Symbol { get ; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(RLConsole console, IMap map)
        {
            // don't draw in cells that are not explored
            if (!map.GetCell(X, Y).IsExplored) return;

            // draw actor and symbol when in field-of-view
            if (map.IsInFov(X, Y))
            {
                console.Set(X, Y, Color, Colors.FloorBackgroundFov, Symbol);
            }
            else
            {
                console.Set(X, Y, Colors.Floor, Colors.FloorBackground, '.'); 
            }
        }
    }
}
