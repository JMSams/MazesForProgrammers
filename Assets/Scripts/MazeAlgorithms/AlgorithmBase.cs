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
        public delegate void AlgorithmCompleteCallbackDelegate();
        public delegate void AlgorithmDrawCallbackDelegate(MazeGrid grid, params Highlight[] highlights);

        public AlgorithmCompleteCallbackDelegate OnComplete;
        public AlgorithmDrawCallbackDelegate OnDraw;

        public abstract IEnumerator On(MazeGrid grid, Tester behaviour);
    }
}
