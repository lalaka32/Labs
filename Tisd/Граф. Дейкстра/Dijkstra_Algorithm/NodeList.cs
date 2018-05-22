using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Dijkstra_s_algorithm
{
    public class NodeList<T> : Collection<GraphNode<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(GraphNode<T>));
        }

        public GraphNode<T> FindByValue(T value)
        {
            foreach (GraphNode<T> node in Items)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }
            return null;
        }
    }
}
