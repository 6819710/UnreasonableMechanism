using System.Collections.Generic;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    /// <summary>
    /// Polyhedron defines 3D Objects made up of 2D faces (polygon).
    /// </summary>
    public class Polyhedron
    {
        /// <summary>
        /// List of 2D Faces (polygon).
        /// </summary>
        private List<Polygon> _faces;

        private Point _trajectory;
        private Point _roll;

        /// <summary>
        /// Constructs an empty polyhedron.
        /// </summary>
        public Polyhedron()
        {
            _faces = new List<Polygon>();
            _trajectory = Center;
            _trajectory.x += 1;
            _roll = Center;
            _roll.y += 1;
        }

        /// <summary>
        /// Constructs a polyhedron with the provided faces.
        /// </summary>
        /// <param name="faces">Array of faces (polygon)</param>
        public Polyhedron(Polygon[] faces)
        {
            _faces = new List<Polygon>(faces);
            _trajectory = Center;
            _trajectory.x += 1;
            _roll = Center;
            _roll.y += 1;
        }

        /// <summary>
        /// Constructs a polhedron with the provided faces at the given location.
        /// </summary>
        /// <param name="faces">Array of faces (polygon)</param>
        /// <param name="location">Location (point)</param>
        public Polyhedron(Polygon[] faces, Point location)
        {
            _faces = new List<Polygon>(faces);
            Offset(new Vector(Center, location));

        }

        /// <summary>
        /// Returns the center point of the polyhedron (Calculated)
        /// </summary>
        public Point Center
        {
            get
            {
                Point result = new Point();
                int count = 0;
                foreach (Polygon face in _faces)
                {
                    foreach (Point vertex in face.Vertices)
                    {
                        result += vertex;
                        count++;
                    }
                }
                return result / count;
            }
        }

        /// <summary>
        /// Returns the list of faces (polygon).
        /// </summary>
        public List<Polygon> Faces
        {
            get
            {
                return _faces;
            }
        }

        //TODO: addFace(face)

        /// <summary>
        /// Draws the polyhedron.
        /// </summary>
        /// <param name="clrFace">Colour to draw faces.</param>
        /// <param name="clrEdge">Colour to draw edges.</param>
        /// <param name="clrVertex">Colour to draw vertices.</param>
        public void Draw(Color clrFace, Color clrEdge, Color clrVertex)
        {
            Sort();
            foreach(Polygon face in _faces)
            {
                face.Draw(clrFace, clrEdge, clrVertex);
            }
        }

        /// <summary>
        /// Draws the polyhedron.
        /// </summary>
        /// <param name="clrFace">Colour to draw the faces.</param>
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
        /// Draws the polyhedron
        /// </summary>
        /// <param name="clrFace">Colour to draw the faces.</param>
        public void Draw(Color clrFace)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.Draw(clrFace);
            }
        }

        /// <summary>
        /// Draws the polyhedron faces.
        /// </summary>
        /// <param name="clr">Colour to draw the faces.</param>
        public void DrawFace(Color clr)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.DrawFace(clr);
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
        /// Draws the polyhedron vertices
        /// </summary>
        /// <param name="clr">Colour to draw the vertices.</param>
        public void DrawVertex(Color clr)
        {
            Sort();
            foreach (Polygon face in _faces)
            {
                face.DrawVertex(clr);
            }
        }

        /// <summary>
        /// Offsets the polyhedron by the given movement (vector)
        /// </summary>
        /// <param name="movement">Movement (vector)</param>
        public void Offset(Vector movement)
        {
            foreach(Polygon face in _faces)
            {
                face.Offset(movement);
            }
        }

        /// <summary>
        /// Offsets the polyhedron by the given cartesian coordinates.
        /// </summary>
        /// <param name="x">Offset in x.</param>
        /// <param name="y">Offset in y.</param>
        /// <param name="z">Offset in z.</param>
        public void Offset(double x, double y, double z)
        {
            Offset(new Vector(x, y, z));
        }

        public void RotateAboutPoint(double yaw, double pitch, double roll, Point point, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].RotateAboutPoint(yaw, pitch, roll, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Rotate(_trajectory, yaw, pitch, roll, point, trajectory, vRoll);
            _roll = Rotation.Rotate(_trajectory, yaw, pitch, roll, point, trajectory, vRoll);
        }
        
        public void RotateAboutPoint(double yaw, double pitch, double roll, Point point)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].RotateAboutPoint(yaw, pitch, roll, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Rotate(_trajectory, yaw, pitch, roll, point, trajectory, vRoll);
            _roll = Rotation.Rotate(_trajectory, yaw, pitch, roll, point, trajectory, vRoll);
        }
        
        public void RotateAboutCenter(double yaw, double pitch, double roll, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].RotateAboutPoint(yaw, pitch, roll, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Rotate(_trajectory, yaw, pitch, roll, Center, trajectory, vRoll);
            _roll = Rotation.Rotate(_trajectory, yaw, pitch, roll, Center, trajectory, vRoll);
        }
        
        public void RotateAboutCenter(double yaw, double pitch, double roll)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].RotateAboutPoint(yaw, pitch, roll, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Rotate(_trajectory, yaw, pitch, roll, Center, trajectory, vRoll);
            _roll = Rotation.Rotate(_trajectory, yaw, pitch, roll, Center, trajectory, vRoll);
        }
        
        public void YawAboutPoint(double yaw, Point point, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].YawAboutPoint(yaw, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Yaw(_trajectory, yaw, point, trajectory, vRoll);
            _roll = Rotation.Yaw(_trajectory, yaw, point, trajectory, vRoll);
        }

        public void YawAboutPoint(double yaw, Point point)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].YawAboutPoint(yaw, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Yaw(_trajectory, yaw, point, trajectory, vRoll);
            _roll = Rotation.Yaw(_trajectory, yaw, point, trajectory, vRoll);
        }

        public void YawAboutCenter(double yaw, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].YawAboutPoint(yaw, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Yaw(_trajectory, yaw, Center, trajectory, vRoll);
            _roll = Rotation.Yaw(_trajectory, yaw, Center, trajectory, vRoll);
        }

        public void YawAboutCenter(double yaw)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].YawAboutPoint(yaw, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Yaw(_trajectory, yaw, Center, trajectory, vRoll);
            _roll = Rotation.Yaw(_trajectory, yaw, Center, trajectory, vRoll);
        }

        public void PitchAboutPoint(double pitch, Point point, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].PitchAboutPoint(pitch, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            _roll = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
        }

        public void PitchAboutPoint(double pitch, Point point)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].PitchAboutPoint(pitch, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Pitch(_trajectory, pitch, point, vRoll);
            _roll = Rotation.Pitch(_trajectory, pitch, point, vRoll);
        }

        public void PitchAboutCenter(double pitch, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].PitchAboutPoint(pitch, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            _roll = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
        }

        public void PitchAboutCenter(double pitch)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].PitchAboutPoint(pitch, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
            _roll = Rotation.Pitch(_trajectory, pitch, Center, vRoll);
        }

        public void RollAboutPoint(double roll, Point point, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].RollAboutPoint(roll, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Roll(_trajectory, roll, point, trajectory);
            _roll = Rotation.Roll(_trajectory, roll, point, trajectory);
        }

        public void RollAboutPoint(double roll, Point point)
        {
            Vector trajectory = new Vector(Center, _trajectory);
            Vector vRoll = new Vector(Center, _roll);
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].RollAboutPoint(roll, point, trajectory, vRoll);
            }
            _trajectory = Rotation.Roll(_trajectory, roll, point, trajectory);
            _roll = Rotation.Roll(_trajectory, roll, point, trajectory);
        }

        public void RollAboutCenter(double roll, Vector trajectory, Vector vRoll)
        {
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].RollAboutPoint(roll, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Roll(_trajectory, roll, Center, trajectory);
            _roll = Rotation.Roll(_trajectory, roll, Center, trajectory);
        }

        public void RollAboutCenter(double roll)
        {
            Vector trajectory = new Vector(_trajectory);
            Vector vRoll = new Vector(_roll);
            for (int i = 0; i < _faces.Count; ++i)
            {
                _faces[i].RollAboutPoint(roll, Center, trajectory, vRoll);
            }
            _trajectory = Rotation.Roll(_trajectory, roll, Center, trajectory);
            _roll = Rotation.Roll(_trajectory, roll, Center, trajectory);
        }
        
        public void Scale(double scale)
        {
            foreach(Polygon face in _faces)
            {
                face.Scale(scale, Center);
            }
        }












        

        /// <summary>
        /// Sorts the faces in order of Z based on the center point of each face.
        /// </summary>
        private void Sort()
        {
            Polygon temp;
            bool flag = true;

            for(int i = 0; i < _faces.Count - 1 && flag == true; i++)
            {
                flag = false;
                for(int j = 0; j < _faces.Count - 1; j++)
                {
                    if(_faces[j + 1].Center.z > _faces[j].Center.z)
                    {
                        temp = _faces[j];
                        _faces[j] = _faces[j + 1];
                        _faces[j + 1] = temp;
                        flag = true;
                    }
                }
            }
        }

        public bool GreaterThanX(double x)
        {
            foreach(Polygon face in _faces)
            {
                if(face.GreaterThanX(x))
                {
                    return true;
                }
            }
            return false;
        }

        public bool LessThanX(double x)
        {
            foreach (Polygon face in _faces)
            {
                if (face.LessThanX(x))
                {
                    return true;
                }
            }
            return false;
        }

        public bool GreaterThanY(double y)
        {
            foreach (Polygon face in _faces)
            {
                if (face.GreaterThanY(y))
                {
                    return true;
                }
            }
            return false;
        }

        public bool LessThanY(double y)
        {
            foreach (Polygon face in _faces)
            {
                if (face.LessThanY(y))
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceGreaterThanX(x) > distance)
                {
                    distance = face.MaxDistanceGreaterThanX(x);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceGreaterThanX(x) < distance)
                {
                    distance = face.MinDistanceGreaterThanX(x);
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceLessThanX(x) > distance)
                {
                    distance = face.MaxDistanceLessThanX(x);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceLessThanX(x) < distance)
                {
                    distance = face.MinDistanceLessThanX(x);
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceFromX(x) > distance)
                {
                    distance = face.MaxDistanceFromX(x);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceFromX(x) < distance)
                {
                    distance = face.MinDistanceFromX(x);
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceGreaterThanY(y) > distance)
                {
                    distance = face.MaxDistanceGreaterThanY(y);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceGreaterThanY(y) < distance)
                {
                    distance = face.MinDistanceGreaterThanY(y);
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceLessThanY(y) > distance)
                {
                    distance = face.MaxDistanceLessThanY(y);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceLessThanY(y) < distance)
                {
                    distance = face.MinDistanceLessThanY(y);
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceFromY(y) > distance)
                {
                    distance = face.MaxDistanceFromY(y);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceFromY(y) < distance)
                {
                    distance = face.MinDistanceFromY(y);
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceGreaterThanZ(z) > distance)
                {
                    distance = face.MaxDistanceGreaterThanZ(z);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceGreaterThanZ(z) < distance)
                {
                    distance = face.MinDistanceGreaterThanZ(z);
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceLessThanZ(z) > distance)
                {
                    distance = face.MaxDistanceLessThanZ(z);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceLessThanZ(z) < distance)
                {
                    distance = face.MinDistanceLessThanZ(z);
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
            foreach (Polygon face in _faces)
            {
                if (face.MaxDistanceFromZ(z) > distance)
                {
                    distance = face.MaxDistanceFromZ(z);
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
            foreach (Polygon face in _faces)
            {
                if (face.MinDistanceFromZ(z) < distance)
                {
                    distance = face.MinDistanceFromZ(z);
                }
            }
            return distance;
        }
    }
}