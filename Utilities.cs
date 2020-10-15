using CG.Entities;

namespace CG.Utilities
{
    public static class GeoUtilities
    {
        public static readonly float epsilon = 0.00001f;

        public static bool CounterClockWise(float2 a, float2 b, float2 c)
        {
            /// cross product
            return ((c.x - a.x) * (b.y - a.y) - (c.y - a.y) * (b.x - a.x)) >= 0;
        }
    }

    public static class MathUtilities
    {
        public static int NearestPower2(int n)
        {
            if (n < 0)
            {
                return 0;
            }

            n |= n >> 1;
            n |= n >> 2;
            n |= n >> 4;
            n |= n >> 8;
            n |= n >> 16;
            n++;
            return n;
        }
    }
}
