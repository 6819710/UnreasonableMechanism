using System;
using SwinGameSDK;

namespace UnreasonableMechanismCSv0x5
{
    /// <summary>
    /// GameMain is a class defining main entry point for program.
    /// </summary>
    public class GameMain
    {
        private static string _title = "Unresonable Mechanism";
        private static double _version = 0.4;

        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0, 0);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}