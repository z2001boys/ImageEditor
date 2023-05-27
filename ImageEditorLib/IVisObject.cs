using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditorLib
{
    public interface IVisObject
    {
        Color Color { get; set; }
        int LineWidth { get; set; }
        void Drawing(Graphics g, SizeF factor);

        string Name { get; set; }


        List<PointF> GetAnchor();
        void SetAnchor(List<PointF> anchor);
        void SetAnchor(PointF anchor, int index);

        int FirstDrawingAnchor { get; }
        int SecondDrawingAnchor { get; }

    }
}
