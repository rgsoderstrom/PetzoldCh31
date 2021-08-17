using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CreateIndexedBitmap
{
    static class Colormap
    {
        static public byte [,] colors = new byte [256, 3];

        static Colormap ()
        {
            StreamReader file = new StreamReader (@"..\..\Colormap.txt");
            string raw;
            int row = 0;

            while ((raw = file.ReadLine ()) != null)
            {
                if (raw.Length > 0)
                {
                    string [] tokens = raw.Split (new char[] {' '});
                    byte r = byte.Parse (tokens [0]);
                    byte g = byte.Parse (tokens [1]);
                    byte b = byte.Parse (tokens [2]);
                    colors [row, 0] = r;
                    colors [row, 1] = g;
                    colors [row, 2] = b;
                    row++;
                }
            }

            file.Close ();
        }
    }
}