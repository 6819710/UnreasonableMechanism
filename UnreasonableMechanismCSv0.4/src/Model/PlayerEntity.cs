using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;


namespace UnreasonableMechanismCS
{
    /// <summary>
    /// Defines the player charicter
    /// </summary>
    public class PlayerEntity : Entity
    {
        private PlayerType _playerType;
        private Polygon _grazebox;

        /// <summary>
        /// Constructs a new player in the defult position.
        /// </summary>
        /// <param name="playerType">Type of player selected.</param>
        public PlayerEntity(PlayerType playerType) : base("Player" + playerType.ToString(), InitBounding(new Point(270, 430), playerType), 1)
        {
            _playerType = playerType;
            _grazebox = InitGrazeBox(Hitbox.Center, playerType);
        }

        private static Polygon InitBounding(Point position, PlayerType playerType)
        {
            Point[] vertices = new Point[]
            {
                new Point(0,0),
                new Point(3,0),
                new Point(5,2),
                new Point(6,2),
                new Point(8,0),
                new Point(11,0),
                new Point(11,3),
                new Point(10,4),
                new Point(11,5),
                new Point(11,10),
                new Point(8,13),
                new Point(9,14),
                new Point(9,15),
                new Point(7,17),
                new Point(4,17),
                new Point(2,15),
                new Point(2,14),
                new Point(3,13),
                new Point(0,10),
                new Point(0,5),
                new Point(1,4),
                new Point(0,3)
            };

            return new Polygon(vertices, new Point(270, 430));
        }

        private static Polygon InitGrazeBox(Point position, PlayerType playerType)
        {
            return new Polygon(new Point[] { new Point(0, 0) }, new Point(270, 430));
        }

        public override void ProcessEvents()
        {
            throw new NotImplementedException();
        }

        public override void ProcessMovement()
        {
            throw new NotImplementedException();
        }
    }
}