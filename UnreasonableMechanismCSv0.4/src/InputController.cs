using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using UnreasonableMechanismEngineCS;

using Vector = UnreasonableMechanismEngineCS.Vector;
using Colour = SwinGameSDK.Color;

namespace UnreasonableMechanismCS
{
    public static class InputController
    {
        /// <summary>
        /// Processes player movement.
        /// </summary>
        public static void ProcessPlayerMovement()
        {
            if(SwinGame.KeyDown(Settings.UP))
            {
                GameObjects.Player.Offset(new Vector(0, -2));
                if (GameObjects.Player.Grazebox.LessThanEqualY(20))
                {
                    GameObjects.Player.Offset(new Vector(0, GameObjects.Player.Grazebox.MaxDistanceLessThanY(21)));
                }
            }

            if(SwinGame.KeyDown(Settings.DOWN))
            {
                GameObjects.Player.Offset(new Vector(0, 2));
                if (GameObjects.Player.Grazebox.GreaterThanEqualY(580))
                {
                    GameObjects.Player.Offset(new Vector(0, -GameObjects.Player.Grazebox.MaxDistanceGreaterThanY(579)));
                }
            }

            if(SwinGame.KeyDown(Settings.LEFT))
            {
                GameObjects.Player.Offset(new Vector(-2, 0));
                if (GameObjects.Player.Grazebox.LessThanEqualX(40))
                {
                    GameObjects.Player.Offset(new Vector(GameObjects.Player.Grazebox.MaxDistanceLessThanX(41), 0));
                }
            }

            if(SwinGame.KeyDown(Settings.RIGHT))
            {
                GameObjects.Player.Offset(new Vector(2, 0));
                if (GameObjects.Player.Grazebox.GreaterThanEqualX(500))
                {
                    GameObjects.Player.Offset(new Vector(-GameObjects.Player.Grazebox.MaxDistanceGreaterThanX(499), 0));
                }
            }
        }
    }
}
