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
        public static void ProcessInput()
        {
            HandleMovement();
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
                    if(polyhedron.GreaterThanY(600))
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
                    if(polyhedron.LessThanX(0))
                    {
                        polyhedron.Offset(new UM.Vector(0, polyhedron.MaxDistanceLessThanX(0)));
                    }
                }
            }

            if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                foreach(Polyhedron polyhedron in GameObjects.Polyhedra)
                {
                    polyhedron.Offset(new UM.Vector(2, 0));
                    if(polyhedron.GreaterThanX(800))
                    {
                        polyhedron.Offset(new UM.Vector(0, polyhedron.MaxDistanceGreaterThanX(800)));
                    }
                }
            }
        }
    }
}
