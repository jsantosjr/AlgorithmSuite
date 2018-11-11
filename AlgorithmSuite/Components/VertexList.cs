using System.Collections.Generic;

namespace AlgorithmSuite.Components
{
    /// <summary>
    /// The VertexList class return a list of vertices.
    /// </summary>
    public class VertexList<VertexType> : List<VertexType>
    {
        /// <summary>
        /// Returns a string representation of this VertexList.
        /// </summary>
        /// <returns>A string representation of this VertexList.</returns>
        public override string ToString()
        {
            string value = string.Empty;
            for (int i = 0; i < Count; i++)
            {
                VertexType element = this[i];
                if (i > 0)
                    value += ", ";
                value += (element != null) ? element.ToString() : string.Empty;
            }
            return value;
        }
    }
}
