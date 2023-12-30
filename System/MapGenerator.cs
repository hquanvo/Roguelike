using Roguelike.Core;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.System
{
    internal class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;

        private readonly DungeonMap _map;

        public MapGenerator(int width, int height)
        {
            _width = width;
            _height = height;
            _map = new DungeonMap();
        }

        // Generate open floor with walls on the outside map
        public DungeonMap CreateMap()
        {
            _map.Initialize(_width, _height);
            foreach (Cell cell in _map.GetAllCells())
            {
                // set transperancy, walkable, explored to true
                _map.SetCellProperties(cell.X, cell.Y, true, true, true);
            }

            // set first and last row in map to not be transparent or walkable
            foreach (Cell cell in _map.GetCellsInRows(0, _height - 1))
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            // set first and last column in map to not be transparent or walkable
            foreach (Cell cell in _map.GetCellsInColumns(0, _width - 1))
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            return _map;
        }
    }
}
