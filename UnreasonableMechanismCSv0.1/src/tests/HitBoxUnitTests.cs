using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnrealMechanismCS
{
    [TestFixture()]
    public class HitBoxUnitTests
    {
        /// <summary>
        /// Test Hit Box Creation
        /// tests that a hitbox can be sucsessfully created
        /// </summary>
        [Test()]
        public void TestHitBoxCreation()
        {
            HitBox testHitBox = new HitBox(0, 0, 10, 10);

            Assert.IsInstanceOf<HitBox>(testHitBox);
        }

        /// <summary>
        /// Test Hit Box Collision
        /// tests that the correct parameter is returned when testing if Hit Boxes Collide
        /// </summary>
        [Test()]
        public void TestHitBoxCollision()
        {
            HitBox hitBoxA = new HitBox(0, 0, 10, 10);
            HitBox hitBoxB = new HitBox(5, 5, 10, 10);
            HitBox hitBoxC = new HitBox(12, 12, 10, 10);

            Assert.IsTrue(hitBoxA.Collides(hitBoxB), "hitBoxA should colide with hitBoxB");
            Assert.IsTrue(hitBoxB.Collides(hitBoxC), "hitBoxB should colide with hitBoxC");
            Assert.IsFalse(hitBoxA.Collides(hitBoxC), "hitBoxA should NOT colide with hitBoxC");
        }
    }
}
