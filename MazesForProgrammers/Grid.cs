using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers
{
    class Grid
    {
        public int columnCount { get; protected set; }
        public int rowCount { get; protected set; }

        Cell[,] cells;

        public Grid(int columnCount, int rowCount)
        {
            this.columnCount = columnCount;
            this.rowCount = rowCount;

            cells = new Cell[columnCount, rowCount];
        }

        public Cell this[int column, int row]
        {
            get
            {
                if (column < 0
                    || row < 0
                    || column >= columnCount
                    || row >= rowCount)
                    return null;
                else
                    return cells[column, row];
            }
        }
    }
}
