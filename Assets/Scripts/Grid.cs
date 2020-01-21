using System;
using System.Collections.Generic;
using System.Text;

public class Grid
{
    public int columnCount { get; protected set; }
    public int rowCount { get; protected set; }

    protected Cell[,] cells;

    public Grid(int columnCount, int rowCount)
    {
        this.columnCount = columnCount;
        this.rowCount = rowCount;

        PrepareGrid();
        ConfigureGrid();
    }

    public virtual IEnumerable<Cell> EachCell()
    {
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                yield return this[col, row];
            }
        }
    }

    public virtual IEnumerable<Cell[]> EachRow()
    {
        List<Cell> therow = new List<Cell>();
        for (int row = 0; row < rowCount; row++)
        {
            therow.Clear();
            for (int col = 0; col < columnCount; col++)
            {
                therow.Add(this[col, row]);
            }
            yield return therow.ToArray();
        }
    }

    protected virtual void PrepareGrid()
    {
        cells = new Cell[columnCount, rowCount];
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                this[col, row] = new Cell(this, col, row);
            }
        }
    }
    protected virtual void ConfigureGrid()
    {
        foreach (Cell cell in EachCell())
        {
            cell.north = this[cell.column, cell.row + 1];
            cell.east = this[cell.column + 1, cell.row];
            cell.south = this[cell.column, cell.row - 1];
            cell.west = this[cell.column - 1, cell.row];
        }
    }

    public virtual Cell this[int col, int row]
    {
        get
        {
            if (row < 0 || row >= cells.GetLength(0) || col < 0 || col >= cells.GetLength(1))
                return null;
            else
                return cells[col, row];
        }
        protected set => cells[col, row] = value;
    }

    public override string ToString()
    {
        StringBuilder rv = new StringBuilder();

        rv.Append("+");
        for (int col = 0; col < columnCount; col++)
            rv.Append("---+");
        rv.AppendLine();

        for (int row = rowCount-1; row >= 0; row--)
        {
            rv.Append("|");
            for (int col = 0; col < columnCount; col++)
            {
                rv.Append("   ");
                if (this[col, row].IsLinked(this[col, row].east))
                    rv.Append(" ");
                else
                    rv.Append("|");
            }
            rv.AppendLine();

            rv.Append("+");
            for (int col = 0; col < columnCount; col++)
            {
                if (this[col, row].IsLinked(this[col, row].south))
                    rv.Append("   +");
                else
                    rv.Append("---+");
            }
            rv.AppendLine();
        }

        return rv.ToString();
    }
}
