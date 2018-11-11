using System;
using System.Collections.Generic;

namespace AlgorithmSuite.Components
{
    public class Vertex
    {
        #region Properties
        /// <summary>
        /// Gets the ID of the vertex.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets and sets the ID of the vertex that was previously visited.
        /// </summary>
        public string PreviousId { get; set; }

        /// <summary>
        /// Gets and sets the shortest distance to the vertex.
        /// </summary>
        public int Distance { get; set; }
        #endregion

        /// <summary>
        /// Creates a Vertex instance.
        /// </summary>
        /// <param name="id">The ID of the Vertex.</param>
        public Vertex(string id)
        {
            Id = id;
            PreviousId = null;
            Distance = Int32.MaxValue;
        }

        /// <summary>
        /// Determines whether the specified Vertex is equal to this Vertex.
        /// </summary>
        /// <param name="obj">The Vertex to compare with this Vertex.</param>
        /// <returns>A value of true if the vertices are equal and false otherwise.</returns>
        public override bool Equals(object obj)
        {
            bool equal = false;
            if (obj.GetType() == typeof(Vertex))
            {
                equal = Equals(obj as Vertex);
            }
            return equal;
        }

        /// <summary>
        /// Determines whether the specified Vertex is equal to this Vertex.
        /// </summary>
        /// <param name="vertex">The Vertex to compare with this Vertex.</param>
        /// <returns>A value of true if the vertices are equal and false otherwise.</returns>
        public bool Equals(Vertex vertex)
        {
            return (vertex != null && Id == vertex.Id);
        }

        /// <summary>
        /// Returns a unique hash code for this Vertex based on its ID.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return EqualityComparer<string>.Default.GetHashCode(Id);
        }

        /// <summary>
        /// Returns a string representation of this Vertex.
        /// </summary>
        /// <returns>A string representation of this Vertex.</returns>
        public override string ToString()
        {
            return (Id != null) ? Id : string.Empty;
        }
    }

    /// <summary>
    /// The VertexListExtension class provides a Get extension method for a VertexList instance that contains Vertex objects.
    /// </summary>
    public static class VertexListExtensions
    {
        /// <summary>
        /// Returns the Vertex in a VertexList container with the specified ID.
        /// </summary>
        /// <param name="obj">The VertexList container from which to retrieve a Vertex object.</param>
        /// <param name="id">The ID of the Vertex object to return.</param>
        /// <returns>The Vertex in a VertexList container with the specified ID or null if no match is found.</returns>
        public static Vertex Get(this VertexList<Vertex> obj, string id)
        {
            return obj.Find(e => e.Id == id);
        }
    }
}
