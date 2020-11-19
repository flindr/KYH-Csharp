using System;
using System.Drawing;

namespace Greyer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var bitmap = new Bitmap(@"C:\Users\FredrikLindroth\Desktop\bild2.jpg");

            for (int y = 0; y < bitmap.Width; y++)
            {
                for (int x = 0; x < bitmap.Height; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int colorMean = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    bitmap.SetPixel(x, y, Color.FromArgb(pixelColor.A, colorMean, colorMean, colorMean));
                }
            }

            bitmap.Save(@"C:\Users\FredrikLindroth\Desktop\processed.jpg");
            

        }
    }
}