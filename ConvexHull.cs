using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using CG.Entities;
using CG.Utilities;

namespace CG
{
    class ConvexHull : IPolygon
    {
        public float2[] Vertices { get; private set; }

        public ConvexHull(float2[] points)
        {
            if (points.Length < 3)
            {
                throw new System.ArgumentException("A polygon need at least 3 points.", "points");
            }

            // 1. Sort the points by x-coordinate
            float2[] orderedPoints = points.OrderBy(p => p.x).ThenBy(p => p.y).ToArray();

            // 2. put the points p(1) and p(2) in a list *Upper Hull* with p1 as the first point
            List<float2> upperHull = new List<float2>();
            upperHull.Add(orderedPoints[0]);
            upperHull.Add(orderedPoints[1]);

            // 3. For i == 3 to n
            for (int i = 2; i < orderedPoints.Length; i++)
            {
                // 4. Append p(i) to *Upper Hull*
                upperHull.Add(orderedPoints[i]);

                // 5. while *Upper Hull* contains more than 2 points and the
                // last three points in *Upper Hull* do not make a right turn
                while (upperHull.Count > 2 && GeoUtilities.CounterClockWise(upperHull[upperHull.Count - 1], upperHull[upperHull.Count - 2], upperHull[upperHull.Count - 3]))
                {
                    // 6. do Delete the middle of the last three points from *Lower Hull*.
                    upperHull.RemoveAt(upperHull.Count - 2);
                }
            }
            // 7. Put the points p(n) and p(n-1) in a *Lower Hull* list with p(n) as the first point.
            List<float2> lowerHull = new List<float2>();
            lowerHull.Add(orderedPoints[orderedPoints.Length - 1]);
            lowerHull.Add(orderedPoints[orderedPoints.Length - 2]);

            // 8. For i == n-3 to 1
            for (int i = orderedPoints.Length - 3; i >= 0; i--)
            {
                // 9. Append p(i) to *Lower Hull*
                lowerHull.Add(orderedPoints[i]);

                // 10. While *Lower Hull* contains more than 2 points and the
                // Las three points in *Lower Hull* do not make a right turn
                while (lowerHull.Count > 2 && CounterClockWise(lowerHull[lowerHull.Count - 1], lowerHull[lowerHull.Count - 2], lowerHull[lowerHull.Count - 3]))
                {
                    // 11. do Delete the middle of the last three points from *Lower Hull*.
                    lowerHull.RemoveAt(lowerHull.Count - 2);
                }
            }

            // 12. Remothe the first and the last point from *Lower Hull* to avoid 
            // duplication of the points where the Upper and Lower Hull meet
            lowerHull.RemoveAt(0);
            lowerHull.RemoveAt(lowerHull.Count - 1);

            // 13. Append *Lower Hull* to *Upper Hull* and call the resulting list *Hull*
            upperHull.AddRange(lowerHull);

            Vertices = upperHull.ToArray();
        }
    }

    
}
