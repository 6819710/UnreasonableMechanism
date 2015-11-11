using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismEngineCS
{
    /// <summary>
    /// Set of tools to detect polygon collisions in the X-Y plane.
    /// </summary>
    public static class PolygonCollisions
    {
        public struct PolygonCollisionResult
        {
            public bool WillIntersect;
            public bool Intersect;
            public Vector MinimumTranslationVector;
        }

        public static void ProjectPolygon(Vector axis, Polygon polygon, ref double min, ref double max)
        {
            double dotProduct = axis.DotProduct(polygon.Vertices[0].ToVector());
            min = dotProduct;
            max = dotProduct;
            for(int i = 0; i < polygon.Vertices.Count; i++)
            {
                dotProduct = polygon.Vertices[i].ToVector().DotProduct(axis);
                if(dotProduct < min)
                {
                    min = dotProduct;
                }
                else if(dotProduct > max)
                {
                    max = dotProduct;
                }
            }
        }

        public static double IntervalDisance(double minA, double maxA, double minB, double maxB)
        {
            if(minA < minB)
            {
                return minB - maxA;
            }
            else
            {
                return minA - maxB;
            }
        }

        public static PolygonCollisionResult PolygonCollision(Polygon a, Polygon b, Vector velocity)
        {
            PolygonCollisionResult result = new PolygonCollisionResult();
            result.WillIntersect = true;
            result.Intersect = true;

            int edgeCountA = a.Edges.Count;
            int edgeCountB = b.Edges.Count;
            double minIntervalDistance = double.PositiveInfinity;
            Vector traslationAxis = new Vector();
            Vector edge;

            for(int edgeIndex = 0; edgeIndex < edgeCountA + edgeCountB; edgeIndex++)
            {
                if(edgeIndex < edgeCountA)
                {
                    edge = a.Edges[edgeIndex];
                }
                else
                {
                    edge = b.Edges[edgeIndex - edgeCountA];
                }

                Vector axis = edge.PerpendicularVector2D();
                axis = axis.Unit;

                double minA = 0;
                double maxA = 0;
                double minB = 0;
                double maxB = 0;

                ProjectPolygon(axis, a, ref minA, ref maxA);
                ProjectPolygon(axis, b, ref minB, ref maxB);

                if (IntervalDisance(minA, maxA, minB, maxB) > 0)
                {
                    result.Intersect = false;
                }

                double velosityProjection = axis.DotProduct(velocity);

                if(velosityProjection < 0)
                {
                    minA += velosityProjection;
                }
                else
                {
                    maxA += velosityProjection;
                }

                double intervalDistance = IntervalDisance(minA, maxA, minB, maxB);
                if(intervalDistance > 0)
                {
                    result.WillIntersect = false;
                }

                if(!result.Intersect && !result.WillIntersect)
                {
                    break;
                }

                intervalDistance = Math.Abs(intervalDistance);
                if(intervalDistance < minIntervalDistance)
                {
                    minIntervalDistance = intervalDistance;
                    traslationAxis = axis;

                    Point d = a.Centroid - b.Centroid;
                    if(d.ToVector().DotProduct(traslationAxis) < 0)
                    {
                        traslationAxis = traslationAxis * -1;
                    }
                }
            }

            if(result.WillIntersect)
            {
                result.MinimumTranslationVector = traslationAxis * minIntervalDistance;
            }

            return result;
        }

        /// <summary>
        /// Determines weather the polygons collide in the x-y plane.
        /// </summary>
        /// <param name="polygonA">Polygon a.</param>
        /// <param name="polygonB">Polygon b.</param>
        /// <returns>Boolean.</returns>
        public static bool Collides(Polygon polygonA, Polygon polygonB)
        {
            bool result = true;

            int edgeCountA = polygonA.Edges.Count;
            int edgeCountB = polygonB.Edges.Count;
            Vector edge;

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

                Vector axis = edge.PerpendicularVector2D();
                axis = axis.Unit;

                double minA = 0;
                double maxA = 0;
                double minB = 0;
                double maxB = 0;

                ProjectPolygon(axis, polygonA, ref minA, ref maxA);
                ProjectPolygon(axis, polygonB, ref minB, ref maxB);

                if (IntervalDisance(minA, maxA, minB, maxB) > 0)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}