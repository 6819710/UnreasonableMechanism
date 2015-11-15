using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

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
            Offset(new Vector(location, Middle));
        }

        /// <summary>
        /// Readonly Property: Centroid point of polygon (calculated).
        /// </summary>
        public Point Centroid
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
        /// Readonly Property: Maximum x value.
        /// </summary>
        public double MaxX
        {
            get
            {
                double result = double.NegativeInfinity;

                foreach(Point vertex in _vertices)
                {
                    if (result < vertex.X)
                    {
                        result = vertex.X;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Readonly Property: Maximum y value.
        /// </summary>
        public double MaxY
        {
            get
            {
                double result = double.NegativeInfinity;

                foreach(Point vertex in _vertices)
                {
                    if(result < vertex.Y)
                    {
                        result = vertex.Y;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Readonly Property: Maximum z value.
        /// </summary>
        public double MaxZ
        {
            get
            {
                double result = double.NegativeInfinity;

                foreach (Point vertex in _vertices)
                {
                    if (result < vertex.Z)
                    {
                        result = vertex.Z;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Readonly Property: Middle point.
        /// </summary>
        public Point Middle
        {
            get
            {
                Point min = new Point(MinX, MinY, MinZ);
                Point max = new Point(MaxX, MaxY, MaxZ);

                return (min + max) / 2;
            }
        }

        /// <summary>
        /// Readonly Property: Minimum x value.
        /// </summary>
        public double MinX
        {
            get
            {
                double result = double.PositiveInfinity;

                foreach (Point vertex in _vertices)
                {
                    if (result > vertex.X)
                    {
                        result = vertex.X;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Readonly Property: Minimum y value.
        /// </summary>
        public double MinY
        {
            get
            {
                double result = double.PositiveInfinity;

                foreach (Point vertex in _vertices)
                {
                    if (result > vertex.Y)
                    {
                        result = vertex.Y;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Readonly Property: Minimum z value.
        /// </summary>
        public double MinZ
        {
            get
            {
                double result = double.PositiveInfinity;

                foreach (Point vertex in _vertices)
                {
                    if (result > vertex.Z)
                    {
                        result = vertex.Z;
                    }
                }

                return result;
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
                    _edges.Add(new Vector(_vertices[0], _vertices[i]));
                }
                else
                {
                    _edges.Add(new Vector(_vertices[i + 1], _vertices[i]));
                }
            }
        }

        /// <summary>
        /// Draws the polygon, face, edges and vertives.
        /// </summary>
        /// <param name="clrFace">Colour to draw face.</param>
        /// <param name="clrEdge">Colour to draw edges.</param>
        /// <param name="clrVertex">Color to draw vertices.</param>
        public void Draw(Color clrFace, Color clrEdge, Color clrVertex)
        {
            DrawFace(clrFace);
            DrawEdge(clrEdge);
            DrawVertex(clrVertex);
        }

        /// <summary>
        /// Draws the polygon, face and edges.
        /// </summary>
        /// <param name="clrFace">Colour to draw face.</param>
        /// <param name="clrEdge">Colour to draw edges.</param>
        public void Draw(Color clrFace, Color clrEdge)
        {
            DrawFace(clrFace);
            DrawEdge(clrEdge);
        }

        /// <summary>
        /// Draws the polygon, face.
        /// </summary>
        /// <param name="clrFace">Colour to draw face.</param>
        public void Draw(Color clrFace)
        {
            DrawFace(clrFace);
        }

        /// <summary>
        /// Draws polygon edges.
        /// </summary>
        /// <param name="clr">Colour to draw edges.</param>
        public void DrawEdge(Color clr)
        {
            for(int i = 0; i < _vertices.Count; i++)
            {
                _edges[i].Draw(clr, _vertices[i]);
            }
        }

        /// <summary>
        /// Draws polygon face.
        /// </summary>
        /// <param name="clr">Colour to draw face.</param>
        public void DrawFace(Color clr)
        {
            for(int i = 0; i < _vertices.Count; i++)
            {
                float x = (float)Centroid.X;
                float y = (float)Centroid.Y;

                float x1 = (float)_vertices[i].X;
                float y1 = (float)_vertices[i].Y;

                float x2, y2;

                if (i + 1 >= _vertices.Count)
                {
                    x2 = (float)_vertices[0].X;
                    y2 = (float)_vertices[0].Y;
                }
                else
                {
                    x2 = (float)_vertices[i + 1].X;
                    y2 = (float)_vertices[i + 1].Y;
                }

                SwinGame.FillTriangle(clr, x, y, x1, y1, x2, y2);
            }
        }

        /// <summary>
        /// Draws polygon vertices.
        /// </summary>
        /// <param name="clr">Color to draw vertices.</param>
        public void DrawVertex(Color clr)
        {
            foreach(Point vertex in _vertices)
            {
                vertex.Draw(clr);
            }
        }

        /// <summary>
        /// Determines if polygon is greater than the provided value.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Boolean.</returns>
        public bool GreaterThanX(double x)
        {
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanX(x))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is greater than or equal to the provided value.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Boolean.</returns>
        public bool GreaterThanEqualX(double x)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.GreaterThanEqualX(x))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is greater than the provided value.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Boolean.</returns>
        public bool GreaterThanY(double y)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.GreaterThanY(y))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is greater than or equal to the provided value.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Boolean.</returns>
        public bool GreaterThanEqualY(double y)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.GreaterThanEqualY(y))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is greater than the provided value.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Boolean.</returns>
        public bool GreaterThanZ(double z)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.GreaterThanZ(z))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is greater than or equal to the provided value.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Boolean.</returns>
        public bool GreaterThanEqualZ(double z)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.GreaterThanEqualZ(z))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is less than the provided value.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Boolean.</returns>
        public bool LessThanX(double x)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.LessThanX(x))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is less than or equal to the provided value.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Boolean.</returns>
        public bool LessThanEqualX(double x)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.LessThanEqualX(x))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is less than the provided value.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Boolean.</returns>
        public bool LessThanY(double y)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.LessThanY(y))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is less than or equal to the provided value.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Boolean.</returns>
        public bool LessThanEqualY(double y)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.LessThanEqualY(y))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is less than the provided value.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Boolean.</returns>
        public bool LessThanZ(double z)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.LessThanZ(z))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if polygon is less than or equal to the provided value.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Boolean.</returns>
        public bool LessThanEqualZ(double z)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.LessThanEqualZ(z))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Calulates the maximum distance from x when vertex is greater than x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Maximum distance from x.</returns>
        public double MaxDistanceGreaterThanX(double x)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanX(x) && vertex.DistanceFromX(x) > distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates the maximum distance from y when vertex is greater than y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Maximum distance from y.</returns>
        public double MaxDistanceGreaterThanY(double y)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.GreaterThanY(y) && vertex.DistanceFromY(y) > distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates the maximum distance from z when vertex is greater than z.
        /// </summary>
        /// <param name="z">Value of z.</param>
        /// <returns>Maximum distance from z.</returns>
        public double MaxDistanceGreaterThanZ(double z)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanZ(z) && vertex.DistanceFromZ(z) > distance)
                {
                    distance = vertex.DistanceFromX(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance from x when vertex is greater than or equal to x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Maximum distance from x.</returns>
        public double MadDistanceGreaterThanEqualX(double x)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanEqualX(x) && vertex.DistanceFromX(x) > distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates maximum distance from y when vertex is greater than or equal to y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Maximum distance from y.</returns>
        public double MaxDistanceGreaterThanEqualY(double y)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanEqualY(y) && vertex.DistanceFromY(y) > distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates maximum distance from z when vertex is greater than or equal to z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>Maximum distance from z.</returns>
        public double MaxDistanceGreaterThanEqualZ(double z)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanEqualZ(z) && vertex.DistanceFromZ(z) > distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates the maximum distance from x when vertex is less than x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Maximum distance from x.</returns>
        public double MaxDistanceLessThanX(double x)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanX(x) && vertex.DistanceFromX(x) > distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates the maximum distance from y when vertex is less than y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Maximum distance from y.</returns>
        public double MaxDistanceLessThanY(double y)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanY(y) && vertex.DistanceFromY(y) > distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates the maximum distance from z when vertex is less than z.
        /// </summary>
        /// <param name="z">Value of z.</param>
        /// <returns>Maximum distance from z.</returns>
        public double MaxDistanceLessThanZ(double z)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanZ(z) && vertex.DistanceFromZ(z) > distance)
                {
                    distance = vertex.DistanceFromX(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance from x when vertex is less than or equal to x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Maximum distance from x.</returns>
        public double MaxDistanceLessThanEqualX(double x)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanEqualX(x) && vertex.DistanceFromX(x) > distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates maximum distance from y when vertex is less than or equal to y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Maximum distance from y.</returns>
        public double MaxDistanceLessThanEqualY(double y)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if (vertex.LessThanEqualY(y) && vertex.DistanceFromY(y) > distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates maximum distance from z when vertex is less than or equal to z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>Maximum distance from z.</returns>
        public double MaxDistanceLessThanEqualZ(double z)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanEqualZ(z) && vertex.DistanceFromZ(z) > distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates minimum distance from x when vertex is greater than x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Minimum distance from x.</returns>
        public double MinDistanceGreaterThanX(double x)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanX(x) && vertex.DistanceFromX(x) < distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates minimum distance from y when vertex is greater than y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Minimum distance from y.</returns>
        public double MinDistanceGreaterThanY(double y)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanY(y) && vertex.DistanceFromY(y) < distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates minimum distance from z when vertex is greater than z.
        /// </summary>
        /// <param name="z">Value of z.</param>
        /// <returns>Minimum distance from z.</returns>
        public double MinDistanceGreaterThanZ(double z)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanZ(z) && vertex.DistanceFromZ(z) < distance)
                {
                    distance = vertex.DistanceFromX(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates minimum distance from x when vertex is greater than or equal to x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Minimum distance from x.</returns>
        public double MinDistanceGreaterThanEqualX(double x)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanEqualX(x) && vertex.DistanceFromX(x) < distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates minimum distance from y when vertex is greater than or equal to y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Minimum distance from y.</returns>
        public double MinDistanceGreaterThanEqualY(double y)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanEqualY(y) && vertex.DistanceFromY(y) < distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates minimum distance from z when vertex is greater than or equal to z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>Minimum distance from z.</returns>
        public double MinDistanceGreaterThanEqualZ(double z)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.GreaterThanEqualZ(z) && vertex.DistanceFromZ(z) < distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates minimum distance from x when vertex is less than x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Minimum distance from x.</returns>
        public double MinDistanceLessThanX(double x)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanX(x) && vertex.DistanceFromX(x) < distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates minimum distance from y when vertex is less than y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Minimum distance from y.</returns>
        public double MinDistanceLessThanY(double y)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanY(y) && vertex.DistanceFromY(y) < distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calulates minimum distance from z when vertex is less than z.
        /// </summary>
        /// <param name="z">Value of z.</param>
        /// <returns>Minimum distance from z.</returns>
        public double MinDistanceLessThanZ(double z)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanZ(z) && vertex.DistanceFromZ(z) < distance)
                {
                    distance = vertex.DistanceFromX(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates minimum distance from x when vertex is less than or equal to x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Minimum distance from x.</returns>
        public double MinDistanceLessThanEqualX(double x)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanEqualX(x) && vertex.DistanceFromX(x) < distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates minimum distance from y when vertex is less than or equal to y.
        /// </summary>
        /// <param name="y">Value of y.</param>
        /// <returns>Minimum distance from y.</returns>
        public double MinDistanceLessThanEqualY(double y)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanEqualY(y) && vertex.DistanceFromY(y) < distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates minimum distance from z when vertex is less than or equal to z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>Minimum distance from z.</returns>
        public double MinDistanceLessThanEqualZ(double z)
        {
            double distance = double.PositiveInfinity;
            foreach(Point vertex in _vertices)
            {
                if(vertex.LessThanEqualZ(z) && vertex.DistanceFromZ(z) < distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Offsets the polygon by the given movment vector.
        /// </summary>
        /// <param name="movement">Movement vector.</param>
        public void Offset(Vector movement)
        {
            for(int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i] = _vertices[i].Offset(movement);
            }
        }

        /// <summary>
        /// Pitches the polygon about the y coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to pitch.</param>
        /// <param name="point">Point to pitch about.</param>
        public void PitchY(double angle, Point point)
        {
            for(int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i] = _vertices[i].PitchY(angle, point);
            }
            BuildEdges();
        }

        /// <summary>
        /// Rolls the polygon about the x coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to roll.</param>
        /// <param name="point">Point to roll about.</param>
        public void RollX(double angle, Point point)
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i] = _vertices[i].RollX(angle, point);
            }
            BuildEdges();
        }

        /// <summary>
        /// Scales the polygon about the given point.
        /// </summary>
        /// <param name="scale">Scale.</param>
        /// <param name="center">Point to scale about.</param>
        public void Scale(double scale, Point point)
        {
            for(int i = 0; i < _vertices.Count; i++)
            {
                Point working = _vertices[i] - point;

                working = working * scale;

                _vertices[i] = working + point;
            }
            BuildEdges();
        }

        /// <summary>
        /// Yaws the polygon about the z coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to yaw.</param>
        /// <param name="point">Point to yaw about.</param>
        public void YawZ(double angle, Point point)
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i] = _vertices[i].YawZ(angle, point);
            }
            BuildEdges();
        }
    }
}