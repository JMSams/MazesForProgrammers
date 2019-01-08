using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public abstract class AlgorithmBase
    {
        public abstract IEnumerator On(MazeGrid grid, Tester behaviour);
    }
}
