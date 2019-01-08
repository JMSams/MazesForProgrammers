using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class RecursiveBacktracker : AlgorithmBase
    {
        bool[,] visited;
        
        public override IEnumerator On(MazeGrid grid, Tester tester)
        {
            int startX = Random.Range(0, grid.columnCount);
            int startY = Random.Range(0, grid.rowCount);

            visited = new bool[grid.columnCount, grid.rowCount];
            for (int x = 0; x < grid.columnCount; x++)
                for (int y = 0; y < grid.rowCount; y++)
                    visited[x, y] = false;

            yield return tester.StartCoroutine(Backtracker(grid, startX, startY, tester));

            tester.AlgorithmComplete();
        }

        IEnumerator Backtracker(MazeGrid grid, int x, int y, Tester tester)
        {
            if (tester != null)
                yield return new WaitForSeconds(tester.delayTime);

            tester.output.text = grid.ToString();

            visited[x, y] = true;

            List<Direction> directions = new List<Direction>();
            if (grid[x, y - 1] != null && !visited[x, y - 1])
                directions.Add(Direction.North);
            if (grid[x, y + 1] != null && !visited[x, y + 1])
                directions.Add(Direction.South);
            if (grid[x + 1, y] != null && !visited[x + 1, y])
                directions.Add(Direction.East);
            if (grid[x - 1, y] != null && !visited[x - 1, y])
                directions.Add(Direction.West);

            while (directions.Count > 0)
            {
                int i = Random.Range(0, directions.Count);
                Direction d = directions[i];
                directions.RemoveAt(i);

                Cell other = null;

                switch (d)
                {
                    case Direction.North:
                        other = grid[x, y - 1];
                        break;
                    case Direction.South:
                        other = grid[x, y + 1];
                        break;
                    case Direction.East:
                        other = grid[x + 1, y];
                        break;
                    case Direction.West:
                        other = grid[x - 1, y];
                        break;
                }

                if (other == null) continue;

                if (!visited[other.column, other.row])
                {
                    grid[x, y].Link(other);
                    yield return tester.StartCoroutine(Backtracker(grid, other.column, other.row, tester));
                }
            }
        }

        enum Direction
        {
            North,
            South,
            East,
            West
        }
    }
}
