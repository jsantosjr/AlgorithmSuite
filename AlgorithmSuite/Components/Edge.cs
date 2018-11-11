using System;

namespace AlgorithmSuite.Components
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
}
