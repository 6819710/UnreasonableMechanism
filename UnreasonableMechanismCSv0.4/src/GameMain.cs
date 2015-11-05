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
            Point A = new Point(0, 0, 0);
            Point B = new Point(1, 0, 0);
            Point C = new Point(0.5, 0.866, 0);
            Point D = new Point(0.5, 0.433, 0.866);

            Polygon A1 = new Polygon(new Point[] { A * 50, B * 50, C * 50 });
            Polygon A2 = new Polygon(new Point[] { A * 50, B * 50, D * 50 });
            Polygon A3 = new Polygon(new Point[] { B * 50, C * 50, D * 50 });
            Polygon A4 = new Polygon(new Point[] { C * 50, A * 50, D * 50 });

            Polyhedron P1 = new Polyhedron(new Polygon[] { A1, A2, A3, A4 });

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

                P1.Offset(new UnreasonableMechanismEngineCS.Vector(1, 1));

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.Black);
                SwinGame.DrawFramerate(2, 2);

                P1.DrawFace(Color.Goldenrod);
                P1.DrawEdge(Color.DarkGoldenrod);

                P1.Center.Draw(Color.Red);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}