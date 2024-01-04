using Roguelike.Core;
using Roguelike.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Interfaces
{
    internal interface IBehavior
    {
        bool Act(Monster monster, CommandSystem commandSystem);
    }
}
