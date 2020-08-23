using System;
using System.Collections.Generic;

namespace HW_01_Set_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            int[] A = Program.BuildSet("A");
            Console.WriteLine();

            int[] B = Program.BuildSet("B");
            Console.WriteLine();

            Console.WriteLine("Set A:");
            Program.PrintArray(A);
            Console.WriteLine();

            Console.WriteLine("Set B:");
            Program.PrintArray(B);
            Console.WriteLine();

            Console.WriteLine("UNION: AuB");
            Program.PrintArray(Program.Union(A, B));
            Console.WriteLine();

            Console.WriteLine("INTERSECTION: AnB");
            Program.PrintArray(Program.Intersection(A, B));
            Console.WriteLine();

            Console.WriteLine("DIFF: A-B");
            Program.PrintArray(Program.Diff(A, B));
            Console.WriteLine();

            Console.WriteLine("DIFF: B-A");
            Program.PrintArray(Program.Diff(B, A));
            Console.WriteLine();

            Console.WriteLine("CARTESIAN: AxB");
            Program.PrintArray(Program.Cartesian(A, B));
            Console.WriteLine();
        }

        static int[] BuildSet(string setName)
        {
            Console.WriteLine("Enter members of set {0} as comma separated integers, press ENTER to submit.", setName);

            List<int> set = new List<int>();

            string input = Console.ReadLine();

            foreach (var str in input.Split(','))
            {
                int value;
                if (int.TryParse(str, out value))
                {
                    if (!set.Contains(value))
                    {
                        set.Add(value);
                    }
                }
            }


            int[] result = set.ToArray();
            Array.Sort(result);

            return result;
        }

        static int[] Union(int[] A, int[] B)
        {
            List<int> union = new List<int>(A);

            Array.ForEach(B, b => {
                if (!union.Contains(b))
                {
                    union.Add(b);
                }
            });

            int[] result = union.ToArray();
            Array.Sort(result);

            return result;
        }

        static int[] Intersection(int[] A, int[] B)
        {
            List<int> intersection = new List<int>();

            Array.ForEach(A, a => {
                if (Array.IndexOf(B, a) > -1)
                {
                    intersection.Add(a);
                }
            });

            int[] result = intersection.ToArray();
            Array.Sort(result);

            return result;
        }

        static int[] Diff(int[] A, int[] B)
        {
            List<int> diff = new List<int>(A);

            Array.ForEach(B, b => {
                if (diff.Contains(b))
                {
                    diff.Remove(b);
                }
            });

            int[] result = diff.ToArray();
            Array.Sort(result);

            return result;
        }

        static (int, int)[] Cartesian(int[] A, int[] B)
        {
            List<(int, int)> cartesian = new List<(int, int)>();

            Array.ForEach(A, a => {
                Array.ForEach(B, b => {
                    cartesian.Add((a, b));
                });
            });

            return cartesian.ToArray();
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        static void PrintArray((int, int)[] array)
        {
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }
    }
}
