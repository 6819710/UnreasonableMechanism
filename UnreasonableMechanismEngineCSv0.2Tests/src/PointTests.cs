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
    public class PointTests
    {
        [Test()]
        public void PointTest()
        {
            Point testPoint = new Point(2, 3, 4);

            Assert.IsInstanceOf<Point>(testPoint, "Error in type.");

            Assert.AreEqual(2, testPoint.X, "Error in x assignment.");
            Assert.AreEqual(3, testPoint.Y, "Error in y assignment.");
            Assert.AreEqual(4, testPoint.Z, "Error in z assignment.");
        }

        [Test()]
        public void PointTest1()
        {
            Point testPoint = new Point(2, 3);

            Assert.IsInstanceOf<Point>(testPoint, "Error in type.");

            Assert.AreEqual(2, testPoint.X, "Error in x assignment.");
            Assert.AreEqual(3, testPoint.Y, "Error in y assignment.");
            Assert.AreEqual(0, testPoint.Z, "Error in z assignment.");
        }

        [Test()]
        public void DifferenceByTest()
        {
            Point a = new Point(2, 3, 4);
            Point b = new Point(3, 6, 9);

            Assert.AreEqual(new Point(-1, -3, -5), a.DifferenceBy(b), "Error in a - b");

            Assert.AreEqual(new Point(1, 3, 5), b.DifferenceBy(a), "Error in b - a");
        }

        [Test()]
        public void DifferenceFromTest()
        {
            Point a = new Point(2, 3, 4);
            Point b = new Point(3, 6, 9);

            Assert.AreEqual(new Point(-1, -3, -5), b.DifferenceFrom(a), "Error in a - b");

            Assert.AreEqual(new Point(1, 3, 5), a.DifferenceFrom(b), "Error in b - a");
        }

        [Test()]
        public void DifferenceByTest1()
        {
            Point a = new Point(2, 3, 4);

            Assert.AreEqual(new Point(1, 2, 3), a.DifferenceBy(1), "Error in a - 1");
        }

        [Test()]
        public void DifferenceFromTest1()
        {
            Point a = new Point(2, 3, 4);

            Assert.AreEqual(new Point(-1, -2, -3), a.DifferenceFrom(1), "Error in 1 - a");
        }

        [Test()]
        public void DifferenceByXTest()
        {
            Point a = new Point(2, 3, 4);
            Point b = new Point(3, 6, 9);

            Assert.AreEqual(-1, a.DifferenceByX(b), "error in a.x - b.x");
            Assert.AreEqual(1, b.DifferenceByX(a), "error in b.x - a.x");
        }

        [Test()]
        public void DifferenceFromXTest()
        {
            Point a = new Point(2, 3, 4);
            Point b = new Point(3, 6, 9);

            Assert.AreEqual(-1, b.DifferenceFromX(a), "error in a.x - b.x");
            Assert.AreEqual(1, a.DifferenceFromX(b), "error in b.x - a.x");
        }

        [Test()]
        public void DifferenceByXTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceFromXTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceByYTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceFromYTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceByYTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceFromYTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceByZTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceFromZTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceByZTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void DifferenceFromZTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void DrawTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void EqualsTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetHashCodeTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void OffsetTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductInXTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductInXTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductInYTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductInYTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductInZTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductInZTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientByTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientFromTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientByTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientFromTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientByXTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientFromXTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientByXTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientFromXTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientByYTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientFromYTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientByYTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientFromYTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientByZTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientFromZTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientByZTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void QuotientFromZTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void SumTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SumTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void SumInXTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SumInXTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void SumInYTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SumInYTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void SumInZTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void SumInZTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ToVectorTest()
        {
            Assert.Fail();
        }
    }
}