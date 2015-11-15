using System;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    /// <summary>
    /// GameMain Class
    /// </summary>
    public class GameMain
    {
        //Game Title and Version
        private static string Title = "Unreal Mechanism";
        private static double Version = 0.2;

        private static int tick = 0;

        /// <summary>
        /// Main Function, main acces point for the program
        /// </summary>
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow(Title + " v" + Version, 800, 600);

            //SwinGame.ToggleFullScreen();
            //SwinGame.ShowSwinGameSplashScreen();

            //Load the game assets
            GameResources.LoadResources();

            GameScores.Initalise();
            GameObjects.Initalise();

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested() && GameScores.Player != 0)
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.Grey);
                SwinGame.DrawRectangle(Color.DarkGray, true, 40, 20, 460, 560);


                SwinGame.DrawFramerate(0, 0);

                //Update Game
                GameObjects.ProcessEvents();

                RandomPlacementOfItems();

                tick++;
                //Draw onto the screen
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
                    rand.Next()%340 + 600,
                    rand.Next()%340 + 40,
                    rand.Next()%340 + 6000,
                    rand.Next()%340 + 60,
                    rand.Next()%140 + 40,
                    rand.Next()%140 + 20,
                    rand.Next()%140 + 40
            };

            for (int i = 0; i < 7; ++i)
            {
                if (tick % (trigger[i]) == 0 && tick > 0)
                {
                    GameObjects.AddItem(new ItemEntity(new Point2D((rand.Next() % (460 - GameResources.GameImage("Item" + items[i].ToString()).Width)) + 40, 50), items[i]));
                }
            }

            if(tick % (rand.Next() % 80 + 50) == 0 && tick > 0)
            {
                double x = rand.Next() % 460 + 40;
                double y = rand.Next() % 460 + 40;
                int n = rand.Next() % 24;
                for (int j = 0; j < n; ++j)
                {
                    GameObjects.AddBullet(new BulletEntity(new Point2D(x, y), new Velocity2D(2.8, 360 / n * j), 360 / n * j, BulletColour.Red, BulletType.Ring, null));
                }
            }
        }
    }
}