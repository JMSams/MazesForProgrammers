using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrid : Grid
{
    new protected CubeCell[,,] cells;
    
    public CubeGrid(int cubeSize) : base(cubeSize, cubeSize) { }

    public new IEnumerable<CubeCell> EachCell()
    {
        for (int face = 0; face < 6; face++)
        {
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    yield return this[face, col, row];
                }
            }
        }
    }

    public new IEnumerable<CubeCell[]> EachRow()
    {
        List<CubeCell> therow = new List<CubeCell>();
        for (int face = 0; face < 6; face++)
        {
            for (int row = 0; row < rowCount; row++)
            {
                therow.Clear();
                for (int col = 0; col < columnCount; col++)
                {
                    therow.Add(this[face, col, row]);
                }
                yield return therow.ToArray();
            }
        }
    }

    protected override void PrepareGrid()
    {
        Debug.Log("CubeGrid.PrepareGrid()");
        cells = new CubeCell[6, columnCount, rowCount];
        for (int face = 0; face < 6; face++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    cells[face, col, row] = new CubeCell(this, face, col, row);
                }
            }
        }
    }

    protected override void ConfigureGrid()
    {
        foreach (CubeCell cell in EachCell())
        {
            cell.north = this[cell.face, cell.column, cell.row + 1];
            cell.east = this[cell.face, cell.column + 1, cell.row];
            cell.south = this[cell.face, cell.column, cell.row - 1];
            cell.west = this[cell.face, cell.column - 1, cell.row];
        }
    }

    public override Cell this[int col, int row]
    {
        get => throw new NotSupportedException("CubeGrid requires three coordinates (face, row, column).");
        protected set => throw new NotSupportedException("CubeGrid requires three coordinates (face, row, column).");
    }

    public CubeCell this[int face, int col, int row]
    {
        get
        {
            //TODO: Wrap around to adjacent faces
            return cells[face, col, row];
        }
        protected set => cells[face, col, row] = value;
    }
}