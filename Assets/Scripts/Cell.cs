using System;
using System.Collections.Generic;
using System.Linq;

public class Cell
{
    public Grid parent { get; protected set; }
    public int row { get; protected set; }
    public int column { get; protected set; }

    public Cell(Grid parent, int row, int col)
    {
        this.parent = parent;
        this.row = row;
        this.column = col;
    }


}