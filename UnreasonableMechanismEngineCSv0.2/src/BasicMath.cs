using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnreasonableMechanismEngineCS
{
    /// <summary>
    /// BasicMath provides common math formules.
    /// </summary>
    public static class BasicMath
    {
        /// <summary>
        /// Converts angles from degrees to radians.
        /// </summary>
        /// <param name="angle">Angle in degrees.</param>
        /// <returns>Angle in radians</returns>
        public static double ToRad(double angle)
        {
            return angle * (Math.PI / 180);
        }

        /// <summary>
        /// Converts angles fron radians to degrees.
        /// </summary>
        /// <param name="angle">Angle in radians.</param>
        /// <returns>Angle in degrees.</returns>
        public static double ToDeg(double angle)
        {
            return angle * (180 / Math.PI);
        }
    }
}
