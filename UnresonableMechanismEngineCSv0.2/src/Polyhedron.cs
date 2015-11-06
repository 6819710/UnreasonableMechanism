using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

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
            Offset(new Vector(location, Center));
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
                return result / count;
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

        /// <summary>
        /// Draws the polyhedron, faces, edges and vertices.
        /// </summary>
        /// <param name="clrFace">Color to draw the faces.</param>
        /// <param name="clrEdge">Colour to draw the edges.</param>
        /// <param name="clrVertex">Color to draw the vertices.</param>
        public void Draw(Color clrFace, Color clrEdge, Color clrVertex)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.Draw(clrFace, clrEdge, clrVertex);
            }
        }

        /// <summary>
        /// Draws the polyhedron, faces and edges.
        /// </summary>
        /// <param name="clrFace">Color to draw the faces.</param>
        /// <param name="clrEdge">Colour to draw the edges.</param>
        public void Draw(Color clrFace, Color clrEdge)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.Draw(clrFace, clrEdge);
            }
        }

        /// <summary>
        /// Draws the polyhedron, faces.
        /// </summary>
        /// <param name="clrFace">Color to draw the faces.</param>
        public void Draw(Color clrFace)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.Draw(clrFace);
            }
        }

        /// <summary>
        /// Draws the polyhedron edges.
        /// </summary>
        /// <param name="clr">Colour to draw the edges.</param>
        public void DrawEdge(Color clr)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.DrawEdge(clr);
            }
        }

        /// <summary>
        /// Draws the polyhedron faces.
        /// </summary>
        /// <param name="clr">Color to draw the faces.</param>
        public void DrawFace(Color clr)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.DrawFace(clr);
            }
        }

        /// <summary>
        /// Draws the polyhedron vertices.
        /// </summary>
        /// <param name="clr">Color to draw the vertices.</param>
        public void DrawVertex(Color clr)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.DrawVertex(clr);
            }
        }

        /// <summary>
        /// Determines if polygon is greater than the provided value.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Boolean.</returns>
        public bool GreaterThanX(double x)
        {
            foreach(Polygon face in _faces)
            {
                if (face.GreaterThanX(x))
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
            foreach(Polygon face in _faces)
            {
                if (face.GreaterThanEqualX(x))
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
            foreach(Polygon face in _faces)
            {
                if (face.GreaterThanY(y))
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
            foreach(Polygon face in _faces)
            {
                if (face.GreaterThanEqualY(y))
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
            foreach(Polygon face in _faces)
            {
                if (face.GreaterThanZ(z))
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
            foreach(Polygon face in _faces)
            {
                if (face.GreaterThanEqualZ(z))
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
            foreach(Polygon face in _faces)
            {
                if (face.LessThanX(x))
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
            foreach(Polygon face in _faces)
            {
                if (face.LessThanEqualX(x))
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
            foreach(Polygon face in _faces)
            {
                if (face.LessThanY(y))
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
            foreach(Polygon face in _faces)
            {
                if (face.LessThanEqualY(y))
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
            foreach(Polygon face in _faces)
            {
                if (face.LessThanZ(z))
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
            foreach(Polygon face in _faces)
            {
                if (face.LessThanEqualZ(z))
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanX(x) && face.MaxDistanceGreaterThanX(x) > distance)
                {
                    distance = face.MaxDistanceGreaterThanX(x);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanY(y) && face.MaxDistanceGreaterThanY(y) > distance)
                {
                    distance = face.MaxDistanceGreaterThanY(y);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanZ(z) && face.MaxDistanceGreaterThanZ(z) > distance)
                {
                    distance = face.MaxDistanceGreaterThanZ(z);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanEqualX(x) && face.MadDistanceGreaterThanEqualX(x) > distance)
                {
                    distance = face.MadDistanceGreaterThanEqualX(x);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanEqualY(y) && face.MaxDistanceGreaterThanEqualY(y) > distance)
                {
                    distance = face.MaxDistanceGreaterThanEqualY(y);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanEqualZ(z) && face.MaxDistanceGreaterThanEqualZ(z) > distance)
                {
                    distance = face.MaxDistanceGreaterThanEqualZ(z);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanX(x) && face.MaxDistanceLessThanX(x) > distance)
                {
                    distance = face.MaxDistanceLessThanX(x);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanY(y) && face.MaxDistanceLessThanY(y) > distance)
                {
                    distance = face.MaxDistanceLessThanY(y);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanZ(z) && face.MaxDistanceLessThanZ(z) > distance)
                {
                    distance = face.MaxDistanceLessThanZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Calculates the maximum distance from x when vertex is less than or equal to x.
        /// </summary>
        /// <param name="x">Value of x.</param>
        /// <returns>Maximum distance from x.</returns>
        public double MadDistanceLessThanEqualX(double x)
        {
            double distance = double.NegativeInfinity;
            foreach(Polygon face in _faces)
            {
                if(face.LessThanEqualX(x) && face.MadDistanceLessThanEqualX(x) > distance)
                {
                    distance = face.MadDistanceLessThanEqualX(x);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanEqualY(y) && face.MaxDistanceLessThanEqualY(y) > distance)
                {
                    distance = face.MaxDistanceLessThanEqualY(y);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanEqualZ(z) && face.MaxDistanceLessThanEqualZ(z) > distance)
                {
                    distance = face.MaxDistanceLessThanEqualZ(z);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanX(x) && face.MinDistanceGreaterThanX(x) < distance)
                {
                    distance = face.MinDistanceGreaterThanX(x);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanY(y) && face.MinDistanceGreaterThanY(y) < distance)
                {
                    distance = face.MinDistanceGreaterThanY(y);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanZ(z) && face.MinDistanceGreaterThanZ(z) < distance)
                {
                    distance = face.MinDistanceGreaterThanZ(z);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanEqualX(x) && face.MinDistanceGreaterThanEqualX(x) < distance)
                {
                    distance = face.MinDistanceGreaterThanEqualX(x);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanEqualY(y) && face.MinDistanceGreaterThanEqualY(y) < distance)
                {
                    distance = face.MinDistanceGreaterThanEqualY(y);
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
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanEqualZ(z) && face.MinDistanceGreaterThanEqualZ(z) < distance)
                {
                    distance = face.MinDistanceGreaterThanEqualZ(z);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanX(x) && face.MinDistanceLessThanX(x) < distance)
                {
                    distance = face.MinDistanceLessThanX(x);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanY(y) && face.MinDistanceLessThanY(y) < distance)
                {
                    distance = face.MinDistanceLessThanY(y);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanZ(z) && face.MinDistanceLessThanZ(z) < distance)
                {
                    distance = face.MinDistanceLessThanZ(z);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanEqualX(x) && face.MinDistanceLessThanEqualX(x) < distance)
                {
                    distance = face.MinDistanceLessThanEqualX(x);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanEqualY(y) && face.MinDistanceLessThanEqualY(y) < distance)
                {
                    distance = face.MinDistanceLessThanEqualY(y);
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
            foreach(Polygon face in _faces)
            {
                if(face.LessThanEqualZ(z) && face.MinDistanceLessThanEqualZ(z) < distance)
                {
                    distance = face.MinDistanceLessThanEqualZ(z);
                }
            }
            return distance;
        }

        /// <summary>
        /// Offsets the polyhedron by the given movment vector.
        /// </summary>
        /// <param name="movement">Movement vector.</param>
        public void Offset(Vector movement)
        {
            foreach(Polygon face in _faces)
            {
                face.Offset(movement);
            }
        }

        /// <summary>
        /// Pitches the polyhedron about the y coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to pitch.</param>
        /// <param name="point">Point to pitch about.</param>
        public void PitchY(double angle, Point point)
        {
            for (int i = 0; i < _faces.Count; i++)
            {
                _faces[i].PitchY(angle, point);
            }
        }

        /// <summary>
        /// Rolls the polyhedron about the x coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to roll.</param>
        /// <param name="point">Point to roll about.</param>
        public void RollX(double angle, Point point)
        {
            for (int i = 0; i < _faces.Count; i++)
            {
                _faces[i].RollX(angle, point);
            }
        }

        /// <summary>
        /// Scales the polyhedron about its center.
        /// </summary>
        /// <param name="scale">Scale.</param>
        public void Scale(double scale)
        {
            Scale(scale, Center);
        }

        /// <summary>
        /// Scales the polyhedron about the given point.
        /// </summary>
        /// <param name="scale">Scale.</param>
        /// <param name="center">Point to scale about.</param>
        public void Scale(double scale, Point point)
        {
            foreach(Polygon face in _faces)
            {
                face.Scale(scale, point);
            }
        }

        /// <summary>
        /// Sorts the faces in order of Z.
        /// </summary>
        private void Sort()
        {
            Polygon temp;
            bool flag = true;

            for (int i = 0; i < _faces.Count - 1 && flag == true; i++)
            {
                flag = false;
                for (int j = 0; j < _faces.Count - 1; j++)
                {
                    if (_faces[j + 1].Center.Z > _faces[j].Center.Z)
                    {
                        temp = _faces[j];
                        _faces[j] = _faces[j + 1];
                        _faces[j + 1] = temp;
                        flag = true;
                    }
                }
            }
        }

        /// <summary>
        /// Yaws the polyhedron about the z coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to yaw.</param>
        /// <param name="point">Point to yaw about.</param>
        public void YawZ(double angle, Point point)
        {
            for(int i = 0; i < _faces.Count; i++)
            {
                _faces[i].YawZ(angle, point);
            }
        }
    }
}