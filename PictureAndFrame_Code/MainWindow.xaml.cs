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
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PictureAndFrame_Code
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
             // JPEG image
                BitmapImage bmi = new BitmapImage (new Uri (@"C:\Users\Randy\Documents\FromWork\MoreToHome\squimMove14 068.jpg"));

                ImageDrawing imageDrawing = new ImageDrawing ();
                imageDrawing.ImageSource = bmi;                
                imageDrawing.Rect = new Rect (new Point (0, 0), new Point (bmi.PixelWidth, bmi.PixelHeight));
                
                
             // rectangle to draw on top of image
                RectangleGeometry rectGeometry = new RectangleGeometry (new Rect (50, 100, 1200, 1440));

             // add drawing parameters to rectangle geometry
                GeometryDrawing geomDrawing = new GeometryDrawing ();
                geomDrawing.Brush = null;
                geomDrawing.Pen = new Pen (Brushes.Red, 5);
                geomDrawing.Geometry = rectGeometry;
                
             // drawing group
                DrawingGroup drawingGroup = new DrawingGroup ();
                drawingGroup.Children.Add (imageDrawing);
                drawingGroup.Children.Add (geomDrawing);

          //    drawingGroup.Opacity = 0.5;
                
             // drawing image
                DrawingImage drawingImage = new DrawingImage (drawingGroup);

             // image defined in XAML
                image.Source = drawingImage;
            }

            catch (Exception ex)
            {
                MessageBox.Show (string.Format ("Exception: {0}", ex.Message));
            }
        }
    }
}
