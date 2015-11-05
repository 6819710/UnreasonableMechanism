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

            Polygon A1 = new Polygon(new Point[] { A, B, C });
            Polygon A2 = new Polygon(new Point[] { A, B, D });
            Polygon A3 = new Polygon(new Point[] { B, C, D });
            Polygon A4 = new Polygon(new Point[] { C, A, D });

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

                if (SwinGame.KeyDown(KeyCode.vk_a))
                {
                    P1.RollX(-0.035, P1.Center);
                }

                if (SwinGame.KeyDown(KeyCode.vk_d))
                {
                    P1.RollX(0.035, P1.Center);
                }

                if (SwinGame.KeyDown(KeyCode.vk_w))
                {
                    P1.PitchY(0.035, P1.Center);
                }

                if (SwinGame.KeyDown(KeyCode.vk_s))
                {
                    P1.PitchY(-0.035, P1.Center);
                }

                if (SwinGame.KeyDown(KeyCode.vk_q))
                {
                    P1.YawZ(0.035, P1.Center);
                }

                if (SwinGame.KeyDown(KeyCode.vk_e))
                {
                    P1.YawZ(-0.035, P1.Center);
                }

                if (SwinGame.KeyDown(KeyCode.vk_z))
                {
                    P1.Scale(1.5, P1.Center);
                }

                if(SwinGame.KeyDown(KeyCode.vk_x))
                {
                    P1.Scale(0.75, P1.Center);
                }

                if (SwinGame.KeyDown(KeyCode.vk_UP))
                {
                    P1.Offset(new UnreasonableMechanismEngineCS.Vector(0, -1));
                }

                if (SwinGame.KeyDown(KeyCode.vk_DOWN))
                {
                    P1.Offset(new UnreasonableMechanismEngineCS.Vector(0, 1));
                    
                }

                if (SwinGame.KeyDown(KeyCode.vk_LEFT))
                {
                    P1.Offset(new UnreasonableMechanismEngineCS.Vector(-1, 0));
                }

                if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
                {
                    P1.Offset(new UnreasonableMechanismEngineCS.Vector(1, 0));
                }

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