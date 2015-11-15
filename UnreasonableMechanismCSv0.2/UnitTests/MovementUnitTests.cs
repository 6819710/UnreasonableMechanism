using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnrealMechanismCS
{
    [TestFixture()]
    class MovementUnitTests
    {
        /// <summary>
        /// TestVectorMovement test, checks that objects move at a specified angle.
        /// </summary>
        [Test()]
        public void TestVectorMovement()
        {
            Velocity2D testVelosity = new Velocity2D(5.0, 36.86989764584402);
            Movement testMovement = new VectorMovement(testVelosity);
            Point2D testPoint = new Point2D(0.0, 0.0);

            double[] expectedX = new double[] { 4.0, 8.0, 12.0, 16.0, 20.0, 24.0, 28.0, 32.0, 36.0, 40.0 };
            double[] expectedY = new double[] { 3.0, 6.0, 9.0, 12.0, 15.0, 18.0, 21.0, 24.0, 27.0, 30.0 };

            for (int i = 0; i < 10; i++)
            {
                testMovement.Step();

                testPoint.X += testMovement.DeltaX;
                testPoint.Y += testMovement.DeltaY;

                Assert.AreEqual(expectedX[i], testPoint.X, "failure with x on iteration " + i);
                Assert.AreEqual(expectedY[i], testPoint.Y, "failure with y on iteration " + i);
            }
        }

        /// <summary>
        /// TestGravitationalMovement test, checks that objects move at a specified angle with a specified acceleration.
        /// </summary>
        [Test()]
        public void TestGravitationalMovement()
        {
            Acceleration2D testAcceleration = new Acceleration2D(new Vector2D(5.0, 0.0), 200.0);
            Velocity2D testVelosity = new Velocity2D(5.0, 36.86989764584402);
            Movement testMovement = new GravitationalMovement(testVelosity, testAcceleration);
            Point2D testPoint = new Point2D(0.0, 0.0);

            double[] expectedX = new double[] { 8.0, 20.0, 36.0, 56.0, 80.0, 108.0, 140.0, 176.0, 216.0, 260.0 };
            double[] expectedY = new double[] { 6.0, 15.0, 27.0, 42.0, 60.0, 81.0, 105.0, 132.0, 162.0, 195.0 };

            for (int i = 0; i < 10; i++)
            {
                testMovement.Step();

                testPoint.X += testMovement.DeltaX;
                testPoint.Y += testMovement.DeltaY;

                Assert.AreEqual(expectedX[i], testPoint.X, "failure with x on iteration " + i);
                Assert.AreEqual(expectedY[i], testPoint.Y, "failure with y on iteration " + i);
            }
        }
    }
}
