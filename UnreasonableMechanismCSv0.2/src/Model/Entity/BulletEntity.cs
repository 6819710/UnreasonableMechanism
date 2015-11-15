using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMechanismCS
{
    /// <summary>
    /// BulletEntity Class, Base Class for bullets.
    /// </summary>
    public class BulletEntity : Entity
    {
        //details for drawing
        private BulletColour _bulletColour;
        private BulletType _bulletType;
        private double _drawDirection;

        //parameters
        private Movement _movement;
        private Entity _owner;

        /// <summary>
        /// Constructor for bullet class.
        /// </summary>
        /// <param name="position">Inital position of the bullet.</param>
        /// <param name="velocity">Inital velosity of the bullet.</param>
        /// <param name="drawDirection">Direction to draw the bullet.</param>
        /// <param name="bulletColour">Colour of the bullet</param>
        /// <param name="bulletType">Type of the bullet</param>
        /// <param name="owner">Owner of the bullet</param>
        public BulletEntity(Point2D position, Velocity2D velocity, double drawDirection, BulletColour bulletColour, BulletType bulletType, Entity owner) : base(position, InitaliseBounding(position, bulletColour, bulletType), 1, bulletType.ToString() + bulletColour.ToString())
        {
            _owner = owner;
            _drawDirection = drawDirection;
            _bulletColour = bulletColour;
            _bulletType = bulletType;

            _movement = new VectorMovement(velocity);
        }

        public Movement Movement
        {
            get
            {
                return _movement;
            }

            set
            {
                _movement = value;
            }
        }

        public Entity Owner
        {
            get
            {
                return _owner;
            }

            set
            {
                _owner = value;
            }
        }

        public override void ProcessEvents()
        {
            ProcessMovement();

            DrawEntity();

            Tick++;
        }

        public override void ProcessMovement()
        {
            _movement.Step();

            X += _movement.DeltaX;
            Y += _movement.DeltaY;

            foreach (Bounding hitBox in Hitboxes)
            {
                hitBox.Offset(_movement.Delta);
            }
        }

        public static List<Bounding> InitaliseBounding(Point2D point, BulletColour bulletColour, BulletType bulletType)
        {
            List<Bounding> result = new List<Bounding>();

            result.Add(new Bounding(new Point2D[]
            {
                new Point2D(point.X + (GameResources.GameImage(bulletType.ToString() + bulletColour.ToString()).Width / 2), point.Y - (GameResources.GameImage(bulletType.ToString() + bulletColour.ToString()).Height / 2)),
                new Point2D(point.X - (GameResources.GameImage(bulletType.ToString() + bulletColour.ToString()).Width / 2), point.Y - (GameResources.GameImage(bulletType.ToString() + bulletColour.ToString()).Height / 2)),
                new Point2D(point.X - (GameResources.GameImage(bulletType.ToString() + bulletColour.ToString()).Width / 2), point.Y + (GameResources.GameImage(bulletType.ToString() + bulletColour.ToString()).Height / 2)),
                new Point2D(point.X + (GameResources.GameImage(bulletType.ToString() + bulletColour.ToString()).Width / 2), point.Y + (GameResources.GameImage(bulletType.ToString() + bulletColour.ToString()).Height / 2))
            }));

            return result;
        }
    }
}