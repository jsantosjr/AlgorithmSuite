﻿using AlgorithmSuite.Components;
using AlgorithmSuite.DataStructures;

namespace AlgorithmSuite.Algorithms
{
    public class Dijkstra
    {
        private bool _calculated;
        private Graph<Vertex> _graph;

        /// <summary>
        /// Creates a Dijkstra instance that is used to calculate the shortest path between vertices.
        /// </summary>
        /// <param name="graph">The graph on which shortest paths will be calculated.</param>
        public Dijkstra(Graph<Vertex> graph)
        {
            _calculated = false;
            _graph = graph;
        }

        /// <summary>
        /// Calculates shortest paths between all vertices in the specified graph.
        /// </summary>
        /// <param name="graph">The graph on which shortest paths will be calculated.</param>
        /// <returns>A graph that's updated with the calculated shortest paths.</returns>
        private void CalculateShortestPaths()
        {
            VertexList<Vertex> unvisited = (_graph != null) ? _graph.GetVertices() : null;
            if (unvisited != null && unvisited.Count > 0)
            {
                VertexList<Vertex> visited = new VertexList<Vertex>();
                Vertex currentVertex = unvisited[0];
                currentVertex.Distance = 0;
                while (unvisited.Count > 0)
                {
                    visited.Add(currentVertex);
                    unvisited.Remove(currentVertex);
                    EdgeList<Vertex> neighbors = _graph.GetNeighbors(currentVertex);
                    foreach (Edge<Vertex> neighbor in neighbors)
                    {
                        Vertex neighborVertex = neighbor.Destination;
                        if (visited.Contains(neighborVertex))
                        {
                            continue;
                        }
                        else
                        {
                            int distance = currentVertex.Distance + neighbor.Weight;
                            if (distance < neighborVertex.Distance)
                            {
                                neighborVertex.Distance = distance;
                                neighborVertex.Previous = currentVertex;
                            }
                        }
                    }
                    currentVertex = GetShortestVertex(currentVertex, unvisited);
                }
            }
            _calculated = true;
        }

        /// <summary>
        /// Calculates and returns the shortest path between the specified vertices in the specified graph.
        /// </summary>
        /// <param name="startVertex">The start Vertex.</param>
        /// <param name="endVertex">The end vertex.</param>
        /// <returns>A graph that's updated with the calculated shortest paths.</returns>
        public VertexList<Vertex> GetShortestPath(Vertex startVertex, Vertex endVertex)
        {
            if (!_calculated)
                CalculateShortestPaths();

            VertexList<Vertex> path = new VertexList<Vertex>();
            if (_graph != null && _graph.VertexExists(startVertex) && _graph.VertexExists(endVertex))
            {
                Vertex currentVertex = endVertex;
                while (currentVertex != null)
                {
                    if (_graph.VertexExists(currentVertex))
                    {
                        path.Add(currentVertex);
                        currentVertex = currentVertex.Previous;
                    }
                    else
                    {
                        path.Clear();
                        break;
                    }
                }
                path.Reverse();
            }
            return path;
        }

        /// <summary>
        /// Searches the passed in vertices and returns the Vertex with the smallest distance from the specified source Vertex.
        /// </summary>
        /// <param name="source">The source Vertex.</param>
        /// <param name="vertices">The vertices to search.</param>
        /// <returns>The Vertex with the smallest distance from the specified source vertex or null if no vertices exist.</returns>
        private Vertex GetShortestVertex(Vertex source, VertexList<Vertex> vertices)
        {
            Vertex vertex = null;
            if (source != null && vertices != null && vertices.Count > 0)
            {
                vertex = vertices[0];
                for (int i = 1; i < vertices.Count; i++)
                {
                    Vertex existingVertex = vertices[i];
                    Vertex previousVertex = (existingVertex != null) ? existingVertex.Previous : null;
                    if (existingVertex != null && previousVertex != null && existingVertex.Previous.Id == source.Id)
                    {
                        if (vertex == null || existingVertex.Distance < vertex.Distance)
                            vertex = existingVertex;
                    }
                }
            }
            return vertex;
        }
    }
}
