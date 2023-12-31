using RLNET;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Core
{
    public class DungeonMap : Map
    {
        public List<Rectangle> Rooms;

        public DungeonMap() { 
            Rooms = new List<Rectangle>();
        }

        public void Draw(RLConsole mapConsole)
        {
            mapConsole.Clear();

            foreach (Cell cell in GetAllCells())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        public void UpdateFov()
        {
            Player player = Game.Player;

            // Compute the field-of-view based on the player's location and awareness
            ComputeFov(player.X, player.Y, player.Awareness, true);
            // Mark all cells in field-of-view as having been explored
            foreach (Cell cell in GetAllCells())
            {
                if (IsInFov(cell.X, cell.Y))
                {
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }

        // Return true if successfully set actor new position, false otherwise
        public bool SetActorPosition(Actor actor, int x, int y)
        {
            // Only allow actor placement if cell is walkable
            if (GetCell(x,y).IsWalkable)
            {
                // Set cell actor was previously on to be walkable
                SetIsWalkable(actor.X, actor.Y, true);

                actor.X = x;
                actor.Y = y;

                // Set cell actor that is currently on to be unwalkable
                SetIsWalkable(actor.X, actor.Y, false);

                if (actor is Player)
                {
                    UpdateFov();
                }
                return true;

            }
            return false;
        }

        public void SetIsWalkable(int x, int y,  bool isWalkable)
        {
            Cell cell = (Cell) GetCell(x,y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
        }

        // 
        private void SetConsoleSymbolForCell(RLConsole mapConsole, Cell cell)
        {
            // When a cell is not explored, do nothing
            if (!cell.IsExplored)
            {
                return;
            }
             
            // When cell is in field-of-view it needs to be drawn with lighter colors
            if (IsInFov(cell.X, cell.Y))
            {
                // Choose symbol to draw if cell is walkable or not, . for floor and # for wall
                if (cell.IsWalkable)
                {
                    mapConsole.Set(cell.X, cell.Y, Colors.FloorFov, Colors.FloorBackgroundFov, '.');
                } else
                {
                    mapConsole.Set(cell.X, cell.Y, Colors.WallFov, Colors.WallBackgroundFov, '#');
                }
            } else
            {
                if (cell.IsWalkable)
                {
                    mapConsole.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                }
                else
                {
                    mapConsole.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
                }
            }

        }
    }
}
