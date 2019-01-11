using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class RecursiveBacktracker : AlgorithmBase
    {
        Highlight cellQueue;
        Highlight unvisited;

        public override IEnumerator On(MazeGrid grid, Tester tester)
        {
            int startX = Random.Range(0, grid.columnCount);
            int startY = Random.Range(0, grid.rowCount);
            
            unvisited = new Highlight();
            for (int x = 0; x < grid.columnCount; x++)
                for (int y = 0; y < grid.rowCount; y++)
                    unvisited.cells.Add(grid[x, y]);
            unvisited.colour = Color.blue;

            cellQueue = new Highlight()
            {
                cells = new List<Cell>(),
                colour = Color.yellow
            };

            yield return tester.StartCoroutine(Backtracker(grid, startX, startY, tester));

            OnComplete();
        }

        IEnumerator Backtracker(MazeGrid grid, int x, int y, Tester tester)
        {
            unvisited.cells.Remove(grid[x, y]);
            yield return new WaitForSeconds(tester.delayTime / 2f);

            // TODO: randomly choose cells to recurse into

            OnDraw(grid, unvisited, cellQueue, new Highlight() { cells = { grid[x, y] }, colour = Color.red });
            cellQueue.cells.Add(grid[x, y]);
            // Backtracker()
            cellQueue.cells.Remove(grid[x, y]);
            yield return new WaitForSeconds(tester.delayTime / 2f);
        }
    }
}
