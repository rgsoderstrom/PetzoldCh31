using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PictureAndFrame2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent ();

            try
            {
             // load image
                BitmapImage bmi = new BitmapImage (new Uri (@"C:\Users\rgsod\source\repos\PetzoldCh31\20220603_093205.jpg"));

                double aa = bmi.DpiX;
                double bb = bmi.DpiY;
                double cc = bmi.PixelWidth;
                double dd = bmi.PixelHeight;

                PixelFormat pf = bmi.Format; // Bgr32
                int bpp = bmi.Format.BitsPerPixel;

    //            image.Source = bmi;


             // copy pixels from a small area
                Int32Rect sourceRect = new Int32Rect (100, 1400, 500, 500);
                UInt32[] pixels = new UInt32 [500 * 500];
                bmi.CopyPixels (sourceRect, pixels, 500 * sizeof (UInt32), 0);

        //        for (int i=0; i<pixels.Length; i++)
          //          pixels [i] |= 0xff000000;



                // http://www.i-programmer.info/programming/wpf-workings/527-writeablebitmap.html?start=1
                // for backbuffer manipulations

             // write them back onto a writeable copy of the original
                WriteableBitmap wbmp = new WriteableBitmap (bmi);
                double aaa = wbmp.DpiX;
                double bbb = wbmp.DpiY;
                double ccc = wbmp.PixelWidth;
                double ddd = wbmp.PixelHeight;

                Int32Rect destRect = new Int32Rect (1000, 100, 500, 500);
                wbmp.WritePixels (destRect, pixels, 500 * sizeof (UInt32), 0);

                image.Source = wbmp;

            }

            catch (Exception ex)
            {
                Console.WriteLine ("Exception: {0}", ex.Message);
            }
        }
    }
}
