using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW_03_Project_Graph_Coloring
{
    // Type Definitions
    using StudentsByLecture = Dictionary<string, List<string>>; // {lectureName:studentList}
    using ColoredGraphDetails = Tuple<int, int[]>; // (colorCount, {vertexIndex: color})

    class Program
    {
        public static readonly string DATA_PATH = "/Users/ramesaliyev/Projects/Personal/hw-discrete-math/HW_03_Project_Graph_Coloring/HW_03_Project_Graph_Coloring/data/set3";

        static void Main(string[] args)
        {
            var studentsByLecture = GetStudents();
            Console.WriteLine("Students by Lecture:");
            PrintDictStringToStringList(studentsByLecture);

            Console.WriteLine();

            var adjMatrix = GenerateAdjMatrix(studentsByLecture);
            Console.WriteLine("Adjacency Matrix:");
            PrintMatrix(adjMatrix);

            Console.WriteLine();
            (var colorCount, var lectureColors) = ColorGraph(adjMatrix);
            Console.WriteLine("Minimum number of colors needed to color the graph: {0}", colorCount);
            Console.WriteLine("Colors by Index of Lectures:");
            PrintColorsByIndexOfLectures(studentsByLecture.Keys.ToList(), lectureColors);
        }

        static ColoredGraphDetails ColorGraph(int[,] adjMatrix)
        {
            var n = adjMatrix.GetLength(0);
            int[] colors = Enumerable.Repeat(1, n).ToArray();

            for (int i = 0; i < n; i++) {
                int color = colors[i];

                for (int j = 0; j < n; j++)
                {
                    if (i != j && adjMatrix[i, j] == 1 && colors[j] == color)
                    {
                        Console.WriteLine("{0}:{1}, {2}", i, j, color + 1);
                        colors[j] = color + 1;
                    }
                }
            }

            return (colors.Distinct().Count(), colors).ToTuple();
        }

        static int[,] GenerateAdjMatrix(StudentsByLecture studentsByLecture)
        {
            int n = studentsByLecture.Keys.Count;
            int[,] matrix = new int[n, n];

            var lectures = studentsByLecture.Keys.ToList();

            for (int i = 0; i < lectures.Count - 1; i++)
            {
                var lectureAName = lectures[i];
                var lectureAStudents = studentsByLecture[lectureAName];

                for (int j = i + 1; j < lectures.Count; j++)
                {
                    var lectureBName = lectures[j];
                    var lectureBStudents = studentsByLecture[lectureBName];

                    if (Program.HasCommonMember(lectureAStudents, lectureBStudents))
                    {
                        matrix[i, j] = 1;
                        matrix[j, i] = 1;
                    }
                }

            }

            return matrix;

        }

        static bool HasCommonMember(List<string> A, List<string> B)
        {
            foreach (string a in A) {
                if (B.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }

        static StudentsByLecture GetStudents()
        {
            var lectures = Program.ReadFile("Lectures");
            var studentsByLecture = new StudentsByLecture();

            foreach (var lecture in lectures)
            {
                studentsByLecture[lecture] = Program.ReadFile(lecture);
            }

            return studentsByLecture;
        }

        static List<string> ReadFile(string fileName)
        {
            var lines = File.ReadAllLines(Path.Combine(DATA_PATH, fileName + ".txt"));
            return new List<string>(lines);
        }

        static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void PrintDictStringToStringList(Dictionary<string, List<string>> list)
        {
            foreach (var key in list.Keys)
            {
                Console.WriteLine("{0} -> [{1}]", key, string.Join(", ", list[key]));
            }
        }

        static void PrintColorsByIndexOfLectures(List<string> lectureNames, int[] colors)
        {
            for (int i = 0; i < lectureNames.Count; i++)
            {
                Console.WriteLine("{0} -> [{1}]", lectureNames[i], colors[i]);
            }
        }
    }
}
