using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnrealMechanismCS
{
    [TestFixture()]
    public class GameToolsUnitTests
    {
        [Test()]
        public void TestCleanDirection()
        {
            double test1 = 450.0;
            double test2 = -270.0;

            Assert.AreEqual(90.0, GameTools.CleanAngle(test1));
            Assert.AreEqual(90.0, GameTools.CleanAngle(test2));
        }

        [Test()]
        public void TestGetDifferenceInAngles()
        {
            double testAngleOne = 90.0;
            double testAngleTwo = 0.0;
            double testAngleThree = 45.0;

            Assert.AreEqual(-90.0, GameTools.GetDifferenceBetweenAngles(testAngleOne, testAngleTwo));
            Assert.AreEqual(-45.0, GameTools.GetDifferenceBetweenAngles(testAngleOne, testAngleThree));
            Assert.AreEqual(90.0, GameTools.GetDifferenceBetweenAngles(testAngleTwo, testAngleOne));
            Assert.AreEqual(45.0, GameTools.GetDifferenceBetweenAngles(testAngleTwo, testAngleThree));
            Assert.AreEqual(45.0, GameTools.GetDifferenceBetweenAngles(testAngleThree, testAngleOne));
            Assert.AreEqual(-45.0, GameTools.GetDifferenceBetweenAngles(testAngleThree, testAngleTwo));
        }
    }
}
