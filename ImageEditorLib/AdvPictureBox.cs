using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditorLib
{
    public partial class AdvPictureBox : UserControl
    {
        private Point mouseAnchor;
        private Point lastPosition;
        private double zoomFactor = 1.0;
        enum MouseActionEm { None, Moving, Drawing, Modifying }
        private MouseActionEm mouseAction = MouseActionEm.None;


        public List<IVisObject> AllVisObjects = new List<IVisObject>();
        private IVisObject _currentDrawingObject;
        private int _drawingAnchor = -1;

        //do not change this!!
        bool _canDisplayObject = false;
        public bool DisplayAllObject
        {
            get => _canDisplayObject;
            private set
            {
                if (_canDisplayObject == value) return;

                if (value == true)
                {
                    pictureBox1.Paint += DisplayObject;
                }
                else
                {
                    pictureBox1.Paint -= DisplayObject;
                }

                _canDisplayObject = value;

            }
        }
        //do not change this
        bool _canDisplayDrawingObject = false;
        public bool DisplayCurrentDrawing
        {
            get => _canDisplayDrawingObject;
            private set
            {
                if (_canDisplayDrawingObject == value) return;

                if (value == true)
                {
                    pictureBox1.Paint += DisplayDrawingObject;
                }
                else
                {
                    pictureBox1.Paint -= DisplayDrawingObject;
                }

                _canDisplayDrawingObject = value;

            }
        }

        PointF PanelCenter => new PointF(panel1.Width / 2, panel1.Height / 2);

        [Obsolete]
        public AdvPictureBox()
        {
            InitializeComponent();

            //初始化picturebox尺寸
            pictureBox1.Size = this.Size;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.SizeChanged += AdvPictureBox_SizeChanged;


            // 捕捉滾輪事件
            MouseWheel += PictureBox_MouseWheel;

            // 捕捉滑鼠拖拉動作
            pictureBox1.MouseDown += PictureBox_MouseDown;
            pictureBox1.MouseMove += PictureBox_MouseMove;
            pictureBox1.MouseUp += PictureBox_MouseUp;
            //繪圖事件
            DisplayAllObject = true;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void DisplayObject(object sender, PaintEventArgs e)
        {

            var factor = GetFactor();

            foreach (var item in AllVisObjects)
            {
                item.Drawing(e.Graphics, factor);
            }
        }

        private void DisplayDrawingObject(object sender, PaintEventArgs e)
        {
            var factor = GetFactor();
            _currentDrawingObject.Drawing(e.Graphics, factor);
        }

        private SizeF GetFactor()
        {
            if (pictureBox1.Image == null)
                return new SizeF(0, 0);

            //return the factor of pictureBoxSize and pictureBox image size
            var pictureBoxSize = pictureBox1.Size;
            var imageSize = pictureBox1.Image.Size;
            var factor = new SizeF(
                              (float)pictureBoxSize.Width / (float)imageSize.Width,
                                              (float)pictureBoxSize.Height / (float)imageSize.Height);
            return factor;

        }

        public void UpdateShow()
        {
            pictureBox1.Refresh();
        }


        private void AdvPictureBox_SizeChanged(object sender, EventArgs e)
        {
            ResetPictureBox();
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseAction == MouseActionEm.Moving)
            {
                mouseAction = MouseActionEm.None;
            }
            else if (mouseAction == MouseActionEm.Drawing)
            {
                mouseAction = MouseActionEm.None;
                AllVisObjects.Add(_currentDrawingObject);
                _currentDrawingObject = null;
                _drawingAnchor = -1;
                DisplayCurrentDrawing = false;
                DisplayAllObject = true;
                pictureBox1.Refresh();
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == MouseActionEm.Moving)
            {
                var pos = Cursor.Position;
                int deltaX = pos.X - mouseAnchor.X;
                int deltaY = pos.Y - mouseAnchor.Y;
                Debug.Print($"{mouseAnchor}+({deltaX},{deltaY})");
                pictureBox1.Location = new Point(lastPosition.X + deltaX, lastPosition.Y + deltaY);
            }
            else if (mouseAction == MouseActionEm.Drawing && e.Button == MouseButtons.Left)
            {
                var imagePoint = ControlPointToImage(panel1.PointToClient(Cursor.Position));
                _currentDrawingObject.SetAnchor(imagePoint, _drawingAnchor);
                pictureBox1.Refresh();
            }

            //update pixel info
            if(pictureBox1.Image!=null)
            {
                var pointOnImage = ControlPointToImage(panel1.PointToClient(Cursor.Position)).ToPoint();
                var color = ((Bitmap)pictureBox1.Image).GetPixel(pointOnImage.X, pointOnImage.Y);
                PixelInfo.Text = $"x,y=({pointOnImage.X},{pointOnImage.Y})";
                RGBInfo.Text = $"rgb=({color.R},{color.G},{color.B})";
            }
            
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseAction == MouseActionEm.None)
            {
                if (HitSomeAnchor(out _currentDrawingObject, out _drawingAnchor))
                {
                    DisplayAllObject = false;
                    DisplayCurrentDrawing = true;
                    mouseAction = MouseActionEm.Drawing;
                    return;
                }

                mouseAction = MouseActionEm.Moving;
                //record mouse location
                mouseAnchor = Cursor.Position;
                //原本的位置
                lastPosition = pictureBox1.Location;
            }
            else if (mouseAction == MouseActionEm.Drawing)
            {
                var imagePoint = ControlPointToImage(panel1.PointToClient(Cursor.Position));
                _currentDrawingObject.SetAnchor(imagePoint, _currentDrawingObject.FirstDrawingAnchor);
                _currentDrawingObject.SetAnchor(imagePoint, _currentDrawingObject.SecondDrawingAnchor);
                _drawingAnchor = _currentDrawingObject.SecondDrawingAnchor;
                pictureBox1.Refresh();
            }
        }

        private bool HitSomeAnchor(out IVisObject obj, out int anchorIndex)
        {
            obj = null;
            anchorIndex = -1;

            var cursorOnControl = panel1.PointToClient(Cursor.Position).ToPointF();
            var factor = GetFactor();
            foreach (var vis in AllVisObjects)
            {
                //find vis's anchor is close to image pose
                var anchor = vis.GetAnchor();
                var idx = anchor.FindIndex(a => ImageToControlPoint(a).Distance(cursorOnControl) < 3);

                if (idx >= 0)
                {
                    obj = vis;
                    anchorIndex = idx;
                    return true;
                }

            }

            return false;
        }

        [Obsolete]
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoomFactor += 0.1;
            }
            else
            {
                zoomFactor = Math.Max(1.0, zoomFactor - 0.1);
            }

            if (zoomFactor == 1)
            {
                ResetPictureBox();
            }
            else
            {
                var newWidth = this.Size.Width * zoomFactor;
                var newHeight = this.Size.Height * zoomFactor;
                var centerOnImage = PanelCenter.Minus(pictureBox1.Location).Multiply(GetFactor().Inverse());

                pictureBox1.SuspendLayout();
                try
                {
                    pictureBox1.Size = new Size((int)newWidth, (int)newHeight);
                    pictureBox1.Location = PanelCenter.Minus(centerOnImage.Multiply(GetFactor())).ToPoint();
                }
                catch { }
                finally
                {
                    pictureBox1.ResumeLayout();
                }

            }

        }

        private void ResetPictureBox()
        {
            pictureBox1.SuspendLayout();
            try
            {
                pictureBox1.Location = new Point(0, 0);
                pictureBox1.Size = this.Size;
            }
            catch { }
            finally
            {
                pictureBox1.ResumeLayout();
            }

        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //show the image
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                ResetPictureBox();
            }
        }

        private void DrawRectangleBtn_Click(object sender, EventArgs e)
        {

            _currentDrawingObject = new RectangleObject();
            _currentDrawingObject.Name = FindNextName();
            DisplayAllObject = false;
            DisplayCurrentDrawing = true;


            mouseAction = MouseActionEm.Drawing;
            pictureBox1.Refresh();

        }

        private string FindNextName()
        {
            int idx = 0;
            while(true)
            {
                if (AllVisObjects.Any(o => o.Name == $"Object-{idx}"))
                {
                    idx++;
                    continue;
                }
                break;
            }
            return $"Object-{idx}";
        }

        private PointF ControlPointToImage(Point pt)
        {
            return ControlPointToImage(pt.ToPointF());
        }

        private PointF ControlPointToImage(PointF pt)
        {
            return pt.Minus(pictureBox1.Location).Multiply(GetFactor().Inverse());
        }

        private PointF ImageToControlPoint(PointF pt)
        {
            return pt.Multiply(GetFactor()).Add(pictureBox1.Location);
        }

        private void ClearObjectBtn_Click(object sender, EventArgs e)
        {
            AllVisObjects.Clear();
            pictureBox1.Refresh();
        }
    }
}
