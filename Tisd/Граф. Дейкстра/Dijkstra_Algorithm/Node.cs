using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra_s_algorithm
{
    public class Node<T>
    {
        private T data;
        private NodeList<T> neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }//ссылка на другой конструктор, но neighbors = 0
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value {get { return data; } set { data = value; } }
        protected NodeList<T> Neighbors { get { return neighbors; } set { neighbors = value; } }
    }
}

