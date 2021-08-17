using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace CreateIndexedBitmap
{
    static class Colormap
    {
        static public List<Color> colors = new List<Color> ();

        static Colormap ()
        {
            StreamReader file = new StreamReader (@"..\..\Colormap.txt");
            string raw;

            while ((raw = file.ReadLine ()) != null)
            {
                if (raw.Length > 0)
                {
                    string [] tokens = raw.Split (new char[] {' '});

                    if (raw [0] == '%') // comment
                        continue;

                    if (tokens.Length == 3)
                    {
                        byte r = byte.Parse (tokens [0]);
                        byte g = byte.Parse (tokens [1]);
                        byte b = byte.Parse (tokens [2]);

                        colors.Add (Color.FromRgb (r, g, b));
                    }
                }
            }

            file.Close ();
            colors.Reverse ();
        }
    }
}