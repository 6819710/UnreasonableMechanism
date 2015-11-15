using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismEngineCS
{
    /// <summary>
    /// Convert is a Static Class containing definitions for convertion methods.
    /// </summary>
    public static class Convert
    {
        /// <summary>
        /// Converts Degrees to Radians.
        /// </summary>
        /// <param name="angle">Angle in Degrees.</param>
        /// <returns>Angle in Radians.</returns>
        public static double DegToRad(double angle)
        {
            return angle * (Math.PI / 180.0);
        }

        /// <summary>
        /// Converts Radians to Degrees.
        /// </summary>
        /// <param name="angle">Angle in Radians.</param>
        /// <returns>Angle in Degrees.</returns>
        public static double RadToDeg(double angle)
        {
            return angle * (Math.PI / 180.0);
        }
    }
}