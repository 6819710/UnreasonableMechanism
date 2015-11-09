using System;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    /// <summary>
    /// GameMain defines the main access point for the program.
    /// </summary>
    public class GameMain
    {
        private static string _title = "Unresonable Mechanism";
        private static double _version = 0.4;

        private static bool _splashFlag = false;

        private static uint _tick = 0;

        /// <summary>
        /// Main access point for the program.
        /// </summary>
        public static void Main()
        {
            //Open game window.
            SwinGame.OpenGraphicsWindow(_title + " v" + _version, 800, 600);

            //Load game assets.
            GameResources.LoadResources();
            GameObjects.Initalise();
            Settings.InitSettings();

            //Show SwinGame splash screen.
            if(_splashFlag)
            {
                SwinGame.ShowSwinGameSplashScreen();
            }

            //Run game loop.
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                SwinGame.ClearScreen(Color.Black);

                GameObjects.ProcessEvents();

                TestLevel.Step(_tick);

                //Clear the screen and draw the framerate
                
                SwinGame.DrawFramerate(2, 2);

                GameObjects.Draw();

                SwinGame.DrawBitmap(GameResources.GameImage("GameArea"), 0, 0);
                //SwinGame.DrawText("Score: " + GameScores.Score, Color.Black, 540, 40);
                //SwinGame.DrawText("Lives: " + GameScores.Player, Color.Black, 540, 60);
                //SwinGame.DrawText("Bombs: " + GameScores.Bomb, Color.Black, 540, 80);
                //SwinGame.DrawText("Power: " + GameScores.Power, Color.Black, 540, 120);
                //SwinGame.DrawText("Graze: " + GameScores.Graze, Color.Black, 540, 140);
                //SwinGame.DrawText("Bonus: " + GameScores.Bonus, Color.Black, 540, 160);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);

                _tick++;
            }

            //Free game assets.
            GameResources.FreeResources();
        }
    }
}