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

            GameObjects.DrawItems();
            GameObjects.DrawPlayer();

            SwinGame.DrawBitmap(GameResources.GameImage("GameArea"), 0, 0);
        }

        public override void Initalise()
        {
            
        }

        public override void ProvessEvents()
        {
            if(SwinGame.KeyTyped(Settings.PAUSE))
            {
                ScreenControler.SetScreen("PauseMenu");
            }

            if(Tick % (_rand.Next() % 140 + 20) == 0)
            {
                GameObjects.AddItem(new ItemEntity(new Point(_rand.Next() % (460 - GameResources.GameImage("Item" + ItemType.Power.ToString()).Width) + 40, 50), ItemType.Power));
            }

            GameObjects.ProcessItemEvents();
            GameObjects.Player.ProcessEvents();

            Tick++;
        }
    }
}