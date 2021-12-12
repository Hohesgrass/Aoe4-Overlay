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
        public Bitmap GetPlayer1()
        {
            Rectangle rect = new Rectangle(134, 220, 150, 50);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("C:\\Users\\alexa\\OneDrive - htw-berlin.de\\Bilder\\Screenshots\\aoe1.bmp", ImageFormat.Bmp);
            return bmp;
        }
        public Bitmap GetPlayer2()
        {
            Rectangle rect = new Rectangle(134, 280, 150, 50);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("C:\\Users\\alexa\\OneDrive - htw-berlin.de\\Bilder\\Screenshots\\aoe2.bmp", ImageFormat.Bmp);
            return bmp;
        }
        public Bitmap GetPlayer3()
        {
            Rectangle rect = new Rectangle(134, 340  , 150, 50);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("C:\\Users\\alexa\\OneDrive - htw-berlin.de\\Bilder\\Screenshots\\aoe3.bmp", ImageFormat.Png);
            return bmp;
        }
        public Bitmap GetPlayer4()
        {
            Rectangle rect = new Rectangle(134, 400, 150, 50);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            bmp.Save("C:\\Users\\alexa\\OneDrive - htw-berlin.de\\Bilder\\Screenshots\\aoe4.bmp", ImageFormat.Bmp);
            return bmp;
        }
    }
}
