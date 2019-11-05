using System.Collections;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public abstract class AlgorithmBase
    {
        public delegate void AlgorithmCompleteCallbackDelegate();
        public delegate void AlgorithmDrawCallbackDelegate(MazeGrid grid);

        public AlgorithmCompleteCallbackDelegate OnComplete;
        public AlgorithmDrawCallbackDelegate OnDraw;

        public abstract IEnumerator On(MazeGrid grid, Tester behaviour);
    }
}
