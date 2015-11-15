using System;

namespace UnrealMechanismCS
{
    public static class Mathematics
    {
        /// <summary>
        /// Converts Angles from Degrees to Radians
        /// </summary>
        /// <param name="value">Angle in Degrees</param>
        /// <returns>Angle in Radians</returns>
        public static double ToRad(double value)
        {
            return value * (Math.PI / 180);
        }

        /// <summary>
        /// Converts Angles from Radians to Degrees
        /// </summary>
        /// <param name="value">Angle in Radians</param>
        /// <returns>Angle in Degrees</returns>
        public static double ToDeg(double value)
        {
            return value * (180 / Math.PI);
        }
    }
}