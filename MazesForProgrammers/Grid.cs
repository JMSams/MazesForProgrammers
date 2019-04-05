using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers
{
    public class Grid
    {
        public int columnCount, rowCount;

        Cell[,] cells;

        public Grid(int columnCount, int rowCount)
        {
            this.columnCount = columnCount;
            this.rowCount = rowCount;

            PrepareGrid();
            ConfigureCells();
        }

        public virtual Cell this[int col, int row]
        {
            get
            {
                if (col < 0) return null;
                if (row < 0) return null;
                if (col >= columnCount) return null;
                if (row >= rowCount) return null;
                return cells[col, row];
            }
        }

        public virtual Cell randomCell
        {
            get
            {
                return cells[Random.Range(0, columnCount), Random.Range(0, rowCount)];
            }
        }

        public virtual void PrepareGrid()
        {
            cells = new Cell[columnCount, rowCount];
            for (int col = 0; col < columnCount; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    cells[col, row] = new Cell(col, row);
                }
            }
        }

        public virtual void ConfigureCells()
        {
            for (int col = 0; col < columnCount; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    cells[col, row].north = this[col, row - 1];
                    cells[col, row].south = this[col, row + 1];
                    cells[col, row].east = this[col + 1, row];
                    cells[col, row].west = this[col - 1, row];
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
