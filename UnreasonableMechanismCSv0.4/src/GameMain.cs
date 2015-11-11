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

        /// <summary>
        /// Main access point for the program.
        /// </summary>
        public static void Main()
        {
            //Open game window.
            SwinGame.OpenGraphicsWindow(_title + " v" + _version, 800, 600);

            //Load game assets.
            GameResources.LoadResources();
            GameObjects.LoadGameOjects();

            //Initaliase game assets.
            ScreenControler.SetScreen("StartupMenu");
            ScreenControler.Initalise();
            Settings.InitSettings();
            GameScores.InitForNewGame();

            //Show SwinGame splash screen.
            if(_splashFlag)
            {
                SwinGame.ToggleFullScreen();
                SwinGame.ShowSwinGameSplashScreen();
            }

            //Run game loop.
            while (!SwinGame.WindowCloseRequested() && !Settings.EXIT)
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                ScreenControler.Screen.ProvessEvents();

                //Draw Game
                ScreenControler.Screen.Draw();
                SwinGame.RefreshScreen(60);
            }

            //Free game assets.
            GameResources.FreeResources();
        }
    }
}