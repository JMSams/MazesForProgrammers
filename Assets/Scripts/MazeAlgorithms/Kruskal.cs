using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class Kruskal : AlgorithmBase
    {
        Highlight currentCells;
        Highlight unvisited;

        List<Set> sets;

        public override IEnumerator On(MazeGrid grid, Tester tester)
        {
            unvisited = new Highlight();
            unvisited.cells = new List<Cell>();
            for (int x = 0; x < grid.columnCount; x++)
                for (int y = 0; y < grid.rowCount; y++)
                    unvisited.cells.Add(grid[x, y]);
            unvisited.colour = Color.blue;

            sets = new List<Set>();
            for (int x = 0; x < grid.columnCount; x++)
                for (int y = 0; y < grid.rowCount; y++)
                    sets.Add(new Set(grid[x, y]));

            while (sets.Count >= 2)
            {
                Cell cellA = grid[Random.Range(0, grid.columnCount), Random.Range(0, grid.rowCount)];
                Cell cellB = grid[Random.Range(0, grid.columnCount), Random.Range(0, grid.rowCount)];
                // TODO: cellB should be next to cellA

                int setID = -1;
                for (int i = 0; i < sets.Count; i++)
                {
                    if (sets[i].IsInSet(cellA))
                    {
                        setID = i;
                        break;
                    }
                }

                if (!sets[setID].IsInSet(cellB))
                {
                    // TODO: Add cellB to sets[setID]

                    // TODO: If sets[setID] is empty, remove it
                }

                currentCells.cells = new List<Cell> { cellA, cellB };
                OnDraw(grid, currentCells, unvisited);
                yield return new WaitForSeconds(tester.delayTime);
            }
        }

        class Set
        {
            public List<Cell> cells;

            public Set(params Cell[] startCells)
            {
                cells = new List<Cell>(startCells);
            }

            public bool IsInSet(Cell cell)
            {
                return cells.Contains(cell);
            }
        }
    }
}
