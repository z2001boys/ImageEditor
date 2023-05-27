using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditorLib
{
    internal class RectangleObject : IVisObject
    {
        public PointF StartPoint { get; set; } = new PointF(0, 0);
        public PointF EndPoint { get; set; } = new PointF(0, 0);

        public SizeF Size
        {
            get
            {
                //return endpoint-startpoint
                return new SizeF(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
            }
        }

        public RectangleObject()
        {

        }

        public Color Color { get; set; } = Color.Blue;
        public int LineWidth { get; set; } = 1;

        public int FirstDrawingAnchor => 0;

        public int SecondDrawingAnchor => 1;

        public string Name { get; set; }

        public void Drawing(Graphics g, SizeF factor)
        {
            if (StartPoint.PointEqual(EndPoint)) return;

            var start = StartPoint.Multiply(factor);
            var end = EndPoint.Multiply(factor);

            using (var pen = new Pen(Color, LineWidth))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                var newStart = start.Min(end);
                var rect = new RectangleF(
                    newStart,
                    end.Minus(start).Abs().ToSizeF());
                g.DrawString(Name, new Font("Arial", 10), Brushes.Black, rect.X, rect.Y + rect.Height);
                g.DrawRectangle(pen, rect.ToRectangle());
            }





            using (var pen = new Pen(Color, LineWidth))
            {
                g.DrawEllipse(pen, start.X - 3, start.Y - 3, 6, 6);
                g.DrawEllipse(pen, end.X - 3, end.Y - 3, 6, 6);
            }
        }

        public List<PointF> GetAnchor()
        {
            return new List<PointF> { StartPoint, EndPoint };
        }

        public void SetAnchor(List<PointF> anchor)
        {
            if (anchor == null) return;
            if (anchor.Count != 2) return;
            StartPoint = anchor[0];
            EndPoint = anchor[1];
        }

        public void SetAnchor(PointF anchor, int index)
        {
            if (index == 0) StartPoint = anchor;
            if (index == 1) EndPoint = anchor;


        }
    }
}
