using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers.Algorithms
{
    public class BinaryTree : AlgorithmBase
    {
        public override void OnGrid(Grid grid)
        {
            for (int col = 0; col < grid.columnCount; col++)
            {
                for (int row = 0; row < grid.rowCount; row++)
                {
                    List<Cell> neighbours = new List<Cell>();
                    if (grid[col, row].north != null)
                        neighbours.Add(grid[col, row].north);
                    if (grid[col, row].east != null)
                        neighbours.Add(grid[col, row].east);

                    if (neighbours.Count == 0)
                        continue;
                    else
                    {
                        Cell neighbour = neighbours[Random.Range(neighbours.Count)];
                        grid[col, row].Link(neighbour);
                    }
                }
            }
        }
    }
}
