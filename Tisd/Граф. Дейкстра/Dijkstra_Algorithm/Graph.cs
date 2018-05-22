using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra_s_algorithm
{
    public class Graph<T> 
    {
        private NodeList<T> nodeSet;//список узлов графа
        public Graph() : this(null) { }
        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet == null)
                this.nodeSet = new NodeList<T>();
            else
                this.nodeSet = nodeSet;
        }
        public NodeList<T> Nodes {get{return nodeSet;}}
        public int Count {get {return nodeSet.Count;}}
        public void AddNode(GraphNode<T> node)
        {
            // добавляет узел в граф
            nodeSet.Add(node);
        }
        
        public void AddNode(T value)
        {
            // добавляет узел в граф
            nodeSet.Add(new GraphNode<T>(value));
        }
        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {//Создание направленного ребра сводится
            from.Neighbors.Add(to);//к добавлению узлу, из которого выходим, соседа,
            from.Costs.Add(cost);  //а также веса ребра
        }
        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {//Создание ненаправленного ребра сводится к аналогичным действиям как и выше,
            from.Neighbors.Add(to);
            from.Costs.Add(cost);  
            to.Neighbors.Add(from);//но в обе стороны
            to.Costs.Add(cost);
        }
        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }
        public bool Remove(T value)
        {
            // сперва удалить узел из множества узлов
            GraphNode<T> nodeToRemove = (GraphNode<T>)
            nodeSet.FindByValue(value);
            if (nodeToRemove == null)
                // узел не найден
                return false;
            // в противном случае узел найден
            nodeSet.Remove(nodeToRemove);
            // пройти по каждому узлу в наборе узлов, удаляя ребра к данному узлу
            foreach (GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // удалить ссылку на узел и его стоимость
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }
            return true;
        }
    }
}
