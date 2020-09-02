using System.Collections.Generic;
using System.Diagnostics;

namespace HW_04_Project_Graph_Coloring_GUI
{
    class DebugPrint
    {
        public static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                string row = "";
                for (int j = 0; j < m; j++)
                {
                    row += matrix[i, j] + " ";
                }
                Debug.WriteLine(row);
            }
        }

        public static void PrintDictStringToStringList(Dictionary<string, List<string>> list)
        {
            foreach (var key in list.Keys)
            {
                Debug.WriteLine("{0} -> [{1}]", key, string.Join(", ", list[key]));
            }
        }

        public static void PrintColorsByIndexOfLectures(List<string> lectureNames, int[] colors)
        {
            for (int i = 0; i < lectureNames.Count; i++)
            {
                Debug.WriteLine("{0} -> [{1}]", lectureNames[i], colors[i]);
            }
        }
    }
}
