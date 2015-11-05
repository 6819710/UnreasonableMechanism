using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnreasonableMechanismEngineCS
{
    public class P1:Polyhedron
    {
        private static List<Point> _vertices = new List<Point>(new Point[]
        {
            new Point(0, 0, 0),
            new Point(1, 0, 0),
            new Point(0.5, Math.Cos(BasicMath.ToRad(30)), 0),
            new Point(0.5, Math.Cos(BasicMath.ToRad(30))/3, Math.Cos(BasicMath.ToRad(30)))
        });

        private static Polygon[] _faces = new Polygon[]
        {
            new Polygon(new Point[] { _vertices[0], _vertices[1], _vertices[2] }),
            new Polygon(new Point[] { _vertices[0], _vertices[1], _vertices[3] }),
            new Polygon(new Point[] { _vertices[1], _vertices[2], _vertices[3] }),
            new Polygon(new Point[] { _vertices[2], _vertices[0], _vertices[3] })
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
