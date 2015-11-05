using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismEngineCS
{
    /// <summary>
    /// Polyhedron defines 3D objects made up of 2D faces (polygon).
    /// </summary>
    public class Polyhedron
    {
        private List<Polygon> _faces;

        /// <summary>
        /// Constructs an empty polyhedron.
        /// </summary>
        public Polyhedron()
        {
            _faces = new List<Polygon>();
        }

        /// <summary>
        /// Constructs a polyhedron with the provided faces.
        /// </summary>
        /// <param name="faces">Array of faces (polygon)</param>
        public Polyhedron(Polygon[] faces)
        {
            _faces = new List<Polygon>(faces);
        }

        /// <summary>
        /// Constructs a polyhedron with the provided faces at the given location
        /// </summary>
        /// <param name="faces">Array of faces (polygon)</param>
        /// <param name="location">Location (point)</param>
        public Polyhedron(Polygon[] faces, Point location)
        {
            _faces = new List<Polygon>(faces);
            Offset(new Vector(Center, location));
        }

        /// <summary>
        /// Readonly Property: Center point of polyhedron (calculated).
        /// </summary>
        public Point Center
        {
            get
            {
                Point result = new Point();
                int count = 0;
                foreach(Polygon face in _faces)
                {
                    foreach(Point vertex in face.Vertices)
                    {
                        result += vertex;
                        count++;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Readonly Property: Faces (polygon).
        /// </summary>
        public List<Polygon> Faces
        {
            get
            {
                return _faces;
            }
        }
    }
}