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
    internal class OCRManager
    {
        private readonly IronTesseract ironOcr;

        internal OCRManager()
        {
            ironOcr = new IronTesseract();
        }

        public string DoOCR(Rectangle screenPosition)
        {
            Screenshooter screen = new Screenshooter();
            ironOcr.Language = OcrLanguage.EnglishBest;
            string result = new IronTesseract().Read(EnhanceInput(screen.TakeScreenshot(screenPosition))).Text;
            return result;
        }

        private OcrInput EnhanceInput(Bitmap bitmap)
        {
            var Input = new OcrInput(bitmap);
            Input.EnhanceResolution();
            Input.Contrast();
            Input.Invert();
            return Input;
        }
    }
}
