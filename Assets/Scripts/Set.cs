using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers
{
    class Set
    {
        public List<Cell> cells;

        Color _colour;
        public Color colour
        {
            get => _colour;
            set
            {
                _colour = value;
                foreach (Cell cell in cells)
                {
                    cell.colour = value;
                }
            }
        }

        public Set(params Cell[] startCells)
        {
            cells = new List<Cell>(startCells);
            colour = Color.HSVToRGB(Random.value, 0.75f, 0.75f);
        }

        public void AddCell(Cell cell)
        {
            this.cells.Add(cell);
            cell.colour = colour;
        }

        public void RemoveCell(Cell cell)
        {
            this.cells.Remove(cell);
            cell.colour = Color.white;
        }

        public bool IsInSet(Cell cell)
        {
            return cells.Contains(cell);
        }
    }
}