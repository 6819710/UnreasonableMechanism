using NUnit.Framework;
using UnreasonableMechanismEngineCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnreasonableMechanismEngineCS.Tests
{
    [TestFixture()]
    public class VectorTests
    {
        [Test()]
        public void MagnitudeTest()
        {
            Vector test = new Vector(3, 2);

            Assert.AreEqual(Math.Sqrt(13), test.Magnitude, "Error: Magnitude of test vector should be the square route of 13.");
        }

        [Test()]
        public void PerpendicularVector2DTest()
        {
            Vector test = new Vector(3, 2);
            Vector perpendicular = test.PerpendicularVector2D();

            Assert.AreEqual(0, test.DotProduct(perpendicular), "Error: the dot product of orthoginal vectors should be 0.");
            Assert.AreEqual(test.Magnitude, perpendicular.Magnitude, "Error: the magnitude of orthoginal vectors should be the same.");
        }
    }
}