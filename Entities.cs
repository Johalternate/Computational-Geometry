using System;
using System.Collections.Generic;
using System.Text;

using CG.Utilities;

namespace CG.Entities
{
    #region float2
    /// <summary>
    ///  Represents a 2D point or vector.
    /// </summary>
    public class float2
    {
        #region Static Properties

        #endregion
        
        #region Properties
        public float x;
        public float y;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new point or vector in 2D space.
        /// </summary>
        /// <param name="x">Horizontal component of the point or vector.</param>
        /// <param name="y">Vertical component of the point or vector.</param>
        public float2(float x, float y)
        {
            Set(x, y);
        }
        #endregion

        #region Public Methods
        public void Set(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Returns true ABC makes a CCW turn.
        /// </summary>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        /// <param name="c">Point C</param>
        /// <returns>True or False</returns>
        public static bool CounterClockWise(float2 a, float2 b, float2 c)
        {
            return ((c.x - a.x) * (b.y - a.y) - (c.y - a.y) * (b.x - a.x)) >= 0;
        }
        #endregion

        #region Operators
        public static bool operator ==(float2 a, float2 b)
        {
            float m = a.x - b.x;
            float n = a.y - b.y;

            bool mm = m < Utilities.Utilities.epsilon && m > -Utilities.Utilities.epsilon;
            bool nn = n < Utilities.Utilities.epsilon && m > -Utilities.Utilities.epsilon;

            return mm && nn;
        }

        public static bool operator !=(float2 a, float2 b)
        {
            return !(a == b);
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
    #endregion


}
