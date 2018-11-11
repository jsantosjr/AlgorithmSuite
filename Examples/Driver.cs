using AlgorithmSuite.Algorithms;
using AlgorithmSuite.Components;
using AlgorithmSuite.DataStructures;

namespace Examples
{
    public class Driver
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            driver.CalculateShortestPath();
        }

        private Graph<Vertex> BuildLargeGraph()
        {
            VertexList<Vertex> vertices = new VertexList<Vertex>() {
                new Vertex("S"), new Vertex("A"), new Vertex("B"), new Vertex("D"),
                new Vertex("F"), new Vertex("H"), new Vertex("G"), new Vertex("C"),
                new Vertex("L"), new Vertex("I"), new Vertex("J"), new Vertex("K"),
                new Vertex("E") };

            Graph<Vertex> graph = new Graph<Vertex>(vertices);
            graph.AddEdges(vertices.Get("S"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("A"), 7), new Edge<Vertex>(vertices.Get("B"), 2), new Edge<Vertex>(vertices.Get("C"), 3) });
            graph.AddEdges(vertices.Get("A"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("S"), 7), new Edge<Vertex>(vertices.Get("B"), 3), new Edge<Vertex>(vertices.Get("D"), 4) });
            graph.AddEdges(vertices.Get("B"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("S"), 2), new Edge<Vertex>(vertices.Get("A"), 3), new Edge<Vertex>(vertices.Get("D"), 4), new Edge<Vertex>(vertices.Get("H"), 1) });
            graph.AddEdges(vertices.Get("D"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("A"), 4), new Edge<Vertex>(vertices.Get("B"), 4), new Edge<Vertex>(vertices.Get("F"), 5) });
            graph.AddEdges(vertices.Get("F"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("D"), 5), new Edge<Vertex>(vertices.Get("H"), 3) });
            graph.AddEdges(vertices.Get("H"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("B"), 1), new Edge<Vertex>(vertices.Get("F"), 3), new Edge<Vertex>(vertices.Get("G"), 2) });
            graph.AddEdges(vertices.Get("G"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("H"), 2), new Edge<Vertex>(vertices.Get("E"), 2) });
            graph.AddEdges(vertices.Get("C"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("S"), 3), new Edge<Vertex>(vertices.Get("L"), 2) });
            graph.AddEdges(vertices.Get("L"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("C"), 2), new Edge<Vertex>(vertices.Get("I"), 4), new Edge<Vertex>(vertices.Get("J"), 4) });
            graph.AddEdges(vertices.Get("I"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("L"), 4), new Edge<Vertex>(vertices.Get("J"), 6), new Edge<Vertex>(vertices.Get("K"), 4) });
            graph.AddEdges(vertices.Get("J"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("L"), 4), new Edge<Vertex>(vertices.Get("I"), 6), new Edge<Vertex>(vertices.Get("K"), 4) });
            graph.AddEdges(vertices.Get("K"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("J"), 4), new Edge<Vertex>(vertices.Get("I"), 4), new Edge<Vertex>(vertices.Get("E"), 5) });
            graph.AddEdges(vertices.Get("E"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("G"), 2), new Edge<Vertex>(vertices.Get("K"), 5) });
            return graph;
        }

        private Graph<Vertex> BuildSmallGraph()
        {
            VertexList<Vertex> vertices = new VertexList<Vertex>() { new Vertex("A"), new Vertex("B"), new Vertex("C"), new Vertex("D"), new Vertex("E") };
            Graph<Vertex> graph = new Graph<Vertex>(vertices);
            graph.AddEdges(vertices.Get("A"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("B"), 6), new Edge<Vertex>(vertices.Get("D"), 1) });
            graph.AddEdges(vertices.Get("B"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("A"), 6), new Edge<Vertex>(vertices.Get("D"), 2), new Edge<Vertex>(vertices.Get("E"), 2), new Edge<Vertex>(vertices.Get("C"), 5) });
            graph.AddEdges(vertices.Get("C"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("B"), 5), new Edge<Vertex>(vertices.Get("E"), 5) });
            graph.AddEdges(vertices.Get("D"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("A"), 1), new Edge<Vertex>(vertices.Get("B"), 2), new Edge<Vertex>(vertices.Get("E"), 1) });
            graph.AddEdges(vertices.Get("E"), new Edge<Vertex>[] { new Edge<Vertex>(vertices.Get("D"), 1), new Edge<Vertex>(vertices.Get("B"), 2), new Edge<Vertex>(vertices.Get("C"), 5) });
            return graph;
        }

        public void CalculateShortestPath()
        {
            Graph<Vertex> graph = BuildLargeGraph();
            Dijkstra algorithm = new Dijkstra();
            graph = algorithm.CalculateShortestPaths(graph);

            VertexList<Vertex> allvertices = graph.GetVertices();
            VertexList<Vertex> pathVertices = algorithm.GetShortestPath(allvertices.Get("S"), allvertices.Get("E"), graph);
            System.Console.WriteLine(pathVertices);
        }
    }
}
