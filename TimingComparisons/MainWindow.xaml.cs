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

using System.Diagnostics; // StopWatch

namespace TimingComparisons
{
    public partial class MainWindow : Window
    {
        const double NumberCircles = 30;
        const double AngularRate = 3; // degrees per step
        const double RadialRate = 0.05; // WPF units per step. Positive means in toward center

        PolyLineSegment polyLine = null;

      //******************************************************

        public MainWindow ()
        {
            InitializeComponent ();

            polyLine = new PolyLineSegment ();

            double angularRateRadians = AngularRate * Math.PI / 180;
            double radial = 500;

            for (double theta = 0; theta < NumberCircles * 2 * Math.PI; theta += angularRateRadians, radial -= RadialRate)
            {
                Point pt = new Point (500 + radial * Math.Cos (theta), 550 + radial * Math.Sin (theta));
                polyLine.Points.Add (pt);
            }


            
        }

      //******************************************************

        void DrawWithDC (PolyLineSegment pls)
        {
        }

      //******************************************************

        void DrawWithPathGeometry (PolyLineSegment pls)
        {
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = pls.Points [0];
            pathFigure.Segments = new PathSegmentCollection();
            pathFigure.Segments.Add (pls);

            PathGeometry pathGeometry = new PathGeometry ();
            pathGeometry.Figures.Add(pathFigure);
            pathGeometry.Freeze ();         

            Path path = new System.Windows.Shapes.Path ();
            path.Stroke = Brushes.Green;
            path.StrokeThickness = 3;
            path.Data = pathGeometry;

       //     path.MouseDown += new MouseButtonEventHandler (path_MouseDown);
                  
            canvas.Children.Add (path);
        }

      //******************************************************

        void DrawWithStreamGeometry (PolyLineSegment pls)
        {
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = pls.Points [0];
            pathFigure.Segments = new PathSegmentCollection();
            pathFigure.Segments.Add (pls);

            StreamGeometry streamGeometry = new StreamGeometry ();
            StreamGeometryContext ctx = streamGeometry.Open();
            ctx.BeginFigure (pls.Points [0], false, false);
            ctx.PolyLineTo (pls.Points, true, true);
            ctx.Close ();
            streamGeometry.Freeze();

            Path path = new System.Windows.Shapes.Path ();
            path.Stroke = Brushes.Green;
            path.StrokeThickness = 3;
            path.Data = streamGeometry;
                  
     //       path.MouseDown += new MouseButtonEventHandler (path_MouseDown);
                  
            canvas.Children.Add (path);
        }

      //******************************************************

        void path_MouseDown (object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine ("Click");
        }

        private void canvas_SizeChanged (object sender, SizeChangedEventArgs e)
        {
            canvas.Children.Clear ();

            Stopwatch stopwatch = new Stopwatch();
        	stopwatch.Start();

            DrawWithPathGeometry (polyLine);
       //     DrawWithStreamGeometry (polyLine);
       //     DrawWithDC (polyLine);

            stopwatch.Stop ();

            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

        }
    }
}
