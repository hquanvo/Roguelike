using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Core
{
    public class Player : Actor
    {
        private int _exp;
        private int _nextExp;
        public Player() 
        {
            Attack = 5;
            Defense = 2;
            Gold = 0;
            Health = 100;
            MaxHealth = 100;
            Speed = 15;
            Awareness = 15;
            Name = "Rogue";
            Color = Colors.Player;
            Symbol = '@';
            _exp = 0;
            _nextExp = 100;
        }

        public void DrawStats(RLConsole statConsole)
        {
            statConsole.Print(1, 1, $"Name:    {Name}", Colors.Text);
            statConsole.Print(1, 3, $"Health:  {Health}/{MaxHealth}", Colors.Text);
            statConsole.Print(1, 5, $"Attack:  {Attack}", Colors.Text);
            statConsole.Print(1, 7, $"Defense: {Defense}", Colors.Text);
            statConsole.Print(1, 9, $"Speed:   {Speed}", Colors.Text);
            statConsole.Print(1, 11, $"Exp:     {_exp}/{_nextExp}", Colors.Exp);
            statConsole.Print(1, 13, $"Gold:    {Gold}", Colors.Gold);
        }
    }
}
