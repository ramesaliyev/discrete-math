using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private Graphics canvas;
        private Panel panel;
        private int vertexSize;

        public void draw(Panel currentPanel, Graphics currentCanvas, ScheduleCalculator scheduleCalculator)
        {
            canvas = currentCanvas;
            panel = currentPanel;

            canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            vertexSize = 40;

            int centerY = panel.Top + (panel.Height / 2); 
            int centerX = panel.Left + (panel.Width / 2);

            int radius = (Math.Min(panel.Width, panel.Height) / 2) - vertexSize;
            int unitAngle = 360 / scheduleCalculator.lectures.Length;

            canvas.FillEllipse(Brushes.SeaShell, centerX - radius, centerY - radius, radius * 2, radius * 2);

            for (int i = 0; i < scheduleCalculator.lectures.Length; i++)
            {
                double angle = DegreesToRadians(i * unitAngle);
                int x = Convert.ToInt32(Math.Cos(angle) * radius);
                int y = Convert.ToInt32(Math.Sin(angle) * radius);

                DrawVertex((i + 1).ToString(), PickBrush(), centerX + x, centerY - y, vertexSize);
            }
        }

        private void DrawVertex(string name, Brush brush, int x, int y, int size)
        {
            Pen pen = new Pen(Color.Black, 2);
            int radius = size / 2;

            canvas.FillEllipse(brush, x - radius, y - radius, size, size);
            canvas.DrawEllipse(pen, x - radius, y - radius, size, size);
        }

        private void DrawEdge()
        {

        }

        private void DrawText()
        {

        }

        private Dictionary<int, Brush> generateBrushes()
        {
            var brushes = new Dictionary<int, Brush>();
            var pickedBrushes = new List<Brush>();


            return brushes;
        }

        private Brush PickBrush()
        {
            PropertyInfo[] properties = typeof(Brushes).GetProperties();
            int random = new Random().Next(properties.Length);
            return (Brush)properties[random].GetValue(null, null);
        }

        double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
