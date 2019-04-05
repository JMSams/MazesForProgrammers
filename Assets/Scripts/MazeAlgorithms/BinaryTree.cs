using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class BinaryTree : AlgorithmBase
    {
        Highlight currentCell;
        Highlight unvisited;

        public override IEnumerator On(MazeGrid grid, Tester tester)
        {
            unvisited = new Highlight();
            unvisited.cells = new List<Cell>();
            for (int x = 0; x < grid.columnCount; x++)
                for (int y = 0; y < grid.rowCount; y++)
                    unvisited.cells.Add(grid[x, y]);
            unvisited.colour = Color.blue;

            for (int y = 0; y < grid.rowCount; y++)
            {
                for (int x = 0; x < grid.columnCount; x++)
                {
                    unvisited.cells.Remove(grid[x, y]);

                    // If current cell is in the north east corner
                    if (x == grid.columnCount-1 && y == 0)
                    {
                        continue;
                    }
                    // Else, if current cell is on the north edge
                    else if (y == 0)
                    {
                        grid[x, y].Link(grid[x + 1, y]);
                    }
                    // Else, if current cell is on the east edge
                    else if (x == grid.columnCount - 1)
                    {
                        grid[x, y].Link(grid[x, y - 1]);
                    }
                    else
                    {
                        if (Random.value >= 0.5f)
                            grid[x, y].Link(grid[x, y - 1]);
                        else
                            grid[x, y].Link(grid[x + 1, y]);
                    }

                    OnDraw(grid, new Highlight()
                        {
                            cells = new List<Cell>{ grid[x, y] },
                            colour = Color.red
                        }, unvisited
                    );
                    yield return new WaitForSeconds(tester.delayTime);
                }
            }
            OnComplete();
        }
    }
}
