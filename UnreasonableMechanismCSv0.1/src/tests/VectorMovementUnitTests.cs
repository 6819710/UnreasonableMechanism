using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnrealMechanismCS
{
    [TestFixture()]
    public class VectorMovementUnitTests
    {
        /// <summary>
        /// TestStepConvertion, unit test to determine cartesian coordinate convertion.
        /// </summary>
        [Test()]
        public void TestStepConvertion()
        {
            VectorMovement testMovement = new VectorMovement(0.0, 1.0);

            //confirm inital values
            Assert.AreEqual(0.0, testMovement.DeltaX);
            Assert.AreEqual(0.0, testMovement.DeltaY);

            //confirm upated values
            testMovement.Step(0, 0);

            Assert.AreEqual(1.0, testMovement.DeltaX);
            Assert.AreEqual(0.0, testMovement.DeltaY);
        }

        /// <summary>
        /// TestChangeVectorDirection, unit test to determine a vectors direction can be set with a pair of cartesian coordinates (to and from)
        /// </summary>
        [Test()]
        public void TestChangeVectorDirection()
        {
            double xTo1 = 1.0;
            double yTo1 = 1.0;

            double xTo2 = 0.0;
            double yTo2 = 1.0;

            double xTo3 = 1.0;
            double yTo3 = 0.0;

            double xFrom = 0.0;
            double yFrom = 0.0;

            VectorMovement testMovement = new VectorMovement(0.0, 1.0);

            testMovement.SetDirection(xTo1, yTo1, xFrom, yFrom);
            Assert.AreEqual(45.0, testMovement.Direction);

            testMovement.SetDirection(xTo2, yTo2, xFrom, yFrom);
            Assert.AreEqual(90.0, testMovement.Direction);

            testMovement.SetDirection(xTo3, yTo3, xFrom, yFrom);
            Assert.AreEqual(0.0, testMovement.Direction);
        }
    }
}
