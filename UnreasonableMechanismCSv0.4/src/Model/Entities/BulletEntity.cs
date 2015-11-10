using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnreasonableMechanismEngineCS;
using SwinGameSDK;

using Colour = SwinGameSDK.Color;
using Vector = UnreasonableMechanismEngineCS.Vector;


namespace UnreasonableMechanismCS
{
    public class BulletEntity : Entity
    {
        private BulletColour _bulletColour;
        private BulletType _bulletType;
        private Movement _movement;
        private Entity _owner;
        private Vector _trajectory;

        /// <summary>
        /// Constructs bullet entity.
        /// </summary>
        /// <param name="bulletColour">Colour of bullet.</param>
        /// <param name="bulletType">Type of bullet.</param>
        /// <param name="owner">Owner of bullet.</param>
        /// <param name="position">Spawn position of bullet.</param>
        /// <param name="trajectory">Trajectory of bullet.</param>
        public BulletEntity(BulletColour bulletColour, BulletType bulletType, Entity owner, Point position, Vector trajectory) : base(bulletColour.ToString() + bulletType.ToString(), InitBounding(bulletType, position, trajectory), 1)
        {
            _bulletColour = bulletColour;
            _bulletType = bulletType;
            _owner = owner;
            _trajectory = trajectory;

            _movement = new Linear(trajectory.Unit * 5);
        }

        /// <summary>
        /// Processes bullet events.
        /// </summary>
        public override void ProcessEvents()
        {
            ProcessMovement();
        }

        /// <summary>
        /// Processes bullet movement.
        /// </summary>
        public override void ProcessMovement()
        {
            Hitbox.Offset(_movement.Velocity);
        }

        private static Polygon InitBounding(BulletType bulletType, Point position, Vector trajectory)
        {
            Point[] vertices = new Point[]
            {
                new Point(0, 0),
                new Point(15, 0),
                new Point(15, 15),
                new Point(0, 15)
            };
            
            switch (bulletType)
            {
                case BulletType.Beam:
                    vertices = new Point[]
                    {
                        new Point(0, 0),
                        new Point(15, 0),
                        new Point(15, 15),
                        new Point(0, 15)
                    };
                    break;

                case BulletType.BigStar:
                    vertices = new Point[]
                    {
                        new Point(2, 13),
                        new Point(11, 10),
                        new Point(15, 3),
                        new Point(16, 3),
                        new Point(20, 10),
                        new Point(29, 13),
                        new Point(24, 20),
                        new Point(23, 28),
                        new Point(16, 25),
                        new Point(15, 25),
                        new Point(8, 28),
                        new Point(6, 20)
                    };
                    break;

                case BulletType.Crystal:
                    vertices = new Point[]
                    {
                        new Point(4, 5),
                        new Point(7, 0),
                        new Point(8, 0),
                        new Point(11, 5),
                        new Point(11, 10),
                        new Point(8, 15),
                        new Point(7, 15),
                        new Point(4, 10)
                    };
                    break;

                case BulletType.Dart:
                    vertices = new Point[]
                    {
                        new Point(4, 7),
                        new Point(7, 0),
                        new Point(8, 0),
                        new Point(11, 7),
                        new Point(9, 8),
                        new Point(9, 9),
                        new Point(11, 11),
                        new Point(11, 13),
                        new Point(9, 15),
                        new Point(6, 15),
                        new Point(4, 13),
                        new Point(4, 11),
                        new Point(6, 9),
                        new Point(6, 8)
                    };
                    break;

                case BulletType.HugeSphere:
                    vertices = new Point[]
                    {
                        new Point(7, 27),
                        new Point(10, 19),
                        new Point(14, 14),
                        new Point(19, 10),
                        new Point(27, 7),
                        new Point(36, 7),
                        new Point(44, 10),
                        new Point(49, 14),
                        new Point(53, 19),
                        new Point(56, 27),
                        new Point(56, 36),
                        new Point(53, 44),
                        new Point(49, 49),
                        new Point(44, 53),
                        new Point(36, 56),
                        new Point(27, 56),
                        new Point(19, 53),
                        new Point(14, 49),
                        new Point(10, 44),
                        new Point(7, 36)
                    };
                    break;

                case BulletType.LargeSphere:
                    vertices = new Point[]
                    {
                        new Point(3, 13),
                        new Point(5, 8),
                        new Point(8, 5),
                        new Point(13, 3),
                        new Point(18, 3),
                        new Point(23, 5),
                        new Point(26, 8),
                        new Point(28, 13),
                        new Point(28, 18),
                        new Point(26, 23),
                        new Point(23, 26),
                        new Point(18, 28),
                        new Point(13, 28),
                        new Point(8, 26),
                        new Point(5, 23),
                        new Point(3, 18)
                    };
                    break;

                case BulletType.Palse:
                    vertices = new Point[]
                    {
                        new Point(0, 13),
                        new Point(3, 6),
                        new Point(7, 2),
                        new Point(8, 2),
                        new Point(12, 6),
                        new Point(15, 13),
                        new Point(13, 15),
                        new Point(11, 9),
                        new Point(10, 13),
                        new Point(8, 15),
                        new Point(7, 15),
                        new Point(5, 13),
                        new Point(4, 9),
                        new Point(2, 15)
                    };
                    break;

                case BulletType.Ring:
                    vertices = new Point[]
                    {
                        new Point(0, 6),
                        new Point(2, 2),
                        new Point(6, 0),
                        new Point(9, 0),
                        new Point(13, 2),
                        new Point(15, 6),
                        new Point(15, 9),
                        new Point(13, 13),
                        new Point(9, 15),
                        new Point(6, 15),
                        new Point(2, 13),
                        new Point(0, 9)
                    };
                    break;

                case BulletType.Seed:
                    vertices = new Point[]
                    {
                        new Point(4, 6),
                        new Point(5, 3),
                        new Point(7, 1),
                        new Point(8, 1),
                        new Point(10, 3),
                        new Point(11, 6),
                        new Point(11, 9),
                        new Point(10, 12),
                        new Point(8, 14),
                        new Point(7, 14),
                        new Point(5, 12),
                        new Point(4, 9)
                    };
                    break;

                case BulletType.Shere:
                    vertices = new Point[]
                    {
                        new Point(1, 6),
                        new Point(3, 3),
                        new Point(6, 1),
                        new Point(9, 1),
                        new Point(12, 3),
                        new Point(14, 6),
                        new Point(14, 9),
                        new Point(12, 12),
                        new Point(9, 14),
                        new Point(6, 14),
                        new Point(3, 12),
                        new Point(1, 9)
                    };
                    break;

                case BulletType.SmallRing:
                    vertices = new Point[]
                    {
                        new Point(0, 4),
                        new Point(1, 1),
                        new Point(4, 0),
                        new Point(7, 0),
                        new Point(10, 1),
                        new Point(11, 4),
                        new Point(11, 7),
                        new Point(10, 10),
                        new Point(7, 11),
                        new Point(4, 11),
                        new Point(1, 10),
                        new Point(0, 7)
                    };
                    break;

                case BulletType.SmallSphere:
                    vertices = new Point[]
                    {
                        new Point(1, 4),
                        new Point(4, 1),
                        new Point(7, 1),
                        new Point(10, 4),
                        new Point(10, 7),
                        new Point(7, 10),
                        new Point(4, 10),
                        new Point(1, 7)
                    };
                    break;

                case BulletType.Star:
                    vertices = new Point[]
                    {
                        new Point(1, 6),
                        new Point(5, 5),
                        new Point(7, 2),
                        new Point(8, 2),
                        new Point(10, 5),
                        new Point(14, 6),
                        new Point(11, 10),
                        new Point(11, 14),
                        new Point(8, 12),
                        new Point(7, 12),
                        new Point(4, 14),
                        new Point(4, 10)
                    };
                    break;
            }

            Polygon bounding = new Polygon(vertices, position);
            bounding.YawZ(trajectory.Phi, bounding.Middle);

            return bounding;
        }
    }
}