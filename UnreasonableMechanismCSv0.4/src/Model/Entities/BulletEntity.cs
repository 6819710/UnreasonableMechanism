using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;


namespace UnreasonableMechanismCS
{
    public class BulletEntity : Entity
    {
        private BulletColour _bulletColour;
        private BulletType _bulletType;
        private UM.Vector _trajectory;

        public BulletEntity(Point position, UM.Vector trajectory, BulletColour bulletColour, BulletType bulletType) : base(bulletColour.ToString() + bulletType.ToString(), InitBounding(position, bulletColour, bulletType), 1)
        {
            _trajectory = trajectory;
            _bulletColour = bulletColour;
            _bulletType = bulletType;
        }

        /// <summary>
        /// Processes bullet events.
        /// </summary>
        public override void ProcessEvents()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Processes bullet movement.
        /// </summary>
        public override void ProcessMovement()
        {
            throw new NotImplementedException();
        }

        private static Polygon InitBounding(Point position, BulletColour bulletColour, BulletType bulletType)
        {
            return new Polygon();
        }
    }
}