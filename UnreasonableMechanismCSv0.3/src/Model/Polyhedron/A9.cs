using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMechanismCS
{
    public class A9:Polyhedron
    {
        private static List<Point> _vertices = new List<Point>(new Point[]
        {
            new Point(1, 1, 0),
            new Point(2.414, 1, 0),
            new Point(2.414, 2.414, 0),
            new Point(1, 2.414, 0),
            new Point(1, 0, 1),
            new Point(2.414, 0, 1),
            new Point(3.414, 1, 1),
            new Point(3.414, 2.414, 1),
            new Point(2.414, 3.414, 1),
            new Point(1, 3.414, 1),
            new Point(0, 2.414, 1),
            new Point(0, 1, 1),
            new Point(1, 0, 2.414),
            new Point(2.414, 0, 2.414),
            new Point(3.414, 1, 2.414),
            new Point(3.414, 2.414, 2.414),
            new Point(2.414, 3.414, 2.414),
            new Point(1, 3.414, 2.414),
            new Point(0, 2.414, 2.414),
            new Point(0, 1, 2.414),
            new Point(1, 1, 3.414),
            new Point(2.414, 1, 3.414),
            new Point(2.414, 2.414, 3.414),
            new Point(1, 2.414, 3.414),
        });

        private static Polygon[] _faces = new Polygon[]
        {
            new Polygon(new Point[] { _vertices[0], _vertices[1], _vertices[2], _vertices[3] }),
            new Polygon(new Point[] { _vertices[0], _vertices[4], _vertices[5], _vertices[1] }),
            new Polygon(new Point[] { _vertices[1], _vertices[6], _vertices[7], _vertices[2] }),
            new Polygon(new Point[] { _vertices[2], _vertices[8], _vertices[9], _vertices[3] }),
            new Polygon(new Point[] { _vertices[3], _vertices[10], _vertices[11], _vertices[0] }),
            new Polygon(new Point[] { _vertices[4], _vertices[5], _vertices[13], _vertices[12] }),
            new Polygon(new Point[] { _vertices[5], _vertices[6], _vertices[14], _vertices[13] }),
            new Polygon(new Point[] { _vertices[6], _vertices[7], _vertices[15], _vertices[14] }),
            new Polygon(new Point[] { _vertices[7], _vertices[8], _vertices[16], _vertices[15] }),
            new Polygon(new Point[] { _vertices[8], _vertices[9], _vertices[17], _vertices[16] }),
            new Polygon(new Point[] { _vertices[9], _vertices[10], _vertices[18], _vertices[17] }),
            new Polygon(new Point[] { _vertices[10], _vertices[11], _vertices[19], _vertices[18] }),
            new Polygon(new Point[] { _vertices[11], _vertices[4], _vertices[12], _vertices[19] }),
            new Polygon(new Point[] { _vertices[12], _vertices[13], _vertices[21], _vertices[20] }),
            new Polygon(new Point[] { _vertices[14], _vertices[15], _vertices[22], _vertices[21] }),
            new Polygon(new Point[] { _vertices[16], _vertices[17], _vertices[23], _vertices[22] }),
            new Polygon(new Point[] { _vertices[18], _vertices[19], _vertices[20], _vertices[23] }),
            new Polygon(new Point[] { _vertices[20], _vertices[21], _vertices[22], _vertices[23] }),
            new Polygon(new Point[] { _vertices[0], _vertices[4], _vertices[11] }),
            new Polygon(new Point[] { _vertices[1], _vertices[6], _vertices[5] }),
            new Polygon(new Point[] { _vertices[2], _vertices[8], _vertices[7] }),
            new Polygon(new Point[] { _vertices[3], _vertices[10], _vertices[9] }),
            new Polygon(new Point[] { _vertices[20], _vertices[19], _vertices[12] }),
            new Polygon(new Point[] { _vertices[21], _vertices[13], _vertices[14] }),
            new Polygon(new Point[] { _vertices[22], _vertices[15], _vertices[16] }),
            new Polygon(new Point[] { _vertices[23], _vertices[17], _vertices[18] })
        };

        public A9(double scale) : base(_faces)
        {
            base.Scale(scale);
        }
    }
}