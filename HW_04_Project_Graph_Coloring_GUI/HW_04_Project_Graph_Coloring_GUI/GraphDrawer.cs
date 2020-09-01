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
            vertexSize = Math.Max(40, Math.Min(vertexSize, 100));

            var center = new Point();
            center.Y = panel.Top + (panel.Height / 2);
            center.X = panel.Left + (panel.Width / 2);

            int radius = (Math.Min(panel.Width, panel.Height) / 2) - vertexSize;

            var positionOfLectures = calculatePositions(scheduleCalculator.lectures.Length, center, radius);

            canvas.FillEllipse(Brushes.LightGray, center.X - radius, center.Y - radius, radius * 2, radius * 2);

            DrawEdges(scheduleCalculator.adjMatrix, positionOfLectures);
            DrawVertices(scheduleCalculator.calculatedColorCount, scheduleCalculator.calculatedLectureColors, positionOfLectures);
        }

        private Dictionary<int, Point> calculatePositions(int n, Point center, int radius)
        {
            var positions = new Dictionary<int, Point>();
            int unitAngle = 360 / n;

            for (int i = 0; i < n; i++)
            {
                var point = new Point();
                double angle = (i * unitAngle) * Math.PI / 180.0;

                point.X = center.X + Convert.ToInt32(Math.Cos(angle) * radius);
                point.Y = center.Y + Convert.ToInt32(Math.Sin(angle) * radius);

                positions.Add(i, point);
            }

            return positions;
        }
        
        private void DrawVertices(int colorCount, int[] vertexColors, Dictionary<int, Point> vertexPositions)
        {
            var brushOfColor = generateBrushes(colorCount);

            for (int i = 0; i < vertexPositions.Keys.Count; i++)
            {
                var color = vertexColors[i];
                DrawVertex((i + 1).ToString(), brushOfColor[color], vertexPositions[i], vertexSize);
            }
        }

        private void DrawEdges(int[,] adjMatrix, Dictionary<int, Point> vertexPositions)
        {
            var n = adjMatrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (i != j && adjMatrix[i, j] == 1)
                    {
                        DrawEdge(vertexPositions[i], vertexPositions[j]);
                    }
                }
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
                Brushes.Aqua,
                Brushes.Aquamarine,
                Brushes.Bisque,
                Brushes.BlueViolet,
                Brushes.Brown,
                Brushes.CadetBlue,
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
                Brushes.Gold,
                Brushes.Goldenrod,
                Brushes.Gray,
                Brushes.Green,
                Brushes.IndianRed,
                Brushes.Lime,
                Brushes.LimeGreen,
                Brushes.Magenta,
                Brushes.Olive,
                Brushes.OliveDrab,
                Brushes.Orchid,
                Brushes.PaleGreen,
                Brushes.PaleTurquoise,
                Brushes.PaleVioletRed,
                Brushes.Peru,
                Brushes.Pink,
                Brushes.Purple,
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
                Brushes.SteelBlue,
                Brushes.Tan,
                Brushes.Thistle,
                Brushes.Tomato,
                Brushes.Turquoise,
                Brushes.Yellow,
                Brushes.YellowGreen,
            };

            var randomIndex = (int)Math.Floor((double)GraphDrawer.random.Next(brushes.Length));
            Debug.WriteLine("Color:" + randomIndex);
            return brushes[randomIndex];
        }
    }
}
