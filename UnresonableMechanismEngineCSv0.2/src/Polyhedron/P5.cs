using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnreasonableMechanismEngineCS
{
    public class P5:Polyhedron
    {
        private static List<Point> _vertices = new List<Point>(new Point[]
        {
            new Point(0, 0, 0),
            new Point(1, 0, 0),
            new Point(1, 1, 0),
            new Point(0, 1, 0),
            new Point(0, 0, 1),
            new Point(1, 0, 1),
            new Point(1, 1, 1),
            new Point(0, 1, 1),
        });

        private static Polygon[] _faces = new Polygon[]
        {
            new Polygon(new Point[] { _vertices[0], _vertices[1], _vertices[2], _vertices[3] }),
            new Polygon(new Point[] { _vertices[0], _vertices[4], _vertices[5], _vertices[1] }),
            new Polygon(new Point[] { _vertices[1], _vertices[5], _vertices[6], _vertices[2] }),
            new Polygon(new Point[] { _vertices[2], _vertices[6], _vertices[7], _vertices[3] }),
            new Polygon(new Point[] { _vertices[3], _vertices[7], _vertices[4], _vertices[1] }),
            new Polygon(new Point[] { _vertices[5], _vertices[4], _vertices[7], _vertices[6] }),
        };

        public P5(double scale) : base(_faces)
        {
            base.Scale(scale);
        }

        public P5(double scale, Point location) : base(_faces, location)
        {
            base.Scale(scale);
        }
    }
}
