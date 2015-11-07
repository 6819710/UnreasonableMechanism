﻿using System;
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

        public PlayerEntity(PlayerType playerType) : base(new Point(270, 430), InitBounding(new Point2D(270, 430), playerType), 1, playerType.ToString())
        {
            _playerType = playerType;
            _grazebox = InitGrazeBox(, playerType);
        }
    }
}