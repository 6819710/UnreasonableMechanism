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
    public class TestLevel : Screen
    {
        private Random _rand;

        public TestLevel()
        {
            _rand = new Random();
        }

        public override void Draw()
        {
            SwinGame.ClearScreen(Color.DarkSlateGray);

            GameObjects.DrawPlayer();

            SwinGame.DrawBitmap(GameResources.GameImage("GameArea"), 0, 0);
        }

        public override void Initalise()
        {
            
        }

        public override void ProvessEvents()
        {
            GameObjects.Player.ProcessEvents();
        }
    }
}