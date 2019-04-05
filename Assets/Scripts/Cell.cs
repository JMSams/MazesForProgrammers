using System.Collections.Generic;

namespace Mazes_for_Programmers
{
    public class Cell
    {
        public Cell(int column, int row)
        {
            this.column = column;
            this.row = row;
            this.links = new List<Cell>();
        }

        public int row { get; protected set; }
        public int column { get; protected set; }

        public Cell north { get; set; }
        public Cell east { get; set; }
        public Cell south { get; set; }
        public Cell west { get; set; }

        public List<Cell> links;

        public void Link(Cell other, bool bidi = true)
        {
            if (other == null) return;

            links.Add(other);
            if (bidi)
                other.Link(this, false);
        }

        public void Unlink(Cell other, bool bidi = true)
        {
            if (other == null) return;

            links.Remove(other);
            if (bidi)
                other.Unlink(this, false);
        }

        public bool IsLinked(Cell other)
        {
            return (other == null) ? false : links.Contains(other);
        }
    }
}
