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
    public class BasicMathTests
    {
        [Test()]
        public void ToRadTest()
        {
            double[] degrees = new double[]
            {
                30,
                60,
                90,
                120,
                150,
                180,
                210,
                240,
                270,
                300,
                330,
                360
            };

            double[] radians = new double[]
            {
                Math.PI / 6,
                2 * Math.PI / 6,
                3 * Math.PI / 6,
                4 * Math.PI / 6,
                5 * Math.PI / 6,
                Math.PI,
                7 * Math.PI / 6,
                8 * Math.PI / 6,
                9 * Math.PI / 6,
                10 * Math.PI / 6,
                11 * Math.PI / 6,
                2 * Math.PI
            };

            for(int i = 0; i < 12; i++)
            {
                Assert.AreEqual(Math.Round(radians[i], 2), Math.Round(BasicMath.ToRad(degrees[i]), 2), "Error on test iteration " + i);
            }
        }

        [Test()]
        public void ToDegTest()
        {
            double[] degrees = new double[]
            {
                30,
                60,
                90,
                120,
                150,
                180,
                210,
                240,
                270,
                300,
                330,
                360
            };

            double[] radians = new double[]
            {
                Math.PI / 6,
                2 * Math.PI / 6,
                3 * Math.PI / 6,
                4 * Math.PI / 6,
                5 * Math.PI / 6,
                Math.PI,
                7 * Math.PI / 6,
                8 * Math.PI / 6,
                9 * Math.PI / 6,
                10 * Math.PI / 6,
                11 * Math.PI / 6,
                2 * Math.PI
            };

            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(Math.Round(degrees[i], 2), Math.Round(BasicMath.ToDeg(radians[i]), 2), "Error on test iteration " + i);
            }
        }
    }
}