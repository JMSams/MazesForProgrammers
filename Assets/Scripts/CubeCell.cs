using System;
using System.Collections.Generic;

public class CubeCell : Cell
{
    public int face { get; protected set; }

    public CubeCell(CubeGrid parent, int face, int col, int row) : base(parent, col, row)
    {
        this.face = face;
    }
}