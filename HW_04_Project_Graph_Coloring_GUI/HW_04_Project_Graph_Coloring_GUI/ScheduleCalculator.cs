using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_04_Project_Graph_Coloring_GUI
{
    // Type Definitions
    using StudentsByLecture = Dictionary<string, List<string>>; // {lectureName:studentList}
    using ColoredGraphDetails = Tuple<int, int[]>; // (colorCount, {vertexIndex: color})

    class ScheduleCalculator
    {
        public string DATA_PATH = "";
        public string INDEX_FILE = "";

        public int[,] adjMatrix;
        public string[] lectures;
        public StudentsByLecture studentsByLecture;

        public int calculatedColorCount;
        public int[] calculatedLectureColors;

        public void Calculate(string dataPath, string indexFile)
        {
            DATA_PATH = dataPath;
            INDEX_FILE = indexFile;

            studentsByLecture = GetStudents();
            adjMatrix = GenerateAdjMatrix(studentsByLecture);
            
            (var colorCount, var lectureColors) = ColorGraph(adjMatrix);
            calculatedColorCount = colorCount;
            calculatedLectureColors = lectureColors;
        }

        ColoredGraphDetails ColorGraph(int[,] adjMatrix)
        {
            var n = adjMatrix.GetLength(0);
            int[] colors = Enumerable.Repeat(1, n).ToArray();

            for (int i = 0; i < n; i++)
            {
                int color = colors[i];

                for (int j = 0; j < n; j++)
                {
                    if (i != j && adjMatrix[i, j] == 1 && colors[j] == color)
                    {
                        colors[j] = color + 1;
                    }
                }
            }

            return (colors.Distinct().Count(), colors).ToTuple();
        }

        int[,] GenerateAdjMatrix(StudentsByLecture studentsByLecture)
        {
            int n = studentsByLecture.Keys.Count;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < lectures.Length - 1; i++)
            {
                var lectureAName = lectures[i];
                var lectureAStudents = studentsByLecture[lectureAName];

                for (int j = i + 1; j < lectures.Length; j++)
                {
                    var lectureBName = lectures[j];
                    var lectureBStudents = studentsByLecture[lectureBName];

                    if (HasCommonMember(lectureAStudents, lectureBStudents))
                    {
                        matrix[i, j] = 1;
                        matrix[j, i] = 1;
                    }
                }

            }

            return matrix;

        }

        bool HasCommonMember(List<string> A, List<string> B)
        {
            foreach (string a in A)
            {
                if (B.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }

        StudentsByLecture GetStudents()
        {
            lectures = ReadFile(INDEX_FILE).ToArray();
            var studentsByLecture = new StudentsByLecture();

            foreach (var lecture in lectures)
            {
                studentsByLecture[lecture] = ReadFile(lecture);
            }

            return studentsByLecture;
        }

        List<string> ReadFile(string fileName)
        {
            var lines = File.ReadAllLines(Path.Combine(DATA_PATH, fileName + ".txt"));
            return new List<string>(lines);
        }
    }
}
