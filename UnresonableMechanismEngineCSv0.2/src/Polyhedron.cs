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
            foreach(Polygon face in _faces)
            {
                face.PitchY(angle, point);
            }
        }

        /// <summary>
        /// Rolls the polyhedron about the x coordinate of the given point.
        /// </summary>
        /// <param name="angle">Angle to roll.</param>
        /// <param name="point">Point to roll about.</param>
        public void RollX(double angle, Point point)
        {
            foreach (Polygon face in _faces)
            {
                face.RollX(angle, point);
            }
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
            foreach (Polygon face in _faces)
            {
                face.YawZ(angle, point);
            }
        }
    }
}