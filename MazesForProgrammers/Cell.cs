using System;
using System.Collections.Generic;
using MonoGame;

namespace MazesForProgrammers
{
    class Cell
    {
        Grid parent;

        public int column { get; protected set; }
        public int row { get; protected set; }

        public Cell north { get { return parent[column, row + 1]; } }
        public Cell east { get { return parent[column + 1, row]; } }
        public Cell south { get { return parent[column, row - 1]; } }
        public Cell west { get { return parent[column - 1, row]; } }

        List<Cell> links;

        public Cell(int column, int row, Grid parent)
        {
            this.column = column;
            this.row = row;
            this.parent = parent;
            links = new List<Cell>();
        }

        public void Link(Cell other, bool bidi = true)
        {
            links.Add(other);
            if (bidi)
                other.Link(this, false);
        }

        public void Draw()
        {
            // http://rbwhitaker.wikidot.com/drawing-triangles
        }
    }
}
