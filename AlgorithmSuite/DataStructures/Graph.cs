using AlgorithmSuite.Components;
using System;
using System.Collections.Generic;

namespace AlgorithmSuite.DataStructures
{
    public class Graph<VertexType>
    {
        Dictionary<VertexType, EdgeList<VertexType>> _adjacentEdges;
        #region Properties
        /// <summary>
        /// Returns the number of vertices in this Graph.
        /// </summary>
        public int NumVertices { get; private set; }
        #endregion

        /// <summary>
        /// Creates a Graph with a specific number of vertices.
        /// </summary>
        /// <param name="vertices">The vertices in the Graph.</param>
        public Graph(VertexList<VertexType> vertices)
        {
            NumVertices = vertices.Count;
            _adjacentEdges = new Dictionary<VertexType, EdgeList<VertexType>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i] != null)
                    _adjacentEdges[vertices[i]] = new EdgeList<VertexType>();
            }
        }

        /// <summary>
        /// Adds an edge to this Graph.
        /// </summary>
        /// <param name="source">A value that identifies the source vertex of the edge.</param>
        /// <param name="edge">The edge to add.</param>
        /// <returns>A value of true if the edge is successfully created and false if it's not.</returns>
        public bool AddEdge(VertexType source, Edge<VertexType> edge)
        {
            bool edgeAdded = false;
            if (edge != null)
            {
                if (VertexExists(source) && VertexExists(edge.Destination))
                {
                    Edge<VertexType> existingEdge = GetEdge(source, edge.Destination);
                    if (existingEdge != null)
                        _adjacentEdges[source].Remove(existingEdge);
                    _adjacentEdges[source].Add(edge);
                    edgeAdded = true;
                }
            }
            return edgeAdded;
        }

        /// <summary>
        /// Adds an edge with a weight to this Graph.
        /// </summary>
        /// <param name="source">A value that identifies the source vertex of the edge.</param>
        /// <param name="destination">A value that identifies the destination vertex of the edge.</param>
        /// <param name="weight">The weight value of the edge.</param>
        /// <returns>A value of true if the edge is successfully created and false if it's not.</returns>
        public bool AddEdge(VertexType source, VertexType destination, int weight = Int32.MaxValue)
        {
            return AddEdge(source, new Edge<VertexType>(destination, weight));
        }

        /// <summary>
        /// Adds a collection of edges that originate from the specified source vertex.
        /// </summary>
        /// <param name="source">A value that identifies the source vertex from which the edges will originate.</param>
        /// <param name="edges">The edges to add.</param>
        public void AddEdges(VertexType source, Edge<VertexType>[] edges)
        {
            foreach (Edge<VertexType> edge in edges)
            {
                AddEdge(source, edge);
            }
        }

        /// <summary>
        /// Returns an edge that exists between the specified vertices or null if it doesn't exist.
        /// </summary>
        /// <param name="source">A value that identifies the source vertex of the edge.</param>
        /// <param name="destination">A value that identifies the destination vertex of the edge.</param>
        /// <returns>an edge that exists between the specified vertices or null if it doesn't exist.</returns>
        private Edge<VertexType> GetEdge(VertexType source, VertexType destination)
        {
            Edge<VertexType> edge = null;
            if (VertexExists(source) && VertexExists(destination))
            {
                edge = _adjacentEdges[source].Find(e => e.Destination.Equals(destination));
            }
            return edge;
        }

        /// <summary>
        /// Returns the neighbors of the specified source vertex.
        /// </summary>
        /// <param name="source">A value that identifies the source vertex.</param>
        public EdgeList<VertexType> GetNeighbors(VertexType source)
        {
            EdgeList<VertexType> neighbors = null;
            if (VertexExists(source))
                neighbors = _adjacentEdges[source];
            return neighbors;
        }

        /// <summary>
        /// Returns a string representation of the specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex whose string representation will be returned.</param>
        /// <returns>A string representation of the specified vertex.</returns>
        public string GetVertexAsString(VertexType vertex)
        {
            string value = string.Empty;
            EdgeList<VertexType> neighbors = GetNeighbors(vertex);
            if (neighbors != null && VertexExists(vertex))
            {
                string neighborsAsString = string.Empty;
                for (int i = 0; i < neighbors.Count; i++)
                {
                    Edge<VertexType> neighbor = neighbors[i];
                    if (i > 0)
                        neighborsAsString += ", ";
                    neighborsAsString += string.Format("{0}:{1}", neighbor.Destination.ToString(), neighbor.Weight);
                }
                if (string.IsNullOrEmpty(neighborsAsString))
                    value = string.Format("[{0}]", vertex.ToString());
                else
                    value = string.Format("[{0}] - {{{1}}}", vertex.ToString(), neighborsAsString);
            }
            return value;
        }

        /// <summary>
        /// Returns a list containing all of the vertices in this Graph.
        /// </summary>
        /// <returns>A list containing all of the vertices in this Graph.</returns>
        public VertexList<VertexType> GetVertices()
        {
            VertexList<VertexType> vertices = new VertexList<VertexType>();
            foreach (VertexType vertex in _adjacentEdges.Keys)
            {
                vertices.Add(vertex);
            }
            return vertices;
        }

        /// <summary>
        /// Returns a value of true if an edge exists between the specified vertices and false otherwise.
        /// </summary>
        /// <param name="source">A value that identifies the source vertex of the edge.</param>
        /// <param name="destination">A value that identifies the destination vertex of the edge.</param>
        /// <returns>A value of true if an edge exists between the specified vertices and false otherwise.</returns>
        private bool EdgeExists(VertexType source, VertexType destination)
        {
            return (GetEdge(source, destination) != null);
        }

        /// <summary>
        /// Removes an edge from this Graph.
        /// </summary>
        /// <param name="source">A value that identifies the source vertex of the edge.</param>
        /// <param name="destination">A value that identifies the destination vertex of the edge.</param>
        /// <returns>A value of true if the edge is successfully removed and false if it's not.</returns>
        public bool RemoveEdge(VertexType source, VertexType destination)
        {
            bool edgeRemoved = false;
            Edge<VertexType> edgeToRemove = GetEdge(source, destination);
            if (edgeToRemove != null)
                edgeRemoved = _adjacentEdges[source].Remove(edgeToRemove);
            return edgeRemoved;
        }

        /// <summary>
        /// Returns a string representation of this Graph.
        /// </summary>
        /// <returns>A string representation of this Graph.</returns>
        public override string ToString()
        {
            string value = string.Empty;
            foreach (VertexType vertex in _adjacentEdges.Keys)
            {
                value += GetVertexAsString(vertex) + "\n";
            }
            return value;
        }

        /// <summary>
        /// Returns a value of true if the specified vertex exists and false if it doesn't.
        /// </summary>
        /// <param name="vertexId">A value that identifies the vertex.</param>
        /// <returns>A value of true if the specified vertex exists and false if it doesn't.</returns>
        public bool VertexExists(VertexType vertexId)
        {
            return (vertexId != null && _adjacentEdges.ContainsKey(vertexId));
        }
    }
}
