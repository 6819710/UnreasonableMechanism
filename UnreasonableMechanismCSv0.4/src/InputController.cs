using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    public static class InputController
    {
        /// <summary>
        /// Processes user input.
        /// </summary>
        public static void ProcessInput()
        {
            HandleMovement();
            HandleYawPitchRoll();
            HandleScale();
        }

        private static void HandleMovement()
        {
            if (SwinGame.KeyDown(KeyCode.vk_UP))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.Offset(new UM.Vector(0, -2));
                    polyhedron.RollX(0.035, polyhedron.Center);
                    if(polyhedron.LessThanEqualY(0))
                    {
                        polyhedron.Offset(new UM.Vector(0, polyhedron.MaxDistanceLessThanY(0)));
                    }
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_DOWN))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.Offset(new UM.Vector(0, 2));
                    polyhedron.RollX(-0.035, polyhedron.Center);
                    if (polyhedron.GreaterThanY(600))
                    {
                        polyhedron.Offset(new UM.Vector(0, -polyhedron.MaxDistanceGreaterThanY(600)));
                    }
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.Offset(new UM.Vector(-2, 0));
                    polyhedron.PitchY(-0.035, polyhedron.Center);
                    if (polyhedron.LessThanX(0))
                    {
                        polyhedron.Offset(new UM.Vector(polyhedron.MaxDistanceLessThanX(0), 0));
                    }
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.Offset(new UM.Vector(2, 0));
                    polyhedron.PitchY(0.035, polyhedron.Center);
                    if (polyhedron.GreaterThanX(800))
                    {
                        polyhedron.Offset(new UM.Vector(-polyhedron.MaxDistanceGreaterThanX(800), 0));
                    }
                }
            }
        }

        private static void HandleYawPitchRoll()
        {
            if (SwinGame.KeyDown(KeyCode.vk_w))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.RollX(0.035, polyhedron.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_s))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.RollX(-0.035, polyhedron.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_a))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.PitchY(-0.035, polyhedron.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_d))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.PitchY(0.035, polyhedron.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_q))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.YawZ(0.035, polyhedron.Center);
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_e))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.YawZ(-0.035, polyhedron.Center);
                }
            }
        }

        public static void HandleScale()
        {
            if (SwinGame.KeyDown(KeyCode.vk_z))
            {
                foreach (Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.Scale(1.01, polyhedron.Center);
                    if(polyhedron.MaxDistanceLessThanX(polyhedron.Center.X) > 150)
                    {
                        polyhedron.Scale(0.99, polyhedron.Center);
                    }
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_x))
            {
                foreach (Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.Scale(0.99, polyhedron.Center);
                    if (polyhedron.MaxDistanceLessThanX(polyhedron.Center.X) < 20)
                    {
                        polyhedron.Scale(1.01, polyhedron.Center);
                    }
                }
            }
        }
    }
}
