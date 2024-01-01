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
        private int _attack;
        private int _defense;
        private int _gold;
        private int _health;
        private int _maxHealth;
        private int _speed;
        private string _name;
        private int _awareness;

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
            }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                _maxHealth = value;
            }
        }

        public int Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public int Awareness
        {
            get { return _awareness; }
            set
            {
                _awareness = value;
            }
        }

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
