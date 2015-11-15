using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public static class InputController
    {
        public static void ProcessMovement()
        {
            if(SwinGame.KeyDown(KeyCode.vk_UP))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.Offset(new Vector(0, -2, 0));
                    if (poly.LessThanY(0))
                    {
                        poly.Offset(new Vector(0, poly.MaxDistanceLessThanY(0), 0));
                    }
                    //poly.RollX(0.035, poly.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_DOWN))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.Offset(new Vector(0, 2, 0));
                    if (poly.GreaterThanY(600))
                    {
                        poly.Offset(new Vector(0, -poly.MaxDistanceGreaterThanY(600), 0));
                    }
                    //poly.RollX(-0.035, poly.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.Offset(new Vector(-2, 0, 0));
                    if (poly.LessThanX(0))
                    {
                        poly.Offset(new Vector(poly.MaxDistanceLessThanX(0), 0, 0));
                    }
                    //poly.PitchY(-0.035, poly.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.Offset(new Vector(2, 0, 0));
                    if(poly.GreaterThanX(800))
                    {
                        poly.Offset(new Vector(-poly.MaxDistanceGreaterThanX(800), 0, 0));
                    }
                    //poly.PitchY(0.035, poly.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_w))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.PitchAboutCenter(1);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_s))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.PitchAboutCenter(-1);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_a))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.YawAboutCenter(1);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_d))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.YawAboutCenter(-1);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_q))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.RollAboutCenter(1);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_e))
            {
                foreach (Polyhedron poly in GameObjects.Polyhedra)
                {
                    poly.RollAboutCenter(-1);
                }
            }

        }
    }
}