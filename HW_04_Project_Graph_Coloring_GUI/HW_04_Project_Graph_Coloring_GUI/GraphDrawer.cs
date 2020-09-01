using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_04_Project_Graph_Coloring_GUI
{
    class GraphDrawer
    {
        private static Random random = new Random();

        private Graphics canvas;
        private Panel panel;
        private int vertexSize;

        public void draw(Panel currentPanel, Graphics currentCanvas, ScheduleCalculator scheduleCalculator)
        {
            canvas = currentCanvas;
            panel = currentPanel;

            canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            vertexSize = panel.Width / (scheduleCalculator.lectures.Length + 1);

            int centerY = panel.Top + (panel.Height / 2);
            int centerX = panel.Left + (panel.Width / 2);

            int radius = (Math.Min(panel.Width, panel.Height) / 2) - vertexSize;
            int unitAngle = 360 / scheduleCalculator.lectures.Length;

            Debug.WriteLine("Choosen colors");
            var brushOfColor = generateBrushes(scheduleCalculator.calculatedColorCount);
            var positionOfLectures = new Dictionary<int, Point>();

            canvas.FillEllipse(Brushes.LightGray, centerX - radius, centerY - radius, radius * 2, radius * 2);

            for (int i = 0; i < scheduleCalculator.lectures.Length; i++)
            {
                double angle = DegreesToRadians(i * unitAngle);
                int x = centerX + Convert.ToInt32(Math.Cos(angle) * radius);
                int y = centerY + Convert.ToInt32(Math.Sin(angle) * radius);

                positionOfLectures.Add(i, new Point(x, y));
            }

            var adjMatrix = scheduleCalculator.adjMatrix;
            var n = scheduleCalculator.adjMatrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (i != j && adjMatrix[i, j] == 1)
                    {
                        DrawEdge(positionOfLectures[i], positionOfLectures[j]);
                    }
                }
            }

            for (int i = 0; i < scheduleCalculator.lectures.Length; i++)
            {
                var color = scheduleCalculator.calculatedLectureColors[i];
                DrawVertex((i + 1).ToString(), brushOfColor[color], positionOfLectures[i], vertexSize);
            }
        }

        private void DrawVertex(string name, Brush brush, Point position, int size)
        {
            Pen pen = new Pen(Color.Black, 3);
            int x = position.X;
            int y = position.Y;
            int radius = size / 2;

            canvas.FillEllipse(brush, x - radius, y - radius, size, size);
            canvas.DrawEllipse(pen, x - radius, y - radius, size, size);

            DrawText(name, x, y);
        }

        private void DrawEdge(Point from, Point to)
        {
            Pen pen = new Pen(Color.Black, 3);
            canvas.DrawLine(pen, from.X, from.Y, to.X, to.Y);
        }

        private void DrawText(string text, int x, int y)
        {
            var fontFamily = new FontFamily("Arial");
            var font = new Font(fontFamily, 24, FontStyle.Regular, GraphicsUnit.Pixel);
            var solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
            var format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            canvas.TextRenderingHint = TextRenderingHint.AntiAlias;
            canvas.DrawString(text, font, solidBrush, new PointF(x, y), format);
        }

        private Dictionary<int, Brush> generateBrushes(int n)
        {
            var brushes = new Dictionary<int, Brush>();

            int i = 0;
            while (i < n)
            {
                var brush = PickBrush();

                if (!brushes.Values.Contains(brush))
                {
                    brushes.Add(i + 1, brush);
                    i++;
                }
            }

            return brushes;
        }

        private Brush PickBrush()
        {
            Brush[] brushes = new Brush[]{
                Brushes.AliceBlue,
                Brushes.AntiqueWhite,
                Brushes.Aqua,
                Brushes.Aquamarine,
                Brushes.Azure,
                Brushes.Bisque,
                Brushes.BlanchedAlmond,
                Brushes.BlueViolet,
                Brushes.Brown,
                Brushes.BurlyWood,
                Brushes.CadetBlue,
                Brushes.Chartreuse,
                Brushes.Chocolate,
                Brushes.Coral,
                Brushes.CornflowerBlue,
                Brushes.Crimson,
                Brushes.Cyan,
                Brushes.DeepPink,
                Brushes.DeepSkyBlue,
                Brushes.DimGray,
                Brushes.DodgerBlue,
                Brushes.Firebrick,
                Brushes.ForestGreen,
                Brushes.Fuchsia,
                Brushes.Gainsboro,
                Brushes.Gold,
                Brushes.Goldenrod,
                Brushes.Gray,
                Brushes.Green,
                Brushes.GreenYellow,
                Brushes.HotPink,
                Brushes.IndianRed,
                Brushes.Khaki,
                Brushes.Lavender,
                Brushes.LavenderBlush,
                Brushes.LawnGreen,
                Brushes.LemonChiffon,
                Brushes.LightBlue,
                Brushes.LightCoral,
                Brushes.LightCyan,
                Brushes.LightGoldenrodYellow,
                Brushes.LightGreen,
                Brushes.LightPink,
                Brushes.LightSalmon,
                Brushes.LightSeaGreen,
                Brushes.LightSkyBlue,
                Brushes.LightSlateGray,
                Brushes.LightSteelBlue,
                Brushes.Lime,
                Brushes.LimeGreen,
                Brushes.Magenta,
                Brushes.MintCream,
                Brushes.MistyRose,
                Brushes.Moccasin,
                Brushes.NavajoWhite,
                Brushes.Olive,
                Brushes.OliveDrab,
                Brushes.Orange,
                Brushes.OrangeRed,
                Brushes.Orchid,
                Brushes.PaleGoldenrod,
                Brushes.PaleGreen,
                Brushes.PaleTurquoise,
                Brushes.PaleVioletRed,
                Brushes.PeachPuff,
                Brushes.Peru,
                Brushes.Pink,
                Brushes.Plum,
                Brushes.PowderBlue,
                Brushes.Purple,
                Brushes.Red,
                Brushes.RosyBrown,
                Brushes.RoyalBlue,
                Brushes.Salmon,
                Brushes.SandyBrown,
                Brushes.SeaGreen,
                Brushes.Sienna,
                Brushes.Silver,
                Brushes.SkyBlue,
                Brushes.SlateBlue,
                Brushes.SlateGray,
                Brushes.SpringGreen,
                Brushes.SteelBlue,
                Brushes.Tan,
                Brushes.Thistle,
                Brushes.Tomato,
                Brushes.Turquoise,
                Brushes.Violet,
                Brushes.Wheat,
                Brushes.Yellow,
                Brushes.YellowGreen,
            };

            var randomIndex = (int)Math.Floor((double)GraphDrawer.random.Next(brushes.Length));
            Debug.WriteLine("color randomIndex=" + randomIndex);
            return brushes[randomIndex];
        }

        double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
