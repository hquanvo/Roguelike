using RLNET;
using Roguelike.Core.Behavior;
using Roguelike.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Core
{
    public class Monster : Actor
    {
        public int? TurnsAlerted {  get; set; }
        protected int _expValue;
        public void DrawStats(RLConsole statConsole, int position)
        {
            int yPosition = 17 + 2 * position;
            statConsole.Print(1, yPosition, Symbol.ToString(), Color);

            int width = Convert.ToInt32(((double) Health / (double) MaxHealth) * 16.0);
            int remainingWidth = 16 - width;

            statConsole.SetBackColor(3, yPosition, width, 1, Pallete.Primary);
            statConsole.SetBackColor(3 + width, yPosition, remainingWidth, 1, Pallete.PrimaryDarkest);

            statConsole.Print(2, yPosition, $": {Name} {Health}/{MaxHealth}", Pallete.DbLight);
        }

        public int ExpValue
        {
            get { return _expValue; }
            set { _expValue = value; }
        }

        public virtual void PerformAction(CommandSystem commandSystem)
        {
            var behavior = new StandardMoveAndAttack();
            behavior.Act(this, commandSystem);
        }
    }
}
