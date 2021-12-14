using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;

namespace Aoe4_Overlay
{
    internal class Screenshooter
    {
        public Bitmap TakeScreenshot(Rectangle playerPosition)
        {
            Bitmap bmp = new Bitmap(playerPosition.Width, playerPosition.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(playerPosition.Left, playerPosition.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            return bmp;
        }
    }
}
