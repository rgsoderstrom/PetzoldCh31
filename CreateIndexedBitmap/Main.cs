using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using System.Drawing;  // must add reference
using System.Drawing.Imaging;

namespace CreateIndexedBitmap
{
    public class MainClass : Window
    {
        [STAThread]
        static public void Main ()
        {
            Application app = new Application ();
            app.Run (new MainClass ());
        }

        MainClass ()
        {
            try
            {
                Title = "Bitmap";

                // palette
                List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color> ();
/**
                for (int i=0; i<256; i+=17)
                    for (int j=0; j<256; j+=17)
                        colors.Add (Color.FromRgb ((byte) i, 0, (byte) j));
**/

                for (int i=0; i<256; i++)
                    colors.Add (System.Windows.Media.Color.FromRgb ((byte) i, (byte) i, (byte) i));

                BitmapPalette palette = new BitmapPalette (colors);

                // bitmap bits
                byte[] array = new byte[256 * 256];
                    
                double maxR = Math.Sqrt (2 * 256 * 256);

                for (int x=0; x<256; x++)
                    for (int y=0; y<256; y++)
                    {
                        double R = Math.Sqrt ((double) x * x + y * y);
                        int r = (int) (255 * R / maxR);
                        array [256 * y + x] = (byte) (r);
                    }

                array [256 * 10 + 10] = 255;
                array [256 * 10 + 11] = 255;
                array [256 * 11 + 10] = 255;
                array [256 * 11 + 11] = 255;

  //            BitmapSource bitmap = BitmapSource.Create (256, 256, 96, 96, PixelFormats.Indexed8, palette, array, 256);
                BitmapSource bitmap = BitmapSource.Create (256, 256, 96, 96, PixelFormats.Gray8, null, array, 256);

               
                // Image
                System.Windows.Controls.Image img = new System.Windows.Controls.Image ();
                img.Source = bitmap;
                img.Stretch = Stretch.None;

                // Window
                Content = img;
            }

            catch (Exception ex)
            {
                Console.WriteLine ("Exception: {0}", ex.Message);
            }
        }
    }
}
