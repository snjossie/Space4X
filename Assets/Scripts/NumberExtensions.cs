using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class NumberExtensions
    {
        public static bool IsBetweenIncludeLimits(this float value, float min, float max)
        {
            return min <= value && value <= max;
        }
    }
}
