using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public static class GameObjects
    {
        public static List<Polyhedron> Polyhedra = new List<Polyhedron>();

        public static void Draw(Color clrFace, Color clrEdge)
        {
            foreach (Polyhedron polyhedra in Polyhedra)
            {
                polyhedra.Draw(clrFace, clrEdge);
            }
        }
    }
}