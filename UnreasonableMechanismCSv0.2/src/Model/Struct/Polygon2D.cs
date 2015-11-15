using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public struct Polygon2D
    {
        public List<Point2D> Vertices;
        public List<Vector2D> Edges;

        public Polygon2D(Point2D[] vertices)
        {
            Vertices = new List<Point2D>(vertices);

            Edges = new List<Vector2D>();

            for (int i = 0; i < Vertices.Count; ++i)
            {
                if (i == Vertices.Count - 1)
                {
                    Edges.Add(new Vector2D(Vertices[i], Vertices[0]));
                }
                else
                {
                    Edges.Add(new Vector2D(Vertices[i], Vertices[i + 1]));
                }
            }
        }

        public void UpdateEdges()
        {
            Edges.Clear();
            for (int i = 0; i < Vertices.Count; ++i)
            {
                if (i == Vertices.Count - 1)
                {
                    Edges.Add(new Vector2D(Vertices[i], Vertices[0]));
                }
                else
                {
                    Edges.Add(new Vector2D(Vertices[i], Vertices[i + 1]));
                }
            }
        }

        public Point2D Center
        {
            get
            {
                double totalX = 0;
                double totalY = 0;
                foreach(Point2D vertex in Vertices)
                {
                    totalX += vertex.X;
                    totalY += vertex.Y;
                }
                return new Point2D(totalX / Vertices.Count, totalY / Vertices.Count);
            }
        }

        public void Offset(Vector2D vector)
        {
            for(int i = 0; i < Vertices.Count; ++i)
            {
                Point2D vertex = Vertices[i];
                Vertices[i] = new Point2D(vertex.X + vector.i, vertex.Y + vector.j);
            }
        }

        public void Offset(Point2D point)
        {
            for (int i = 0; i < Vertices.Count; ++i)
            {
                Point2D vertex = Vertices[i];
                Vertices[i] = new Point2D(vertex.X + point.X, vertex.Y + point.Y);
            }
        }

        public void Draw(Color clr)
        {
            for (int i = 0; i < Vertices.Count; ++i)
            {
                if (i == Vertices.Count - 1)
                {
                    SwinGame.DrawLine(clr, (float)Vertices[i].X, (float)Vertices[i].Y, (float)Vertices[0].X, (float)Vertices[0].Y);
                }
                else
                {
                    SwinGame.DrawLine(clr, (float)Vertices[i].X, (float)Vertices[i].Y, (float)Vertices[i + 1].X, (float)Vertices[i + 1].Y);
                }
            }
        }
    }
}