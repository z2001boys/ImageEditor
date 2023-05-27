using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditorLib
{
    internal static class Utils
    {
        //pointf * pointf
        public static PointF Multiply(this PointF p1, PointF p2)
        {
            return new PointF(p1.X * p2.X, p1.Y * p2.Y);
        }
        //pointf - pointf
        public static PointF Minus(this PointF p1, PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }
        //pointf + pointf
        public static PointF Add(this PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }

        //pointf * sizef
        public static PointF Multiply(this PointF p1, SizeF p2)
        {
            return new PointF(p1.X * p2.Width, p1.Y * p2.Height);
        }

        //sizef * sizef
        public static SizeF Multiply(this SizeF p1, SizeF p2)
        {
            return new SizeF(p1.Width * p2.Width, p1.Height * p2.Height);
        }
        //rectangle f to rectangle
        public static Rectangle ToRectangle(this RectangleF rect)
        {
            return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }
        //inverse sizef
        public static SizeF Inverse(this SizeF size)
        {
            return new SizeF(1 / size.Width, 1 / size.Height);
        }
        //pointf to point
        public static Point ToPoint(this PointF point)
        {
            return new Point((int)point.X, (int)point.Y);
        }
        //point to pointf
        public static PointF ToPointF(this Point point)
        {
            return new PointF(point.X, point.Y);
        }
        //pointf to sizef
        public static SizeF ToSizeF(this PointF point)
        {
            return new SizeF(point.X, point.Y);
        }
        //check pointf equal
        public static bool PointEqual(this PointF p1, PointF p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        //distance of two pointf
        public static float Distance(this PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        //min of two pointf
        public static PointF Min(this PointF p1, PointF p2)
        {
            return new PointF(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
        }
        //abs of pointf
        public static PointF Abs(this PointF p1)
        {
            return new PointF(Math.Abs(p1.X), Math.Abs(p1.Y));
        }
    }
}
