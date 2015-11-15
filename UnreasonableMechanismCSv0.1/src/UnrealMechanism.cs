using System;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public class GameMain
    {
        private static string Title = "Unreal Mechanism";
        private static double Version = 0.1;

        private static int tick = 0;

        /// <summary>
        /// main
        /// the main entry point for the program
        /// </summary>
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow(Title + " v" + Version, 800, 600);

            GameResources.LoadResources();
            GameScores.Initalise();
            GameObjects.Player = new PlayerEntity(PlayerType.NarrowA);

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                RandomPlacementOfItems();

                SwinGame.ClearScreen(Color.Grey);
                SwinGame.DrawRectangle(Color.DarkGray, true, 40, 20, 460, 560);

                SwinGame.ProcessEvents();

                GameObjects.Player.ProcessEvents();

                foreach(ItemEntity item in GameObjects.Items)
                {
                    item.ProcessEvents();
                }

                SwinGame.DrawBitmap(GameResources.GameImage("GameArea"), 0, 0);
                SwinGame.DrawText("Score: " + GameScores.Score, Color.Black, 540, 40);
                SwinGame.DrawText("Lives: " + GameScores.Player, Color.Black, 540, 60);
                SwinGame.DrawText("Bombs: " + GameScores.Bomb , Color.Black, 540, 80);
                SwinGame.DrawText("Power: " + GameScores.Power, Color.Black, 540, 120);
                SwinGame.DrawText("Graze: " + GameScores.Graze, Color.Black, 540, 140);
                SwinGame.DrawText("Bonus: " + GameScores.Bonus, Color.Black, 540, 160);

                SwinGame.DrawFramerate(0, 0);

                tick++;

                SwinGame.RefreshScreen(60);
            }
            GameResources.FreeResources();
        }

        public static void RandomPlacementOfItems()
        {
            Random rand = new Random();

            ItemType[] items = new ItemType[]
            {
                ItemType.BigPower,
                ItemType.Bomb,
                ItemType.FullPower,
                ItemType.Life,
                ItemType.Point,
                ItemType.Power,
                ItemType.Star
            };

            int[] trigger = new int[]
            {
                rand.Next()%240 + 600,
                rand.Next()%240 + 40,
                rand.Next()%240 + 6000,
                rand.Next()%240 + 60,
                rand.Next()%40 + 40,
                rand.Next()%40 + 20,
                rand.Next()%40 + 40
            };

            for(int i = 0; i < 7; ++i)
            {
                if(tick % trigger[i] == 0)
                {
                    GameObjects.AddItem(new ItemEntity((rand.Next() % (460 - GameResources.GameImage("Item" + items[i].ToString()).Width)) + 40, 50, items[i]));
                }
            }
        }
    }
}