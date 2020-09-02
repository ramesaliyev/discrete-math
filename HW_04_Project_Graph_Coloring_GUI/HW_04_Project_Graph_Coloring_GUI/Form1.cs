using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace HW_04_Project_Graph_Coloring_GUI
{
    public partial class MainForm : Form
    {
        private ScheduleCalculator scheduleCalculator;
        private GraphDrawer graphDrawer;
        private bool readyToPaint = false;

        public MainForm()
        {
            InitializeComponent();
            scheduleCalculator = new ScheduleCalculator();
            graphDrawer = new GraphDrawer();
        }

        private void buttonReloadAndCalculate_Click(object sender, EventArgs e)
        {
            scheduleCalculator.Calculate(textBoxDataPath.Text, textBoxIndexFile.Text);
            readyToPaint = true;
            canvas.Refresh();
            PrintSummary();

            // Debug Prints
            Debug.WriteLine("");
            Debug.WriteLine("Students by Lecture:");
            DebugPrint.PrintDictStringToStringList(scheduleCalculator.studentsByLecture);
            Debug.WriteLine("");

            Console.WriteLine("Adjacency Matrix:");
            DebugPrint.PrintMatrix(scheduleCalculator.adjMatrix);
            Debug.WriteLine("");

            Debug.WriteLine(String.Format("Minimum number of colors needed to color the graph: {0}", scheduleCalculator.calculatedColorCount.ToString()));
            Debug.WriteLine("Colors by Index of Lectures:");
            DebugPrint.PrintColorsByIndexOfLectures(scheduleCalculator.studentsByLecture.Keys.ToList(), scheduleCalculator.calculatedLectureColors);
            Debug.WriteLine("");
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (!readyToPaint) return;

            graphDrawer.draw(canvas, e.Graphics, scheduleCalculator);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Redrawing...");
            canvas.Refresh();
        }

        private void PrintSummary()
        {
            var lectures = scheduleCalculator.lectures;
            var colorCount = scheduleCalculator.calculatedColorCount;
            var lectureColors = scheduleCalculator.calculatedLectureColors;
            var lectureStudents = scheduleCalculator.studentsByLecture;
            var adjMatrix = scheduleCalculator.adjMatrix;

            string text = "";

            text += "Calculations result is summarized below. Scroll down to see.";
            text += "\n\n";

            text += String.Format("Minimum number of colors needed to color the graph:\n");
            text += String.Format("{0}", colorCount.ToString());
            text += "\n\n";

            text += String.Format("Lecture names by corresponding vertex numbers:\n");
            for (int i = 0; i < lectures.Length; i++)
            {
                text += String.Format("{0} -> {1}", i + 1, lectures[i]);
                text += "\n";
            }
            text += "\n";

            text += String.Format("Colors numbers of lectures:\n");
            for (int i = 0; i < lectures.Length; i++)
            {
                text += String.Format("{0}, {1} -> {2}", i + 1, lectures[i], lectureColors[i] + 1);
                text += "\n";
            }
            text += "\n";

            text += String.Format("Students by Lecture:\n");
            for (int i = 0; i < lectures.Length; i++)
            {
                text += String.Format("{0}, {1} -> {2}", i + 1, lectures[i], string.Join(", ", lectureStudents[lectures[i]]));
                text += "\n";
            }
            text += "\n";

            text += String.Format("Adjacency Matrix:\n");
            int n = lectures.Length;
            text += String.Format("X {0}\n", string.Join(" ", Enumerable.Range(1, n)));
            for (int i = 0; i < n; i++)
            {
                text += (i + 1) + " ";

                for (int j = 0; j < n; j++)
                {
                    text += adjMatrix[i, j] + " ";
                }
                text += "\n";
            }
            text += "\n";

            summary.Text = text;
        }
    }
}
