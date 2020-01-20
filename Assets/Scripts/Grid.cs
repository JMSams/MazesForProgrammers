using System;
using System.Collections.Generic;

public class Grid
{
    public int columnCount { get; protected set; }
    public int rowCount { get; protected set; }

    protected virtual Cell[,] cells;

    public Cell this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= cells.GetLength(0) || col < 0 || col >= cells.GetLength(1))
                return null;
            else
                return cells[row, col];
        }
        protected set => cells[row, col] = value;
    }
}
