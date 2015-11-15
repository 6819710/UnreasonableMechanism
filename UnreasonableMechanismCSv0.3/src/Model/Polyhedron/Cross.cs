using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMechanismCS
{
    public class Cross : Polyhedron
    {
        private List<Point> _vertices = new List<Point>(new Point[]
        {
            new Point(0,1,0),
            new Point(2,1,0),
            new Point(2,0,0),
            new Point(3,0,0),
            new Point(3,1,0),
            new Point(4,1,0),
            new Point(4,2,0),
            new Point(3,2,0),
            new Point(3,3,0),
            new Point(2,3,0),
            new Point(2,2,0),
            new Point(0,2,0),
            new Point(0,1,1),
            new Point(2,1,1),
            new Point(2,0,1),
            new Point(3,0,1),
            new Point(3,1,1),
            new Point(4,1,1),
            new Point(4,2,1),
            new Point(3,2,1),
            new Point(3,3,1),
            new Point(2,3,1),
            new Point(2,2,1),
            new Point(0,2,1)
        });

        public Cross(double scale) : base()
        {
            for(int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i] = _vertices[i] * scale;
            }

            Faces.Add(new Polygon(new Point[] { _vertices[1], _vertices[2], _vertices[3], _vertices[4], _vertices[5], _vertices[6], _vertices[7], _vertices[8], _vertices[9], _vertices[10], _vertices[11], _vertices[12] }));
        }
    }
}