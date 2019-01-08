using System.Collections;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class BinaryTree : AlgorithmBase
    {
        public override IEnumerator On(MazeGrid grid, Tester tester)
        {
            for (int y = grid.rowCount - 1; y >= 0; y--)
            {
                for (int x = 0; x < grid.columnCount; x++)
                {
                    if (y == 0)
                    {
                        if (x < grid.columnCount - 1)
                        {
                            grid[x, y].Link(grid[x + 1, y]);
                        }
                    }
                    else if (x == grid.columnCount - 1)
                    {
                        grid[x, y].Link(grid[x, y - 1]);
                    }
                    else
                    {
                        if (Random.value >= 0.5f)
                        {
                            grid[x, y].Link(grid[x, y - 1]);
                        }
                        else
                        {
                            grid[x, y].Link(grid[x + 1, y]);
                        }
                    }

                    tester.output.text = grid.ToString();
                    yield return new WaitForSeconds(tester.delayTime);
                }
            }

            tester.AlgorithmComplete();
        }
    }
}
