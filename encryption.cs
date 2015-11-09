using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ImageEncoder
{
    static class encryption
    {
        public static Bitmap encode(Bitmap img, int offSet)
        {
            Bitmap newImage = new Bitmap(img.Width * offSet, img.Height * offSet);
            List<List<Color>> pixelMap = new List<List<Color>>();
            for (int y = 0; y < img.Height; y++)
            {
                List<Color> row = new List<Color>();
                for (int x = 0; x < img.Width; x++)
                {
                    row.Add(img.GetPixel(x, y));
                }
                pixelMap.Add(row);
            }
            Random r = new Random();
            for (int y = 0; y < newImage.Height; y++)
            {
                for (int x = 0; x < newImage.Width; x++)
                {
                    if (x % offSet == 0 && y % offSet == 0)
                    {
                        newImage.SetPixel(x, y, pixelMap[y / offSet][x / offSet]);
                    }
                    else
                    {
                        newImage.SetPixel(x, y, img.GetPixel(r.Next(0, img.Width - 1), r.Next(0, img.Height - 1)));
                    }
                }
            }
            return newImage;
        }
        public static Bitmap decode(Bitmap img, int offSet)
        {
            Bitmap newImage = new Bitmap(img.Width / offSet, img.Height / offSet);
            List<List<Color>> pixelMap = new List<List<Color>>();
            for (int y = 0; y < img.Height; y++)
            {
                List<Color> row = new List<Color>();
                for (int x = 0; x < img.Width; x++)
                {
                    row.Add(img.GetPixel(x, y));
                }
                pixelMap.Add(row);
            }
            for (int y = 0; y < newImage.Height; y++)
            {
                for (int x = 0; x < newImage.Width; x++)
                {
                    newImage.SetPixel(x, y, img.GetPixel(x * offSet, y * offSet));
                }
            }
            return newImage;
        }
    }
}
