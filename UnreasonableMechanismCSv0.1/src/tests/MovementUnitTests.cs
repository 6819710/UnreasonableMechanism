using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnrealMechanismCS
{
    [TestFixture()]
    public class MovementUnitTests
    {
        /// <summary>
        /// TestVectorMovement, unit test to show object vector movement;
        /// </summary>
        [Test()]
        public void TestVectorMovement()
        {
            Movement testMovement = new VectorMovement(0.0, 1.0);

            testMovement.Step(0, 0);

            double x = 0;
            double y = 0;

            double[] expectedX = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            double[] expectedY = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };

            for (int i = 0; i < 10; i++)
            {
                testMovement.Step(0, 0);

                x += testMovement.DeltaX;
                y += testMovement.DeltaY;

                Assert.AreEqual(expectedX[i], x, "failure with x on iteration " + i);
                Assert.AreEqual(expectedY[i], y, "failure with y on iteration " + i);
            }
        }

        /// <summary>
        /// TestGravitationalMovement, unit test to show object gravitational movement;
        /// </summary>
        [Test()]
        public void TestGravitationalMovement()
        {
            //inital delta = 0, acceleration = 1 unit/tick^2, terminal velosity = 10 units/tick
            Movement testMovement = new GravitationalMovement(0.0, 0.0, 1.0, 0.0, 10.0, 0.0);

            testMovement.Step();

            double x = 0;
            double y = 0;

            double[] expectedX = new double[] { 2.0, 5.0, 9.0, 14.0, 20.0, 27.0, 35.0, 44.0, 54.0, 64.0 };
            double[] expectedY = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };

            for (int i = 0; i < 10; i++)
            {
                testMovement.Step();

                x += testMovement.DeltaX;
                y += testMovement.DeltaY;

                Assert.AreEqual(expectedX[i], x, "failure with x on iteration " + i);
                Assert.AreEqual(expectedY[i], y, "failure with y on iteration " + i);
            }
        }
    }
}
