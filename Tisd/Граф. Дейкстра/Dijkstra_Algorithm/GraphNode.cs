using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra_s_algorithm
{
    public class GraphNode<T> : Node<T>
    {
        private List<int> costs;
        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

        new public NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>();
                return base.Neighbors;
            }
        }
        public List<int> Costs
        {
            get
            {
                if (costs == null)
                    costs = new List<int>();
                return costs;
            }
        }
        public GraphNode<T> GetClosestNeighbor(out int mincost)
        {
            mincost = costs.Min();
            return Neighbors.ElementAt(costs.IndexOf(mincost));
        }
    }

}
