using System.Text;
using UnityEngine;

namespace Mazes_for_Programmers
{
    public class MazeGrid
    {
        public int columnCount { get; protected set; }
        public int rowCount { get; protected set; }

        Cell[,] cells;

        public MazeGrid(int columnCount, int rowCount)
        {
            this.columnCount = columnCount;
            this.rowCount = rowCount;

            PrepareGrid();
            ConfigureCells();
        }

        protected virtual void PrepareGrid()
        {
            cells = new Cell[columnCount, rowCount];
        }

        protected virtual void ConfigureCells()
        {
            for (int x = 0; x < columnCount; x++)
            {
                for (int y = 0; y < rowCount; y++)
                {
                    cells[x, y] = new Cell(x, y);

                    cells[x, y].north = this[x, y - 1];
                    cells[x, y].south = this[x, y + 1];
                    cells[x, y].east = this[x + 1, y];
                    cells[x, y].west = this[x - 1, y];
                }
            }
        }

        public Cell this[int x, int y]
        {
            get
            {
                if (x < 0) return null;
                if (y < 0) return null;
                if (x >= columnCount) return null;
                if (y >= rowCount) return null;
                return cells[x, y];
            }
        }

        public Cell randomCell
        {
            get
            {
                return this[Random.Range(0, columnCount), Random.Range(0, rowCount)];
            }
        }

        public int size { get { return rowCount * columnCount; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("█");
            for (int x = 0; x < columnCount; x++)
                sb.Append("██");
            sb.AppendLine();

            for (int y = 0; y < rowCount; y++)
            {
                sb.Append("█");
                for (int x = 0; x < columnCount; x++)
                {
                    sb.Append(" ");
                    sb.Append(this[x, y].IsLinked(this[x + 1, y]) ? " " : "█");
                }
                sb.AppendLine();
                
                sb.Append("█");
                for (int x = 0; x < columnCount; x++)
                {
                    sb.Append(this[x, y].IsLinked(this[x, y + 1]) ? " " : "█");
                    sb.Append("█");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
