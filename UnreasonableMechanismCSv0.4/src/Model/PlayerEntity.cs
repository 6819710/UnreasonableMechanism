using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;
using UnreasonableMechanismEngineCS;

using Vector = UnreasonableMechanismEngineCS.Vector;
using Colour = SwinGameSDK.Color;


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
            _grazebox = InitGrazeBox(Hitbox.Centroid, playerType);
        }

        /// <summary>
        /// Property: Grazebox.
        /// </summary>
        public Polygon Grazebox
        {
            get
            {
                return _grazebox;
            }

            set
            {
                _grazebox = value;
            }
        }

        /// <summary>
        /// Draws the player.
        /// </summary>
        public override void Draw()
        {
            base.Draw();

            if(Settings.SHOWHITBOX)
            {
                DrawGrazebox(Colour.Orange);
            }
        }

        /// <summary>
        /// Draws player graze box.
        /// </summary>
        /// <param name="clr">Colour to draw graze box.</param>
        public void DrawGrazebox(Colour clr)
        {
            _grazebox.DrawEdge(clr);
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
            Point[] vertices = new Point[]
            {
                new Point(3,1),
                new Point(9,1),
                new Point(14,4),
                new Point(15,4),
                new Point(20,1),
                new Point(26,1),
                new Point(26,6),
                new Point(24,9),
                new Point(27,12),
                new Point(27,17),
                new Point(25,19),
                new Point(25,23),
                new Point(24,24),
                new Point(22,24),
                new Point(20,26),
                new Point(20,27),
                new Point(22,29),
                new Point(22,31),
                new Point(19,34),
                new Point(19,36),
                new Point(18,37),
                new Point(17,37),
                new Point(15,35),
                new Point(14,35),
                new Point(12,37),
                new Point(11,37),
                new Point(10,36),
                new Point(10,34),
                new Point(7,31),
                new Point(7,29),
                new Point(9,27),
                new Point(9,26),
                new Point(7,24),
                new Point(5,24),
                new Point(1,20),
                new Point(1,13),
                new Point(5,9),
                new Point(3,6)
            };

            return new Polygon(vertices, new Point(270, 430));
        }

        public override void ProcessEvents()
        {
            ProcessMovement();
        }

        public override void ProcessMovement()
        {
            InputController.ProcessPlayerMovement();
        }
    }
}