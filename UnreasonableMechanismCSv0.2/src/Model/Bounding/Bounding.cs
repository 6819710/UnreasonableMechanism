using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public class Bounding
    {
        private Polygon2D _polygon;

        /// <summary>
        /// Sets the inital values for the bounding polygon.
        /// </summary>
        /// <param name="vertices">array of verticies of the polygon</param>
        public Bounding(Point2D[] vertices)
        {
            _polygon = new Polygon2D(vertices);
        }

        /// <summary>
        /// Accessor for the bounding polygon.
        /// </summary>
        public Polygon2D Polygon
        {
            get
            {
                return _polygon;
            }

            set
            {
                _polygon = value;
            }
        }

        /// <summary>
        /// returns the position of the bounding polygon.
        /// </summary>
        public Point2D Position
        {
            get
            {
                return _polygon.Center;
            }
        }

        /// <summary>
        /// Returns the x coordinate of the bounding polygon.
        /// </summary>
        public double X
        {
            get
            {
                return _polygon.Center.X;
            }
        }

        /// <summary>
        /// Returns the y coordinate of the bounding polygon.
        /// </summary>
        public double Y
        {
            get
            {
                return _polygon.Center.Y;
            }
        }

        public PolygonCollisionResult PolygonCollision(Polygon2D polygonA, Polygon2D polygonB, Vector2D velocity)
        {
            PolygonCollisionResult result = new PolygonCollisionResult();
            result.Intersect = true;
            result.WillIntersect = true;

            int edgeCountA = polygonA.Edges.Count;
            int edgeCountB = polygonB.Edges.Count;
            double minIntervalDistance = double.PositiveInfinity;
            Vector2D translationAxis = new Vector2D();
            Vector2D edge;

            // Loop through all the edges of both polygons
            for (int edgeIndex = 0; edgeIndex < edgeCountA + edgeCountB; edgeIndex++)
            {
                if (edgeIndex < edgeCountA)
                {
                    edge = polygonA.Edges[edgeIndex];
                }
                else
                {
                    edge = polygonB.Edges[edgeIndex - edgeCountA];
                }

                // ===== 1. Find if the polygons are currently intersecting =====

                // Find the axis perpendicular to the current edge
                Vector2D axis = new Vector2D(-edge.j, edge.i);
                axis.Normalise();

                // Find the projection of the polygon on the current axis
                double minA = 0; double minB = 0; double maxA = 0; double maxB = 0;
                ProjectPolygon(axis, polygonA, ref minA, ref maxA);
                ProjectPolygon(axis, polygonB, ref minB, ref maxB);

                // Check if the polygon projections are currentlty intersecting
                if (IntervalDistance(minA, maxA, minB, maxB) > 0)
                {
                    result.Intersect = false;
                }

                // ===== 2. Now find if the polygons *will* intersect =====

                // Project the velocity on the current axis
                double velocityProjection = axis.Dot(velocity);

                // Get the projection of polygon A during the movement
                if (velocityProjection < 0)
                {
                    minA += velocityProjection;
                }
                else
                {
                    maxA += velocityProjection;
                }

                // Do the same test as above for the new projection
                double intervalDistance = IntervalDistance(minA, maxA, minB, maxB);
                if (intervalDistance > 0) result.WillIntersect = false;

                // If the polygons are not intersecting and won't intersect, exit the loop
                if (!result.Intersect && !result.WillIntersect) break;

                // Check if the current interval distance is the minimum one. If so store
                // the interval distance and the current distance.
                // This will be used to calculate the minimum translation vector
                intervalDistance = Math.Abs(intervalDistance);
                if (intervalDistance < minIntervalDistance)
                {
                    minIntervalDistance = intervalDistance;
                    translationAxis = axis;

                    Vector2D d =new Vector2D(polygonA.Center, polygonB.Center);
                    if (d.Dot(translationAxis) < 0)
                    {
                        translationAxis.Direction += 180;
                    }
                }
            }

            // The minimum translation vector
            // can be used to push the polygons appart.
            if (result.WillIntersect)
            {
                result.MinimumTranslationVector = new Vector2D(translationAxis.i * minIntervalDistance, translationAxis.j * minIntervalDistance);
            }
                

            return result;
        }

        public void Draw(bool colides)
        {
            if(colides)
            {
                _polygon.Draw(Color.Red);
            }
            else
            {
                _polygon.Draw(Color.Black);
            }
        }

        protected void ProjectPolygon(Vector2D axis, Polygon2D polygon, ref double min, ref double max)
        {
            double dotProduct = axis.Dot(polygon.Vertices[0]);
            min = dotProduct;
            max = dotProduct;

            foreach (Point2D vertex in polygon.Vertices)
            {
                dotProduct = axis.Dot(vertex);
                if (dotProduct < min)
                {
                    min = dotProduct;
                }
                else if (dotProduct > max)
                {
                    max = dotProduct;
                }
            }
        }

        protected double IntervalDistance(double minA, double maxA, double minB, double maxB)
        {
            if (minA < minB)
            {
                return minB - maxA;
            }
            else
            {
                return minA - maxB;
            }
        }

        public void Offset(Vector2D vector)
        {
            _polygon.Offset(vector);
        }

        public void Offset(Point2D point)
        {
            _polygon.Offset(point);
        }
    }
}