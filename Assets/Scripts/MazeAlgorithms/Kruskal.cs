using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class Kruskal : AlgorithmBase
    {
        List<Set> sets;

        public override IEnumerator On(MazeGrid grid, Tester tester)
        {
            sets = new List<Set>();
            for (int y = 0; y < grid.rowCount; y++)
            {
                for (int x = 0; x < grid.columnCount; x++)
                {
                    sets.Add(new Set(grid[x, y]));
                }
            }

            List<Passage> passages = GeneratePassages(grid);
            
            OnDraw(grid);
            yield return new WaitForSeconds(tester.delayTime);
            
            while (sets.Count >= 2)
            {
                Passage passage = passages[Random.Range(0, passages.Count)];
                passages.Remove(passage);

                int setA = -1, setB = -1;
                for (int s = 0; s < sets.Count; s++)
                {
                    if (sets[s].IsInSet(passage.cellA)) setA = s;
                    if (sets[s].IsInSet(passage.cellB)) setB = s;
                    if (setA >= 0 && setB >= 0) break;
                }

                if (setA == setB)
                { // if both sets are in the same set, pick a new pair
                    Debug.Log(string.Format("found pair in same set ({0},{1}) & ({2},{3})", passage.cellA.column, passage.cellA.row, passage.cellB.column, passage.cellB.row));
                    continue;
                }
                else
                {
                    passage.cellA.Link(passage.cellB);
                    if (sets[setA].cells.Count > sets[setB].cells.Count)
                    {
                        foreach (Cell c in sets[setB].cells)
                        {
                            sets[setA].AddCell(c);
                        }
                        sets.RemoveAt(setB);
                    }
                    else
                    {
                        foreach (Cell c in sets[setA].cells)
                        {
                            sets[setB].AddCell(c);
                        }
                        sets.RemoveAt(setA);
                    }
                }

                
                OnDraw(grid);
                yield return new WaitForSeconds(tester.delayTime);
            }
            sets[0].colour = Color.white;
            OnComplete();
        }

        List<Passage> GeneratePassages(MazeGrid grid)
        {
            List<Passage> passages = new List<Passage>();

            for (int y = 0; y < grid.rowCount; y++)
            {
                for (int x = 0; x < grid.columnCount; x++)
                {
                    if (x > 0)
                        passages.Add(new Passage { cellA = grid[x, y], cellB = grid[x - 1, y] });
                    if (y > 0)
                        passages.Add(new Passage { cellA = grid[x, y], cellB = grid[x, y - 1] });
                }
            }

            return passages;
        }

        class Passage
        {
            public Cell cellA, cellB;
        }
    }
}
