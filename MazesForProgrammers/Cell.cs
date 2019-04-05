using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers
{
    public class Cell
    {
        public int column { get; set; }
        public int row { get; set; }

        public Cell north { get; set; }
        public Cell east { get; set; }
        public Cell south { get; set; }
        public Cell west { get; set; }

        public Dictionary<Directions, Cell> Neighbours
        {
            get
            {
                var rv = new Dictionary<Directions, Cell>();
                rv.Add(Directions.North, north);
                rv.Add(Directions.East, east);
                rv.Add(Directions.South, south);
                rv.Add(Directions.West, west);
                return rv;
            }
        }

        List<Cell> _links;
        public Cell[] links
        {
            get
            {
                return _links.ToArray();
            }
        }

        public Cell(int column, int row)
        {
            this.column = column;
            this.row = row;

            this._links = new List<Cell>();
        }

        public void Link(Cell other, bool bidi = true)
        {
            _links.Add(other);
            if (bidi)
                other.Link(this);
        }

        public void Unlink(Cell other, bool bidi = true)
        {
            _links.Remove(other);
            if (bidi)
                other.Unlink(this);
        }

        public bool IsLinked(Cell other)
        {
            return _links.Contains(other);
        }
    }
}
