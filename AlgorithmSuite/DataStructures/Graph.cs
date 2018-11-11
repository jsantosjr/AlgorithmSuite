using System;
using System.Collections.Generic;

namespace AlgorithmSuite.DataStructures
{
    /// <summary>
    /// The Edge class is used to identify the connection between two vertices on a graph. It is characterized as having
    /// a destination vertex and a weight value.
    /// </summary>
    public class Edge<VertexType>
    {
        #region Properties
        /// <summary>
        /// Returns a value that identifies the destination vertex of this Edge.
        /// </summary>
        public VertexType Destination { get; private set; }

        /// <summary>
        /// Returns and sets the weight of this Edge.
        /// </summary>
        public int Weight { get; private set; }
        #endregion

        /// <summary>
        /// Creates an Edge instance.
        /// </summary>
        /// <param name="destination">A value that identifies the destination vertex of the Edge.</param>
        /// <param name="weight">The weight value of the Edge.</param>
        public Edge(VertexType destination, int weight = Int32.MaxValue)
        {
            Destination = destination;
            Weight = weight;
        }
    }

    public class Graph<VertexType>
    {
        Dictionary<VertexType, List< Edge<VertexType>>> _adjacentEdges;
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
        public Graph(VertexType[] vertices)
        {
            NumVertices = vertices.Length;
            _adjacentEdges = new Dictionary<VertexType, List<Edge<VertexType>>>();
            for (int i = 0; i < vertices.Length; i++)
            {
                _adjacentEdges[vertices[i]] = new List<Edge<VertexType>>();
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
            if (VertexExists(source) && VertexExists(edge.Destination))
            {
                Edge<VertexType> existingEdge = GetEdge(source, edge.Destination); 
                if (existingEdge != null)
                    _adjacentEdges[source].Remove(existingEdge);
                _adjacentEdges[source].Add(edge);
                edgeAdded = true;
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
        /// Returns a string representation of the specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex whose string representation will be returned.</param>
        /// <returns>A string representation of the specified vertex.</returns>
        public string GetVertexAsString(VertexType vertex)
        {
            string value = string.Empty;
            List<Edge<VertexType>> children = GetChildren(vertex);
            if (children != null && VertexExists(vertex))
            {
                string childrenAsString = string.Empty;
                for (int i = 0; i < children.Count; i++)
                {
                    Edge<VertexType> child = children[i];
                    if (i > 0)
                        childrenAsString += ", ";
                    childrenAsString += string.Format("{0}:{1}", child.Destination.ToString(), child.Weight);
                }
                if (string.IsNullOrEmpty(childrenAsString))
                    value = string.Format("[{0}]", vertex.ToString());
                else
                    value = string.Format("[{0}] - {{{1}}}", vertex.ToString(), childrenAsString);
            }
            return value;
        }

        /// <summary>
        /// Returns the children of the specified source vertex.
        /// </summary>
        /// <param name="source">A value that identifies the source vertex.</param>
        public List<Edge<VertexType>> GetChildren(VertexType source)
        {
            List<Edge<VertexType>> children = null;
            if (VertexExists(source))
                children = _adjacentEdges[source];
            return children;
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
            return (_adjacentEdges.ContainsKey(vertexId));
        }
    }
}
