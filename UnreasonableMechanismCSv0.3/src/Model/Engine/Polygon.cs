using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    /// <summary>
    /// Polygon defines 2D objects made up of an equal number of vertices (point) and edges (vector)
    /// </summary>
    public class Polygon
    {
        /// <summary>
        /// List of vertices (point).
        /// </summary>
        private List<Point> _vertices;

        /// <summary>
        /// List of edges (vector).
        /// </summary>
        private List<Vector> _edges;

        private Point _trajectory;
        private Point _roll;

        /// <summary>
        /// Constructs an empty polygon.
        /// </summary>
        public Polygon()
        {
            _vertices = new List<Point>();
            _edges = new List<Vector>();
        }

        /// <summary>
        /// Constructs a polygon with the provided vertices.
        /// </summary>
        /// <param name="vertices">Array of vertices (point)</param>
        public Polygon(Point[] vertices)
        {
            _vertices = new List<Point>(vertices);
            _edges = new List<Vector>();
            BuildEdges();
        }

        /// <summary>
        /// Constructs a polygon with the provided
        /// </summary>
        /// <param name="vertices">Array of vertices (point)</param>
        /// <param name="location">Location (point)</param>
        public Polygon(Point[] vertices, Point location)
        {
            _vertices = new List<Point>(vertices);
            _edges = new List<Vector>();
            Offset(new Vector(Center, location));
        }

        /// <summary>
        /// Returns the center point of the polygon (calculated).
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
        /// Returns the list of edges (vector).
        /// </summary>
        public List<Vector> Edges
        {
            get
            {
                return _edges;
            }
        }

        /// <summary>
        /// Returns the list of vertices (point).
        /// </summary>
        public List<Point> Vertices
        {
            get
            {
                return _vertices;
            }
        }

        /// <summary>
        /// Adds a vertex at the given location (absolute cartesian coordinates).
        /// </summary>
        /// <param name="x">Absolute x coordinate of location.</param>
        /// <param name="y">Absolute y coordinate of location.</param>
        /// <param name="z">Absolute z coordinate of location.</param>
        public void AddAbsVertex(double absX, double absY, double absZ)
        {
            AddAbsVertex(new Point(absX, absY, absZ));
        }

        /// <summary>
        /// Adds a vertex at the given location.
        /// </summary>
        /// <param name="location">Location (point)</param>
        public void AddAbsVertex(Point location)
        {
            _vertices.Add(location);
            BuildEdges();
        }

        //TODO: AddVertex(v,y,z)

        //TODO: AddVertex(location)

        /// <summary>
        /// Builds the edges of the polygon.
        /// </summary>
        public void BuildEdges()
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
        /// Draws the polygon.
        /// </summary>
        /// <param name="clrFace">Colour to draw the face.</param>
        /// <param name="clrEdge">Colour to draw the edges.</param>
        /// <param name="clrVertex">Colour to draw the vertices.</param>
        public void Draw(Color clrFace, Color clrEdge, Color clrVertex)
        {
            DrawFace(clrFace);
            DrawEdge(clrEdge);
            DrawVertex(clrVertex);
        }

        /// <summary>
        /// Draws the polygon.
        /// </summary>
        /// <param name="clrFace">Colour to draw the face.</param>
        /// <param name="clrEdge">Colour to draw the polygon.</param>
        public void Draw(Color clrFace, Color clrEdge)
        {
            DrawFace(clrFace);
            DrawEdge(clrEdge);
        }

        /// <summary>
        /// Draws the polygon.
        /// </summary>
        /// <param name="clrFace">Colour to draw the face.</param>
        public void Draw(Color clrFace)
        {
            DrawFace(clrFace);
        }

        /// <summary>
        /// Draws the polygon face.
        /// </summary>
        /// <param name="clr">Colour to draw the face.</param>
        public void DrawFace(Color clr)
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                float x1 = (float)Center.x;
                float y1 = (float)Center.y;

                float x2 = (float)_vertices[i].x;
                float y2 = (float)_vertices[i].y;

                float x3, y3;

                if (i + 1 >= _vertices.Count)
                {
                    x3 = (float)_vertices[0].x;
                    y3 = (float)_vertices[0].y;
                }
                else
                {
                    x3 = (float)_vertices[i + 1].x;
                    y3 = (float)_vertices[i + 1].y;
                }

                SwinGame.FillTriangle(clr, x1, y1, x2, y2, x3, y3);
            }
        }

        /// <summary>
        /// Draws the polygon edges.
        /// </summary>
        /// <param name="clr">Colour to draw the edges.</param>
        public void DrawEdge(Color clr)
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                _edges[i].Draw(clr, _vertices[i]);
            }
        }

        /// <summary>
        /// Draws the polygon vertices.
        /// </summary>
        /// <param name="clr">Colour to draw the vertices.</param>
        public void DrawVertex(Color clr)
        {
            foreach(Point vertex in _vertices)
            {
                vertex.Draw(clr);
            }
        }

        /// <summary>
        /// Offsets the polygon by the given movement (vector)
        /// </summary>
        /// <param name="movement">Movement (vector)</param>
        public void Offset(Vector movement)
        {
            for(int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = (_vertices[i] + movement).ToPoint();
            }
            _trajectory = (_trajectory + movement).ToPoint();
            _roll = (_trajectory + movement).ToPoint();
        }

        /// <summary>
        /// Offsets the polygon by the given cartesian coordinates.
        /// </summary>
        /// <param name="x">Offset in x.</param>
        /// <param name="y">Offset in y.</param>
        /// <param name="z">Offset in z.</param>
        public void Offset(double x, double y, double z)
        {
            Offset(new Vector(x, y, z));
        }

        /// <summary>
        /// Rotates the polygon about the given point in the given frame of reference
        /// </summary>
        /// <param name="yaw">Angle to yaw (radians).</param>
        /// <param name="pitch">Angle to pitch (radians).</param>
        /// <param name="roll">Angle to roll (radians).</param>
        /// <param name="point">Point to rotate about.</param>
        /// <param name="trajectory">Direction facing (vector).</param>
        /// <param name="vroll">Direction of Roll (vector).</param>
        public void RotateAboutPoint(double yaw, double pitch, double roll, Point point, Vector trajectory, Vector vRoll)
        {
            for(int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Rotate(_vertices[i], yaw, pitch, roll, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Rotate(_trajectory, yaw, pitch, roll, point, trajectory, vRoll);
            _roll = Rotation.Rotate(_trajectory, yaw, pitch, roll, point, trajectory, vRoll);
            BuildEdges();
        }

        /// <summary>
        /// Rotates the polygon about the given point in its frame of reference.
        /// </summary>
        /// <param name="yaw">Angle to yaw (radians).</param>
        /// <param name="pitch">Angle to pitch (radians).</param>
        /// <param name="roll">Angle to roll (radians).</param>
        /// <param name="point">Point to rotate about.</param>
        public void RotateAboutPoint(double yaw, double pitch, double roll, Point point)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Rotate(_vertices[i], yaw, pitch, roll, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Rotate(_trajectory, yaw, pitch, roll, point, trajectory, vRoll);
            _roll = Rotation.Rotate(_trajectory, yaw, pitch, roll, point, trajectory, vRoll);
            BuildEdges();
        }

        //TODO: RotateAboutPointXYZ(yaw, pitch, roll, point)

        /// <summary>
        /// Rotates the polygon about its center in the given frame of reference
        /// </summary>
        /// <param name="yaw">Angle to yaw (radians).</param>
        /// <param name="pitch">Angle to pitch (radians).</param>
        /// <param name="roll">Angle to roll (radians).</param>
        /// <param name="trajectory">Direction facing (vector).</param>
        /// <param name="vroll">Direction of Roll (vector).</param>
        public void RotateAboutCenter(double yaw, double pitch, double roll, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Rotate(_vertices[i], yaw, pitch, roll, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Rotate(_trajectory, yaw, pitch, roll, Center, trajectory, vRoll);
            _roll = Rotation.Rotate(_trajectory, yaw, pitch, roll, Center, trajectory, vRoll);
            BuildEdges();
        }

        /// <summary>
        /// Rotates the polygon about its center in its frame of reference.
        /// </summary>
        /// <param name="yaw">Angle to yaw (radians).</param>
        /// <param name="pitch">Angle to pitch (radians).</param>
        /// <param name="roll">Angle to roll (radians).</param>
        public void RotateAboutCenter(double yaw, double pitch, double roll)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Rotate(_vertices[i], yaw, pitch, roll, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Rotate(_trajectory, yaw, pitch, roll, Center, trajectory, vRoll);
            _roll = Rotation.Rotate(_trajectory, yaw, pitch, roll, Center, trajectory, vRoll);
            BuildEdges();
        }

        //TODO: RotateAboutCenterXYZ(yaw, pitch, roll)

        public void YawAboutPoint(double yaw, Point point, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Yaw(_vertices[i], yaw, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Yaw(_trajectory, yaw, point, trajectory, vRoll);
            _roll = Rotation.Yaw(_trajectory, yaw, point, trajectory, vRoll);
            BuildEdges();
        }

        public void YawAboutPoint(double yaw, Point point)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Yaw(_vertices[i], yaw, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Yaw(_trajectory, yaw, point, trajectory, vRoll);
            _roll = Rotation.Yaw(_trajectory, yaw, point, trajectory, vRoll);
            BuildEdges();
        }

        public void YawAboutCenter(double yaw, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Yaw(_vertices[i], yaw, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Yaw(_trajectory, yaw, Center, trajectory, vRoll);
            _roll = Rotation.Yaw(_trajectory, yaw, Center, trajectory, vRoll);
            BuildEdges();
        }

        public void YawAboutCenter(double yaw)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Yaw(_vertices[i], yaw, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Yaw(_trajectory, yaw, Center, trajectory, vRoll);
            _roll = Rotation.Yaw(_trajectory, yaw, Center, trajectory, vRoll);
            BuildEdges();
        }

        public void PitchAboutPoint(double pitch, Point point, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Pitch(_vertices[i], pitch, point, vRoll);
            }
            _trajectory = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            _roll = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            BuildEdges();
        }

        public void PitchAboutPoint(double pitch, Point point)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Pitch(_vertices[i], pitch, point, vRoll);
            }
            _trajectory = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            _roll = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            BuildEdges();
        }

        public void PitchAboutCenter(double pitch, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Pitch(_vertices[i], pitch, Center, vRoll);
            }
            _trajectory = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            _roll = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            BuildEdges();
        }

        public void PitchAboutCenter(double pitch)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Pitch(_vertices[i], pitch, Center, vRoll);
            }
            _trajectory = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            _roll = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            BuildEdges();
        }

        public void RollAboutPoint(double roll, Point point, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Roll(_vertices[i], roll, point, trajectory);
            }
            _trajectory = Rotation.Roll(_trajectory, roll, point, trajectory);
            _roll = Rotation.Roll(_trajectory, roll, point, trajectory);
            BuildEdges();
        }

        public void RollAboutPoint(double roll, Point point)
        {
            Vector trajectory = new Vector(1, 0, 0);
            Vector vRoll = new Vector(0, 1, 0);
            for (int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i] = Rotation.Roll(_vertices[i], roll, point, trajectory);
            }
            _trajectory = Rotation.Roll(_trajectory, roll, point, trajectory);
            _roll = Rotation.Roll(_trajectory, roll, point, trajectory);
            BuildEdges();
        }

        public void RollAboutCenter(double roll, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Roll(_vertices[i], roll, Center, trajectory);
            }
            _trajectory = Rotation.Roll(_trajectory, roll, Center, trajectory);
            _roll = Rotation.Roll(_trajectory, roll, Center, trajectory);
            BuildEdges();
        }

        public void RollAboutCenter(double roll)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _vertices.Count; ++i)
            {
                _vertices[i] = Rotation.Roll(_vertices[i], roll, Center, trajectory);
            }
            _trajectory = Rotation.Roll(_trajectory, roll, Center, trajectory);
            _roll = Rotation.Roll(_trajectory, roll, Center, trajectory);
            BuildEdges();
        }

        public void Scale(double scale, Point center)
        {
            for(int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i] = _vertices[i] * scale;
            }
            BuildEdges();
        }

        public void Scale(double scale)
        {
            Scale(scale, Center);
        }






        public bool GreaterThanX(double x)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.x > x)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LessThanX(double x)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.x < x)
                {
                    return true;
                }
            }
            return false;
        }

        public bool GreaterThanY(double y)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.y > y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool LessThanY(double y)
        {
            foreach (Point vertex in _vertices)
            {
                if (vertex.y < y)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Calculates the maximum distance greater than x.
        /// </summary>
        /// <param name="x">value of x.</param>
        /// <returns>maximum distance greater than x.</returns>
        public double MaxDistanceGreaterThanX(double x)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.x > x && vertex.DistanceFromX(x) > distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance greater than x.
        /// </summary>
        /// <param name="x">value of x.</param>
        /// <returns></returns>
        public double MinDistanceGreaterThanX(double x)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.x > x && vertex.DistanceFromX(x) < distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance less than x.
        /// </summary>
        /// <param name="x">value of x.</param>
        /// <returns>maximum distance less than x.</returns>
        public double MaxDistanceLessThanX(double x)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.x < x && vertex.DistanceFromX(x) > distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance less than x.
        /// </summary>
        /// <param name="x">value of x.</param>
        /// <returns>Minimum distance less than x</returns>
        public double MinDistanceLessThanX(double x)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.x < x && vertex.DistanceFromX(x) < distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance from x.
        /// </summary>
        /// <param name="x">value of x.</param>
        /// <returns>maximum distance from x.</returns>
        public double MaxDistanceFromX(double x)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.DistanceFromX(x) > distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance from x.
        /// </summary>
        /// <param name="x">value of x.</param>
        /// <returns>Minimum distance from x.</returns>
        public double MinDistanceFromX(double x)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.DistanceFromX(x) < distance)
                {
                    distance = vertex.DistanceFromX(x);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance greater than y.
        /// </summary>
        /// <param name="y">value of y.</param>
        /// <returns>maximum distance greater than y.</returns>
        public double MaxDistanceGreaterThanY(double y)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.y > y && vertex.DistanceFromY(y) > distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance greater than y.
        /// </summary>
        /// <param name="y">value of y.</param>
        /// <returns></returns>
        public double MinDistanceGreaterThanY(double y)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.y > y && vertex.DistanceFromY(y) < distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance less than y.
        /// </summary>
        /// <param name="y">value of y.</param>
        /// <returns>maximum distance less than y.</returns>
        public double MaxDistanceLessThanY(double y)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.y < y && vertex.DistanceFromY(y) > distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance less than y.
        /// </summary>
        /// <param name="y">value of y.</param>
        /// <returns>Minimum distance less than z</returns>
        public double MinDistanceLessThanY(double y)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.y < y && vertex.DistanceFromY(y) < distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance from y.
        /// </summary>
        /// <param name="y">value of y.</param>
        /// <returns>maximum distance from y.</returns>
        public double MaxDistanceFromY(double y)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.DistanceFromY(y) > distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance from y.
        /// </summary>
        /// <param name="y">value of y.</param>
        /// <returns>Minimum distance from y.</returns>
        public double MinDistanceFromY(double y)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.DistanceFromY(y) < distance)
                {
                    distance = vertex.DistanceFromY(y);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance greater than z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>maximum distance greater than z.</returns>
        public double MaxDistanceGreaterThanZ(double z)
        {
            double distance = double.NegativeInfinity;
            foreach(Point vertex in _vertices)
            {
                if (vertex.z > z && vertex.DistanceFromZ(z) > distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance greater than z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns></returns>
        public double MinDistanceGreaterThanZ(double z)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.z > z && vertex.DistanceFromZ(z) < distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance less than z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>maximum distance less than z.</returns>
        public double MaxDistanceLessThanZ(double z)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.z < z && vertex.DistanceFromZ(z) > distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance less than z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>Minimum distance less than z</returns>
        public double MinDistanceLessThanZ(double z)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.z < z && vertex.DistanceFromZ(z) < distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance from z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>maximum distance from z.</returns>
        public double MaxDistanceFromZ(double z)
        {
            double distance = double.NegativeInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.DistanceFromZ(z) > distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the minimum distance from z.
        /// </summary>
        /// <param name="z">value of z.</param>
        /// <returns>Minimum distance from z.</returns>
        public double MinDistanceFromZ(double z)
        {
            double distance = double.PositiveInfinity;
            foreach (Point vertex in _vertices)
            {
                if (vertex.DistanceFromZ(z) < distance)
                {
                    distance = vertex.DistanceFromZ(z);
                }
            }
            return distance;
        }
    }
}