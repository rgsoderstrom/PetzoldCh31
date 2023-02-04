using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

//using System.Drawing;  // must add reference
//using System.Drawing.Imaging;

using Color = System.Windows.Media.Color;

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
                Title = "A Bitmap";



                Rect rect = new Rect (new Point (100, 100), new Point (400, 300));
                RectangleGeometry rg = new RectangleGeometry (rect);

                System.Windows.Shapes.Path path = new System.Windows.Shapes.Path ();
                path.Data = rg;

                path.Fill = null; // see below
                path.Stroke = Brushes.Black;
                path.StrokeThickness = 1;

               
                Content = path;







                BitmapPalette palette = new BitmapPalette (Colormap.colors);

                // bitmap bits
                byte[] array = new byte[256 * 256];

                double maxR = Math.Sqrt (2 * 256 * 256);

                for (int x=0; x<256; x++)
                {
                    for (int y=0; y<256; y++)
                    {
                        double R = Math.Sqrt ((double) x * x + y * y);
                        int r = (int) (255 * R / maxR);
                        array [256 * y + x] = (byte) (r);
                    }
                }

                array [256 * 10 + 10] = 255;
                array [256 * 10 + 11] = 255;
                array [256 * 11 + 10] = 255;
                array [256 * 11 + 11] = 255;

                BitmapSource bitmap = BitmapSource.Create (256, 256, 96, 96, PixelFormats.Indexed8, palette, array, 256);
              //BitmapSource bitmap = BitmapSource.Create (256, 256, 96, 96, PixelFormats.Gray8, palette, array, 256);

               
                // Image
                Image img = new Image ();
                img.Source = bitmap;
                //img.Stretch = Stretch.Fill;
                img.Stretch = Stretch.None;

                ImageBrush ib = new ImageBrush (img.Source);
                path.Fill = ib;

                // Window
                //Content = img;
            }

            catch (Exception ex)
            {
                Console.WriteLine ("Exception: {0}", ex.Message);
            }
        }
    }
}
