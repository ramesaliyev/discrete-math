using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_04_Project_Graph_Coloring_GUI
{
    public partial class MainForm : Form
    {
        private ScheduleCalculator scheduleCalculator;

        public MainForm()
        {
            InitializeComponent();
            scheduleCalculator = new ScheduleCalculator();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonReloadAndCalculate_Click(object sender, EventArgs e)
        {
            scheduleCalculator.Calculate(textBoxDataPath.Text, textBoxIndexFile.Text);

            // Debug Prints
            Debug.WriteLine("Students by Lecture:");
            DebugPrint.PrintDictStringToStringList(scheduleCalculator.studentsByLecture);
            Debug.WriteLine("");

            Console.WriteLine("Adjacency Matrix:");
            DebugPrint.PrintMatrix(scheduleCalculator.adjMatrix);
            Debug.WriteLine("");

            Debug.WriteLine(String.Format("Minimum number of colors needed to color the graph: {0}", scheduleCalculator.calculatedColorCount.ToString()));
            Debug.WriteLine("Colors by Index of Lectures:");
            DebugPrint.PrintColorsByIndexOfLectures(scheduleCalculator.studentsByLecture.Keys.ToList(), scheduleCalculator.calculatedLectureColors);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
