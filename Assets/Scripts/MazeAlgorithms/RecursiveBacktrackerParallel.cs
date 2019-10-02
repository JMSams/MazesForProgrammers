using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class RecursiveBacktrackerParallel : AlgorithmBase
    {
        Highlight cellQueue;
        Highlight unvisited;

        int running = 0;

        public override IEnumerator On(MazeGrid grid, Tester tester)
        {
            List<Vector2Int> start = new List<Vector2Int>();
            for (int i = 0; i < tester.parallelProccesses; i++)
            {
                start.Add(new Vector2Int(Random.Range(0, grid.columnCount), Random.Range(0, grid.rowCount)));
            }

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

            running = 0;
            for (int i = 0; i < tester.parallelProccesses; i++)
            {
                running++;
                tester.StartCoroutine(BacktrackerWrapper(grid, start[i].x, start[i].y, tester));
            }
            
            while (running > 0)
            {
                yield return null;
            }

            // TODO: Connect all the maze segments

            OnComplete();
        }

        IEnumerator BacktrackerWrapper(MazeGrid grid, int x, int y, Tester tester)
        {
            Debug.Log("Starting new backtracker...");
            yield return tester.StartCoroutine(Backtracker(grid, x, y, tester));
            running--;
            Debug.Log("Backtracker finished!");
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
                cells = new List<Cell>{ grid[x, y] },
                colour = Color.red
            };
            OnDraw(grid, unvisited, cellQueue, currentCell);

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
