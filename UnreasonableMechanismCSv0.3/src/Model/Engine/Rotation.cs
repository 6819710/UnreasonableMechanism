using System;

namespace UnrealMechanismCS
{
    /// <summary>
    /// Rotation defines the rotation equations.
    /// </summary>
    public static class Rotation
    {
        /// <summary>
        /// Rotates the point about the axis provided by the angle provided
        /// </summary>
        /// <param name="point">Point to rotate.</param>
        /// <param name="angle">Angle to rotate (radians).</param>
        /// <param name="axis">Axis to rotate about (vector).</param>
        /// <returns></returns>
        private static Point RotateAboutAxis(Point point, double angle, Vector axis)
        {
            Vector u = axis.Unit;

            double ux = u.i;
            double uy = u.j;
            double uz = u.k;

            double c = Math.Cos(angle);
            double C = 1 - c;
            double s = Math.Sin(angle);

            double a1 = c + (ux * ux * C);
            double a2 = (ux * uy * C) - (uz * s);
            double a3 = (ux * uz * C) + (uy * s);

            double b1 = (uy * ux * C) + (uz * s);
            double b2 = c + (uy * uy * C);
            double b3 = (uy * uz * C) - (ux * s);

            double x = point.x;
            double y = point.y;
            double z = point.z;

            point.x = ((Math.Cos(angle) + (u.i * (1 - Math.Cos(angle)))) * x) + (((u.i * u.j * (1 - Math.Cos(angle))) - (u.k * Math.Sin(angle))) * y) + (((u.i * u.k * (1 - Math.Cos(angle))) + (u.j * Math.Sin(angle))) * z);
            point.y = (((u.j * u.i * (1 - Math.Cos(angle))) + (u.k * Math.Sin(angle))) * x) + ((Math.Cos(angle) + (u.j * (1 - Math.Cos(angle)))) * y) + (((u.j * u.k * (1 - Math.Cos(angle))) - (u.i * Math.Sin(angle))) * z);
            point.z = (((u.k * u.i * (1 - Math.Cos(angle))) - (u.j * Math.Sin(angle))) * x) + (((u.k * u.j * (1 - Math.Cos(angle))) + (u.i * Math.Sin(angle))) * y) + ((Math.Cos(angle) + (u.k * (1 - Math.Cos(angle)))) * z);
            return point;
        }

        /// <summary>
        /// Rolls the point about the axis provided.
        /// </summary>
        /// <param name="pointToRotate"></param>
        /// <param name="angle"></param>
        /// <param name="pointToRotateAbout"></param>
        /// <param name="trajectory"></param>
        /// <returns></returns>
        public static Point Roll(Point pointToRotate, double angle, Point pointToRotateAbout, Vector trajectory)
        {
            pointToRotate = RotateAboutAxis(pointToRotate - pointToRotateAbout, angle, trajectory);
            return pointToRotate + pointToRotateAbout;
        }

        public static Point Roll(Point pointToRotate, double angle, Point pointToRotateAbout)
        {
            pointToRotate -= pointToRotateAbout;

            pointToRotate.y = (Math.Cos(angle) * pointToRotate.y) + (Math.Sin(angle) * pointToRotate.z);
            pointToRotate.z = -(Math.Sin(angle) * pointToRotate.y) + (Math.Cos(angle) * pointToRotate.z);

            pointToRotate += pointToRotateAbout;
            return pointToRotate;
        }

        public static Point Pitch(Point pointToRotate, double angle, Point pointToRotateAbout, Vector roll)
        {
            pointToRotate = RotateAboutAxis(pointToRotate - pointToRotateAbout, angle, roll);
            return pointToRotate + pointToRotateAbout;
        }

        public static Point Yaw(Point pointToRotate, double angle, Point pointToRotateAbout, Vector trajectory, Vector roll)
        {
            pointToRotate = RotateAboutAxis(pointToRotate - pointToRotateAbout, angle, trajectory.Cross(roll));
            return pointToRotate + pointToRotateAbout;
        }

        public static Point Rotate(Point pointToRotate, double yaw, double pitch, double roll, Point pointToRotateAbout, Vector trajectory, Vector vroll)
        {
            pointToRotate = RotateAboutAxis(pointToRotate, yaw, trajectory.Cross(vroll));
            pointToRotate = RotateAboutAxis(pointToRotate, pitch, vroll);
            pointToRotate = RotateAboutAxis(pointToRotate, roll, trajectory);
            return pointToRotate + pointToRotateAbout;
        }
    }
}