using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnreasonableMechanismEngineCS;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// PlayerEntity is a child class of Game entity.
    /// </summary>
    public class PlayerEntity : GameEntity
    {
        private PlayerType _playerType;
        private Polygon _grazebox;

        private int _cannonMain;
        private int _cannonAux;
        private int _cooldown;

        /// <summary>
        /// Constructs Player in default position.
        /// </summary>
        /// <param name="playerType">Type of player.</param>
        public PlayerEntity(PlayerType playerType) : base(new Point(270, 430), null, 1)
        {
            _playerType = playerType;
            _grazebox = null;

            _cannonMain = 0;
            _cannonAux = 0;
            _cooldown = 0;
        }

        /// <summary>
        /// Readonly Property.
        /// </summary>
        private Polygon GrazeBox
        {
            get
            {
                return _grazebox;
            }
        }
    }
}