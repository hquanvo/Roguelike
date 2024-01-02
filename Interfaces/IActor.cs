using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Interfaces
{
    public interface IActor
    {   
        // Combat: Damage formula is Attack - Defense (with 5% dmg variation). Speed determines hit chance.
        // If attacker speed >= 1.5 * defender speed, hit chance is 150%, if attacker speed <= defender speed / 2, hit chance is 50%.
        int Attack { get; set; }
        int Defense { get; set; }
        int Gold { get; set; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Speed { get; set; }
        string Name { get; set; }
        int Awareness { get; set; }
    }
}
