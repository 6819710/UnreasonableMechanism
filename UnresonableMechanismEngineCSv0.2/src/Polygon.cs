using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismEngineCS
{
    /// <summary>
    /// Polygon defines 2D objects made up of an equal number of vertices (points) and edges (vectors).
    /// </summary>
    public class Polygon
    {
        private List<Point> _vertices;
        private List<Vector> _edges;

        /// <summary>
        /// Constructs an empty polygon.
        /// </summary>
        public Polygon()
        {
            _vertices = new List<Point>();
            _edges = new List<Vector>();
        }

        /// <summary>
        /// Constructs a polygon using an array of vertices.
        /// </summary>
        /// <param name="vertices">Array of vertices (point).</param>
        public Polygon(Point[] vertices)
        {
            _vertices = new List<Point>(vertices);
            _edges = new List<Vector>();
            BuildEdges();
        }

        /// <summary>
        /// Constructs a polygon using an array of vertices (point) and location.
        /// </summary>
        /// <param name="vertices">Array of vertices (point).</param>
        /// <param name="location">Location (point).</param>
        public Polygon(Point[] vertices, Point location)
        {
            _vertices = new List<Point>(vertices);
            _edges = new List<Vector>();
            BuildEdges();
            Offset(new Vector(Center, location));
        }

        /// <summary>
        /// Readonly Property: Center point of polygon (calculated).
        /// </summary>
        public Point Center
        {
            get
            {
                Point result = new Point();
                foreach(Point vertex in _vertices)
                {
                    result += vertex;
                }
                return result / _vertices.Count;
            }
        }

        /// <summary>
        /// Readonly Property: List of edges (vector).
        /// </summary>
        public List<Vector> Edges
        {
            get
            {
                return _edges;
            }
        }

        /// <summary>
        /// Readonly Property: List of vertices (point).
        /// </summary>
        public List<Point> Vertices
        {
            get
            {
                return _vertices;
            }
        }

        private void BuildEdges()
        {
            _edges.Clear();
            for (int i = 0; i < _vertices.Count; ++i)
            {
                if (i + 1 >= _vertices.Count)
                {
                    _edges.Add(new Vector(_vertices[i], _vertices[0]));
                }
                else
                {
                    _edges.Add(new Vector(_vertices[i], _vertices[i + 1]));
                }
            }
        }

        /// <summary>
        /// Offsets the polygon by the given movment vector.
        /// </summary>
        /// <param name="movement">Movement vector.</param>
        public void Offset(Vector movement)
        {
            foreach(Point vertex in _vertices)
            {
                vertex.Offset(movement);
            }
        }
    }
}