using AlgorithmSuite.DataStructures;

namespace Examples
{
    public class Driver
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>(new string[] { "S", "A", "B", "D", "F", "H", "G", "C", "L", "I", "J", "K", "E" });
            graph.AddEdges("S", new Edge<string>[] { new Edge<string>("A", 7), new Edge<string>("B", 2), new Edge<string>("C", 3) });
            graph.AddEdges("A", new Edge<string>[] { new Edge<string>("S", 7), new Edge<string>("B", 3), new Edge<string>("D", 4) });
            graph.AddEdges("B", new Edge<string>[] { new Edge<string>("S", 2), new Edge<string>("A", 3), new Edge<string>("D", 4), new Edge<string>("H", 1) });
            graph.AddEdges("D", new Edge<string>[] { new Edge<string>("A", 4), new Edge<string>("B", 4), new Edge<string>("F", 5) });
            graph.AddEdges("F", new Edge<string>[] { new Edge<string>("D", 5), new Edge<string>("H", 3) });
            graph.AddEdges("H", new Edge<string>[] { new Edge<string>("B", 1), new Edge<string>("F", 3), new Edge<string>("G", 2) });
            graph.AddEdges("G", new Edge<string>[] { new Edge<string>("H", 2), new Edge<string>("E", 2) });
            graph.AddEdges("C", new Edge<string>[] { new Edge<string>("S", 3), new Edge<string>("L", 2) });
            graph.AddEdges("L", new Edge<string>[] { new Edge<string>("C", 2), new Edge<string>("I", 4), new Edge<string>("J", 4) });
            graph.AddEdges("I", new Edge<string>[] { new Edge<string>("L", 4), new Edge<string>("J", 6), new Edge<string>("K", 4) });
            graph.AddEdges("J", new Edge<string>[] { new Edge<string>("L", 4), new Edge<string>("I", 6), new Edge<string>("K", 4) });
            graph.AddEdges("K", new Edge<string>[] { new Edge<string>("J", 4), new Edge<string>("I", 4), new Edge<string>("E", 5) });
            graph.AddEdges("E", new Edge<string>[] { new Edge<string>("G", 2), new Edge<string>("K", 5) });
            System.Console.WriteLine(graph.ToString());
        }
    }
}
