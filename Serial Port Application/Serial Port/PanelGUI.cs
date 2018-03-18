using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Serial_Port
{
    public class PanelGUI
    {
        public static GroupBox Panel { get; set; }
        public static Size CellSize { get; } = new Size(54, 54);
        public static Size WebSize { get; private set; }
        public static Rectangle WebBoundary { get; private set; }
        public static ArrayList Elements { get; set; }

        public Point Location { get; set; }
        public char Element { get; set; }

        public PanelGUI()
        {
            Elements.Add(this);
        }

        public static Point GetCell(Point cursor)
        {
            if (cursor.X < WebBoundary.X || cursor.Y < WebBoundary.Y) return new Point(0, 0);
            if (cursor.X > WebBoundary.X + WebBoundary.Width || cursor.Y > WebBoundary.Y + WebBoundary.Height) return new Point(WebSize.Width - 1, WebSize.Height - 1);
            return new Point((cursor.X - WebBoundary.X) / CellSize.Width, (cursor.Y - WebBoundary.Y) / CellSize.Height);
        }

        public static void Update()
        {
            WebSize = new Size(Panel.Width / CellSize.Width, (Panel.Height - 16) / CellSize.Height);
            Point boundary = new Point(Panel.Width - WebSize.Width * CellSize.Width, Panel.Height - WebSize.Height * CellSize.Height);
            WebBoundary = new Rectangle(boundary.X / 2, boundary.Y / 2 + 8, WebSize.Width * CellSize.Width, WebSize.Height * CellSize.Height);
            Elements.Sort(new LocationComparer());
            Point drawingPoint = new Point(0, 0);
            foreach (PanelGUI eGUI in Elements) eGUI.Paint(ref drawingPoint);
        }
        public virtual void Paint(ref Point drawingPoint) {}
        public class LocationComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Point a = ((PanelGUI)(x)).Location;
                Point b = ((PanelGUI)(y)).Location;
                if ((a.X == b.X) && (a.Y == b.Y)) a.X++;
                if ((a.Y < b.Y) || ((a.Y == b.Y) && (a.X < b.X))) return -1;
                else return 1;
            }
        }
    }
}
