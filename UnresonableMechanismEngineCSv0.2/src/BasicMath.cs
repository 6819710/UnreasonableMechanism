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
        public static double ToRad(double angle)
        {
            return angle * (Math.PI / 180);
        }
    }
}
