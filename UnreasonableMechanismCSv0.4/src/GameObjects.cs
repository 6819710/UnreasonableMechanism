using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    public static class GameObjects
    {
        public static List<Polyhedron> Polyhedra = new List<Polyhedron>();

        public static void Draw(Color clrFace, Color clrEdge)
        {
            foreach(Polyhedron polyhedron in Polyhedra)
            {
                polyhedron.Draw(clrFace, clrEdge);
            }
        }
    }
}
