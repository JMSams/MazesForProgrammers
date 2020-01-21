using System;
using System.Collections.Generic;
using System.Linq;

public class Cell
{
    public Grid parent { get; protected set; }
    public int row { get; protected set; }
    public int column { get; protected set; }

    public Cell north { get; set; }
    public Cell east { get; set; }
    public Cell south { get; set; }
    public Cell west { get; set; }

    List<Cell> links;

    public Cell(Grid parent, int col, int row)
    {
        this.parent = parent;
        this.row = row;
        this.column = col;

        this.links = new List<Cell>();
    }

    public void Link(Cell other)
    {
        Link(other, true);
    }
    public void Link(Cell other, bool bidi)
    {
        links.Add(other);

        if (bidi)
            other.Link(this, false);
    }

    public void Unlink(Cell other)
    {
        Unlink(other, true);
    }
    public void Unlink(Cell other, bool bidi)
    {
        links.Remove(other);

        if (bidi)
            other.Unlink(this, false);
    }

    public bool IsLinked(params Cell[] others)
    {
        bool rv = true;
        foreach (Cell c in others)
            rv &= links.Contains(c);
        return rv;
    }
}