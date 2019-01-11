using System;

namespace Mazes_for_Programmers
{
    [Flags]
    public enum Directions
    {
        nill    = 0,
        north   = 1,
        east    = 2,
        south   = 4,
        west    = 8
    }
}