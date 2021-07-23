using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DrawGraphcsOnBitmap
{
    public class DrawOnBitmap : Window
    {
        [STAThread]
        public static void Main ()
        {
            Application app = new Application ();
            app.Run (new DrawOnBitmap ());
        }

        DrawOnBitmap ()
        {
            Title = "Draw on bitmap";

            Background = Brushes.Khaki;

            // bitmap object
   //         double dpi = 96; // dots per inch
     //       double sizeInches = 2;
       //     int dots = (int) (sizeInches * dpi);

  //        RenderTargetBitmap renderBitmap = new RenderTargetBitmap (100, 100, 96, 96, PixelFormats.Default);
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap (300, 300, 2*96, 2*96, PixelFormats.Default);

            // DrawingVisual
            DrawingVisual vis = new DrawingVisual ();
            DrawingContext dc = vis.RenderOpen ();
   //       dc.DrawRoundedRectangle (Brushes.LawnGreen, new Pen (Brushes.LightSlateGray, 10), new Rect (25, 25, 50, 50), 5, 5);
            dc.DrawRoundedRectangle (Brushes.LawnGreen, new Pen (Brushes.Black, 1), new Rect (1.5, 1.5, 145, 150), 5, 5);
            dc.Close ();

            // render
            renderBitmap.Render (vis);

            // Image
            Image img = new Image ();
            img.Source = renderBitmap;
            img.Stretch = Stretch.None;

            Content = img;
        }
    }
}
