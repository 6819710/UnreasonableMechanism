using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private static double Version = 0.3;

        private static int tick = 0;

        /// <summary>
        /// Main Function, main acces point for the program
        /// </summary>
        public static void Main()
        {
            GameObjects.Polyhedra.Add(new A9(35));

            GameObjects.Polyhedra[0].Offset(new Vector(80, 80));
            //Open the game window
            SwinGame.OpenGraphicsWindow(Title + " v" + Version, 800, 600);

            //SwinGame.ToggleFullScreen();
            //SwinGame.ShowSwinGameSplashScreen();

            //Load the game assets
            GameResources.LoadResources();

            GameScores.Initalise();

            //Run the game loop
            while (false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                InputController.ProcessMovement();

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.Black);

                SwinGame.DrawFramerate(0, 0);

                if(SwinGame.KeyDown(KeyCode.vk_z))
                {
                    GameObjects.Polyhedra[0].Scale(1.01);
                }
                if (SwinGame.KeyDown(KeyCode.vk_x))
                {
                    GameObjects.Polyhedra[0].Scale(0.99);
                }


                //Update Game

                GameObjects.Draw(Color.Goldenrod, Color.DarkGoldenrod);

                tick++;

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }

            GameResources.FreeResources();
        }
    }
}