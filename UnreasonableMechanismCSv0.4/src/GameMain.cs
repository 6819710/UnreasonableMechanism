using System;
using SwinGameSDK;
using UnreasonableMechanismEngineCS;

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
            Polygon polygon = new Polygon(new Point[]
            {
                new Point(0, 0),
                new Point(20, 0),
                new Point(0, 80)
            }, new Point(100, 100));



            //Open game window.
            SwinGame.OpenGraphicsWindow(_title + " v" + _version, 800, 600);

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

                polygon.Offset(new UnreasonableMechanismEngineCS.Vector(1, 1));

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.Black);
                SwinGame.DrawFramerate(2, 2);
                
                polygon.DrawFace(Color.Goldenrod);
                polygon.DrawEdge(Color.DarkGoldenrod);

                polygon.Center.Draw(Color.Red);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}