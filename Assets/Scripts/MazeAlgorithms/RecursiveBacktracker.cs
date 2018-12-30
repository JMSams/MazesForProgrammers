using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class RecursiveBacktracker : AlgorithmBase
    {
        bool[,] visited;

        public override void On(ref MazeGrid grid)
        {
            int startX = Random.Range(0, grid.columnCount);
            int startY = Random.Range(0, grid.rowCount);

            visited = new bool[grid.columnCount, grid.rowCount];

            Backtracker(ref grid, startX, startY);
        }

        void Backtracker(ref MazeGrid grid, int x, int y)
        {
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

                switch (d)
                {
                    case Direction.North:
                        Backtracker(ref grid, x, y - 1);
                        break;
                    case Direction.South:
                        Backtracker(ref grid, x, y + 1);
                        break;
                    case Direction.East:
                        Backtracker(ref grid, x + 1, y);
                        break;
                    case Direction.West:
                        Backtracker(ref grid, x - 1, y);
                        break;
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
