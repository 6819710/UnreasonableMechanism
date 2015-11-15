using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMechanismCS
{
    public class BulletEntity : Entity
    {
        //attributes
        private Colours _bulletColour;
        private BulletType _bulletType;
        private double _drawDirection;
        private VectorMovement _movement;

        //constructor
        /// <summary>
        /// BulletEntity, class constructor.
        /// </summary>
        /// <param name="x">X position of the bullet.</param>
        /// <param name="y">Y position of the bullet.</param>
        /// <param name="direction">Movement Direction of the bullet.</param>
        /// <param name="drawDirection">Draw Direction of the bullet.</param>
        /// <param name="colour">Colour of the bullet.</param>
        /// <param name="bulletType">Type of the bullet.</param>
        public BulletEntity(double x, double y, double direction, double drawDirection, Colours colour, BulletType bulletType) : base(x, y, new HitBox[] { new HitBox(x - (GameResources.GameImage(bulletType + colour.ToString()).Width / 2.0), y - (GameResources.GameImage(bulletType + colour.ToString()).Height / 2), GameResources.GameImage(bulletType + colour.ToString()).Width, GameResources.GameImage(bulletType + colour.ToString()).Height) }, 1, bulletType + colour.ToString())
        {
            _drawDirection = drawDirection;
            _bulletColour = colour;
            _bulletType = bulletType;

            _movement = new VectorMovement(direction, 1.0);

            switch(bulletType)
            {
                case BulletType.Beam:
                    _movement.Delta = 16.0;
                    break;

                case BulletType.BigStar:
                    _movement.Delta = 4.0;
                    break;

                case BulletType.Crystal:
                    _movement.Delta = 8.0;
                    break;

                case BulletType.Dart:
                    _movement.Delta = 8.0;
                    break;

                case BulletType.HugeSphere:
                    _movement.Delta = 5.0;
                    break;

                case BulletType.LargeSphere:
                    _movement.Delta = 6.0;
                    break;

                case BulletType.Palse:
                    _movement.Delta = 8.0;
                    break;

                case BulletType.Ring:
                    _movement.Delta = 8.0;
                    break;

                case BulletType.Seed:
                    _movement.Delta = 8.0;
                    break;

                case BulletType.Shere:
                    _movement.Delta = 7.0;
                    break;

                case BulletType.SmallRing:
                    _movement.Delta = 8.0;
                    break;

                case BulletType.SmallSphere:
                    _movement.Delta = 8.0;
                    break;

                case BulletType.Star:
                    _movement.Delta = 6.0;
                    break;
            }
        }

        //methods
        /// <summary>
        /// ProcessEvents, overide method.
        /// </summary>
        public override void ProcessEvents()
        {
            ProcessMovement();

            DrawEntity();

            Tick++;
        }

        /// <summary>
        /// ProcessMovement, overide method, determines bullet movement.
        /// </summary>
        public override void ProcessMovement()
        {
            _movement.Step();

            X += _movement.DeltaX;
            Y += _movement.DeltaY;

            foreach (HitBox hitBox in HitBoxes)
            {
                hitBox.X += _movement.DeltaX;
                hitBox.Y += _movement.DeltaY;
            }
        }

        //properties
        public VectorMovement Movement
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
    }
}
