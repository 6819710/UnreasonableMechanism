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
        public PlayerEntity(PlayerType playerType) : base(new Point(270, 430), InitBounding(new Point(270, 430), playerType), 1, playerType.ToString())
        {
            _playerType = playerType;
            _grazebox = InitGrazeBox(Position, playerType);
        }

        private static Polygon InitBounding(Point position, PlayerType playerType)
        {
            return new Polygon();
        }

        private static Polygon InitGrazeBox(Point position, PlayerType playerType)
        {
            return new Polygon();
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