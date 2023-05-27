using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditorLib
{
    internal interface IImageSource
    {
        Bitmap CreateBitMap();
        List<double> GetIntensity(int x,int y);
        Size GetSize();
    }


    public class BitMapImageSource : IImageSource, IDisposable
    {
        Bitmap bitmapHandle;
        public BitMapImageSource(string fileName)
        {
            using (Bitmap temp = new Bitmap(fileName))
            {
                bitmapHandle = new Bitmap(temp);
            }
        }
        public Bitmap CreateBitMap()
        {
            return bitmapHandle;
        }

        public void Dispose()
        {
            bitmapHandle.Dispose();
        }

        public List<double> GetIntensity(int x, int y)
        {
            var c = bitmapHandle.GetPixel(x, y);
            return new List<double>() { c.R, c.G, c.B };
        }

        public Size GetSize()
        {
            return bitmapHandle.Size;            
        }
    }

}
