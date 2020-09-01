using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW_04_Project_Graph_Coloring_GUI
{
    class GraphDrawer
    {
        public void draw (Graphics canvas, ScheduleCalculator scheduleCalculator)
        {
            canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Brush brush = PickBrush();
            Pen pen = new Pen(Color.Black, 2);

            canvas.FillEllipse(brush, 220, 220, 100, 100);
            canvas.DrawEllipse(pen, 220, 220, 100, 100);
        }

        private void DrawVertex()
        {

        }

        private void DrawEdge()
        {

        }

        private Brush PickBrush()
        {
            PropertyInfo[] properties = typeof(Brushes).GetProperties();
            int random = new Random().Next(properties.Length);
            return (Brush)properties[random].GetValue(null, null);
        }
    }
}
