using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public static class GameTools
    {
        /// <summary>
        /// CleanAngle, sets the direction between -180.0 - +180.0
        /// </summary>
        /// <param name="direction">direction to clean</param>
        /// <returns>clean direction</returns>
        public static double CleanAngle(double angle)
        {
            while (angle < -180.0)
            {
                angle += 360.0;
            }

            while (angle > 180.0)
            {
                angle -= 360.0;
            }

            return angle;
        }

        /// <summary>
        /// GetDifferenceBetweenAngles, caclualtes the difference between angles.
        /// </summary>
        /// <param name="a">first angle</param>
        /// <param name="b">second angle</param>
        /// <returns>the difference between the angles.</returns>
        public static double GetDifferenceBetweenAngles(double a, double b)
        {
            return CleanAngle(b - a);
        }
    }
}
