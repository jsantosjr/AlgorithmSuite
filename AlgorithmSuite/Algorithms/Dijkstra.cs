using AlgorithmSuite.Components;
using AlgorithmSuite.DataStructures;

namespace AlgorithmSuite.Algorithms
{
    public class Dijkstra
    {
        /// <summary>
        /// Creates a Dijkstra instance that is used to calculate the shortest path between vertices.
        /// </summary>
        /// <param name="graph">The Graph on which shortest paths will be calculated.</param>
        public Dijkstra()
        {
        }

        /// <summary>
        /// Calculates and returns the shortest path between the specified start and end vertices on the specified graph.
        /// </summary>
        /// <param name="startVertex">The start vertex.</param>
        /// <param name="endVertex">The end vertex.</param>
        /// <param name="graph">The graph on which a shortest path will be calculated.</param>
        public VertexList<Vertex> GetShortestPath(Vertex startVertex, Vertex endVertex, Graph<Vertex> graph)
        {
            VertexList<Vertex> path = new VertexList<Vertex>();
            if (graph != null)
            {
                VertexList<Vertex> unvisited = graph.GetVertices();
                VertexList<Vertex> visited = new VertexList<Vertex>();
            }
            return path;
        }
    }
}
