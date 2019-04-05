using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers
{
    public static class Random
    {
        static System.Random _rand;
        static System.Random random
        {
            get
            {
                if (_rand == null)
                    _rand = new System.Random();
                return _rand;
            }
        }

        public static float value
        {
            get
            {
                return (float)random.NextDouble();
            }
        }

        public static int Range(int maximum)
        {
            return (int)Math.Floor(value * maximum);
        }
        public static int Range(int minimum, int maximum)
        {
            float v = value * (maximum - minimum);
            return (int)Math.Floor(v) + minimum;
        }
        public static float Range(float maximum)
        {
            return value * maximum;
        }
        public static float Range(float minimum, float maximum)
        {
            float v = value * (maximum - minimum);
            return v + minimum;
        }
    }
}
