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
        }

        public void DrawStats(RLConsole statConsole)
        {
            statConsole.Print(1, 1, $"Name:    {Name}", Colors.Text);
            statConsole.Print(1, 3, $"Health:  {Health}/{MaxHealth}", Colors.Text);
            statConsole.Print(1, 5, $"Attack:  {Attack}", Colors.Text);
            statConsole.Print(1, 7, $"Defense: {Defense}", Colors.Text);
            statConsole.Print(1, 9, $"Speed: {Speed}", Colors.Text);
            statConsole.Print(1, 11, $"Gold:    {Gold}", Colors.Gold);
        }
    }
}
