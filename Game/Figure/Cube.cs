using System.Collections.Generic;

namespace Lab4GK.Figure
{
    class Cube
    {
        public List<Edge> edges = new List<Edge>();
        public void AddEdge(Edge edge)
        {
            edges.Add(edge);
        }

    }
}
