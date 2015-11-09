using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ImageEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            int mode;
            while (true)
            {
                Console.WriteLine("Would you like to 1)encode or 2)decode an image?");
                try
                {
                    mode = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch
                {

                }
            }
            Console.WriteLine("Enter relative image path from the desktop");
            string path = Console.ReadLine();
            Bitmap img = (Bitmap)Bitmap.FromFile(path);
            Console.WriteLine("The loaded image is {0} x {1}", img.Width, img.Height);
            Console.WriteLine("The first pixel is {0}", img.GetPixel(0, 0));
            if(mode == 1)
            {
                int offSet;
                Console.WriteLine("The image will now be encoded with a random pixel between every pixel");
                while (true)
                {
                    Console.WriteLine("What offset would you like to use?");
                    try
                    {
                        offSet = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {

                    }
                }
                
                saveImage(encryption.encode(encryption.encode(img, offSet), offSet));
            }
            else
            {
                int offSet;
                Console.WriteLine("The image will now be decoded, back in to the original form");
                while (true)
                {
                    Console.WriteLine("What offset was used?");
                    try
                    {
                        offSet = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {

                    }
                }
                
                saveImage(encryption.decode(encryption.decode(img, offSet), offSet));
            }

        }
        static bool saveImage(Bitmap image)
        {
            Console.WriteLine("Where would you like to save the new image?");
            string path = Console.ReadLine();
            while (path == "" || path == null)
            {
                path = Console.ReadLine();
            }
            image.Save(path);
            return true;
        }
    }
}
