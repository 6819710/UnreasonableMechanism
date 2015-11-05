using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnreasonableMechanismEngineCS
{
    class P1:Polyhedron
    {
        private static List<Point> _vertices = new List<Point>(new Point[]
        {
            new Point(0, 0, 0),
            new Point(1, 0, 0),
            new Point(0.5, 0.866, 0),
            new Point(0.5, 0.433, 0.866)
        });

        private static Polygon[] _faces = new Polygon[]
        {
            new Polygon(new Point[] { _vertices[1], _vertices[2], _vertices[3] }),
            new Polygon(new Point[] { _vertices[1], _vertices[2], _vertices[4] }),
            new Polygon(new Point[] { _vertices[2], _vertices[3], _vertices[4] }),
            new Polygon(new Point[] { _vertices[3], _vertices[1], _vertices[4] })
        };

        public P1(double scale) : base(_faces)
        {
            base.Scale(scale);
        }

        public P1(double scale, Point location) : base(_faces, location)
        {
            base.Scale(scale);
        }
    }
}
