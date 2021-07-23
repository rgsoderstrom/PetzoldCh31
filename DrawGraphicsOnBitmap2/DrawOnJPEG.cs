using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DrawGraphicsOnBitmap2
{
    class DrawOnJPEG : Window
    {
        [STAThread]
        public static void Main ()
        {
            Application app = new Application ();
            app.Run (new DrawOnJPEG ());
        }

        DrawOnJPEG ()
        {
            Title = "Draw on a JPEG";

            Background = Brushes.Khaki;
        
            try
            {
                Grid grid = new Grid ();

             // load image
                BitmapImage bmi = new BitmapImage (new Uri (@"D:\FromWork\MoreToHome\squimMove14 068.jpg"));

                double aa = bmi.DpiX;
                double bb = bmi.DpiY;
                double cc = bmi.PixelWidth;
                double dd = bmi.PixelHeight;

             // make a bitmap we can draw on
                RenderTargetBitmap rtbm = new RenderTargetBitmap (bmi.PixelWidth, bmi.PixelHeight, bmi.DpiX, bmi.DpiY, PixelFormats.Default);

                // DrawingVisual
                DrawingVisual vis = new DrawingVisual ();
                DrawingContext dc = vis.RenderOpen ();
                dc.DrawRoundedRectangle (null, new Pen (Brushes.Red, 7), new Rect (150, 300, 145, 150), 5, 5);
                dc.Close ();

             // render
                rtbm.Render (vis);


                Image image1 = new Image ();
                image1.Source = bmi;

                Image image2 = new Image ();
                image2.Source = rtbm;

                grid.Children.Add (image1); // same grid cell
                grid.Children.Add (image2);

                Content = grid;
            }

            catch (Exception ex)
            {
                Console.WriteLine ("Exception: {0}", ex.Message);
            }
        }

    }
}
