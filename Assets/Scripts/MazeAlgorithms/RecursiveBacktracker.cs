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
            unvisited.cells = new List<Cell>();
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
            List<Directions> directions = new List<Directions>();
            if (x > 0)
            	directions.Add(Directions.west);
            if (x < grid.columnCount-1)
            	directions.Add(Directions.east);
            if (y > 0)
            	directions.Add(Directions.north);
            if (y < grid.rowCount-1)
            	directions.Add(Directions.south);

            Highlight currentCell = new Highlight()
            {
                //cells = { grid[x, y] },
                colour = Color.red
            };
            OnDraw(grid, unvisited, cellQueue);

            cellQueue.cells.Add(grid[x, y]);
            
            while (directions.Count > 0)
            {
            	Directions d = directions[Random.Range(0, directions.Count)];
            	directions.Remove(d);

                Vector2Int other = Vector2Int.zero;
                switch (d)
                {
                    case Directions.north:
                        other = new Vector2Int(x, y - 1);
                        break;
                    case Directions.south:
                        other = new Vector2Int(x, y + 1);
                        break;
                    case Directions.east:
                        other = new Vector2Int(x + 1, y);
                        break;
                    case Directions.west:
                        other = new Vector2Int(x - 1, y);
                        break;
                }
                if (unvisited.cells.Contains(grid[other.x, other.y]))
                {
                    grid[x, y].Link(grid[other.x, other.y]);
                    yield return tester.StartCoroutine(Backtracker(grid, other.x, other.y, tester));
                }
            }
            
            cellQueue.cells.Remove(grid[x, y]);
            OnDraw(grid, unvisited, cellQueue);
            yield return new WaitForSeconds(tester.delayTime / 2f);
        }
    }
}
