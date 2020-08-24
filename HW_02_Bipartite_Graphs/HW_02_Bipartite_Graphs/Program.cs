using System;
using System.Collections.Generic;

namespace HW_02_Bipartite_Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bipartite Graph Checker!");

            Graph graph = BuildGraph();

            Console.WriteLine();
            Console.WriteLine("Vertices: [{0}]", string.Join(", ", graph.vertices));
            Console.WriteLine("Edges: [{0}]", string.Join(", ", graph.edges));

            Console.WriteLine();
            Console.WriteLine("Generating Adjacency Matrix!");
            graph.generateAdjacencyMatrix();

            Console.WriteLine("Adjacency Matrix:");
            PrintMatrix(graph.adjMatrix);

            Console.WriteLine();
            Console.WriteLine("Generating Adjacency List!");
            graph.generateAdjacencyList();

            Console.WriteLine("Adjacency List:");
            PrintList(graph.adjList);

            Console.WriteLine();
            Console.WriteLine("Checking if graph is Bipartite by using adjacency matrix!");
            bool isGraphBipartiteByAdjMatrix = graph.checkIfGraphBipartiteUsingAdjMatrix();
            Console.WriteLine("Result is: {0}", isGraphBipartiteByAdjMatrix);

            Console.WriteLine();
            Console.WriteLine("Checking if graph is Bipartite by using adjacency list!");
            bool isGraphBipartiteByAdjList = graph.checkIfGraphBipartiteUsingAdjList();
            Console.WriteLine("Result is: {0}", isGraphBipartiteByAdjList);

            Console.WriteLine();
            Console.WriteLine("Done! Press enter to exit.");
            Console.ReadLine();
        }

        static Graph BuildGraph()
        {
            Graph graph = new Graph();
            string input;

            Console.WriteLine("Enter a vertex (node) name and press enter to submit. Enter 'ok' to complete.");

            input = Console.ReadLine().Trim();
            while (input != "ok")
            {
                if (graph.vertices.Contains(input))
                {
                    Console.WriteLine("Error: Vertex with name '{0}' already exist, ignoring input...", input);
                }
                else if (input.Length == 0)
                {
                    Console.WriteLine("Error: Vertex name cannot be empty, ignoring input...", input);
                }
                else
                {
                    graph.vertices.Add(input);
                }

                input = Console.ReadLine().Trim();
            }

            Console.WriteLine("Enter an comma separated edge info (ex: A,B) and press enter to submit. Enter 'ok' to complete.");

            input = Console.ReadLine().Trim();
            while (input != "ok")
            {
                if (input.Contains(','))
                {
                    string[] parsedInput = input.Split(',');
                    (string from, string to) = (parsedInput[0], parsedInput[1]);

                    if (!graph.vertices.Contains(from) || !graph.vertices.Contains(to))
                    {
                        Console.WriteLine("Error: Given vertex name '{0}' does not exist on vertices list, ignoring input...", !graph.vertices.Contains(from) ? from : to);
                    }
                    else if (graph.edges.Contains((from, to)) || graph.edges.Contains((to, from)))
                    {
                        Console.WriteLine("Error: Edge from '{0}' to '{1}' already exist (might exist in reversed order), ignoring input...", from, to);
                    }
                    else
                    {
                        graph.edges.Add((from, to));
                    }
                }
                else
                {
                    Console.WriteLine("Error: Input does not contain comma, ignoring input...");
                }


                input = Console.ReadLine().Trim();
            }

            return graph;
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

        static void PrintList(Dictionary<string, string[]> list)
        {
            foreach (var key in list.Keys)
            {
                Console.WriteLine("{0} -> [{1}]", key, string.Join(", ", list[key]));
            }
        }
    }

    class Vertices : List<string> { }
    class Edges : List<(string, string)> { }

    class Graph
    {
        public Edges edges;
        public Vertices vertices;

        public int[,] adjMatrix;
        public Dictionary<string, string[]> adjList;

        public Graph()
        {
            this.edges = new Edges();
            this.vertices = new Vertices();
        }

        public void generateAdjacencyMatrix()
        {
            int n = this.vertices.Count;
            int[,] matrix = new int[n, n];

            this.edges.ForEach(edge => {
                (string from, string to) = edge;
                int i = this.vertices.IndexOf(from);
                int j = this.vertices.IndexOf(to);

                matrix[i, j] = 1;
                matrix[j, i] = 1;
            });

            this.adjMatrix = matrix;
        }

        public void generateAdjacencyList()
        {
            var list = new Dictionary<string, string[]>();

            this.vertices.ForEach(vertex => {
                var edges = new List<string>();

                this.edges.ForEach(edge => {
                    (string from, string to) = edge;
                    if (from == vertex || to == vertex)
                    {
                        edges.Add(from == vertex ? to : from);
                    }
                });

                list[vertex] = edges.ToArray();
            });

            this.adjList = list;
        }

        public bool checkIfGraphBipartiteUsingAdjMatrix()
        {
            var matrix = this.adjMatrix; // only input
            var n = matrix.GetLength(0);
            var colors = new Dictionary<int, int>(); // 0=red, 1=blue

            for (int i = 0; i < n; i++)
            {
                int selfColor = 0; // red
                int oppositeColor = 1; // blue

                if (!colors.ContainsKey(i))
                {
                    colors.Add(i, selfColor);
                }
                else
                {
                    selfColor = colors[i];
                    oppositeColor = selfColor == 1 ? 0 : 1;
                }

                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        if (i == j)
                        {
                            return false;
                        }

                        if (!colors.ContainsKey(j))
                        {
                            colors.Add(j, oppositeColor);
                        }
                        else if (colors[j] != oppositeColor)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool checkIfGraphBipartiteUsingAdjList()
        {
            var list = this.adjList; // only input
            var colors = new Dictionary<string, int>(); // 0=red, 1=blue

            foreach (var vertex in list.Keys)
            {
                var edges = list[vertex];

                int selfColor = 0; // red
                int oppositeColor = 1; // blue

                if (!colors.ContainsKey(vertex))
                {
                    colors.Add(vertex, selfColor);
                }
                else
                {
                    selfColor = colors[vertex];
                    oppositeColor = selfColor == 1 ? 0 : 1;
                }

                for (int i = 0; i < edges.Length; i++)
                {
                    var edge = edges[i];

                    if (vertex == edge)
                    {
                        return false;
                    }

                    if (!colors.ContainsKey(edge))
                    {
                        colors.Add(edge, oppositeColor);
                    }
                    else if (colors[edge] != oppositeColor)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}