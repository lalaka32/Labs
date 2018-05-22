using Dijkstra_s_algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra_s_algorithm
{
    class Prima<T>
    {
        static public Graph<T> AlgorithmByPrim(Graph<T> graph)
        {
            NodeList<T> result = new NodeList<T>();
            List<int> edges = new List<int>();
            //использованные вершины
            NodeList<T> usedNode = new NodeList<T>();
            //неиспользованные вершины
            NodeList<T> notUsedNode = graph.Nodes;
            //выбираем случайную начальную вершину
            Random rnd = new Random();
            int randint = rnd.Next(0, notUsedNode.Count);
            usedNode.Add(notUsedNode[randint]);
            result.Add(new GraphNode<T>(usedNode[0].Value));
            notUsedNode.RemoveAt(randint);
            while (notUsedNode.Count > 0)
            {
                //поиск ближайшего соседа группы usedNode
                int closestEdge = int.MaxValue;
                GraphNode<T> closestNeighbor = new GraphNode<T>();
                int numberPreviosNode = 0;
                for (int i = 0; i < usedNode.Count; i++)
                {
                    if (usedNode[i].Neighbors.Count != 0)
                    {
                        int toOpenEdge;
                        GraphNode<T> toOpen = usedNode[i].GetClosestNeighbor(out toOpenEdge);
                        if (toOpenEdge < closestEdge)
                        {
                            closestEdge = toOpenEdge;
                            closestNeighbor = toOpen;
                            numberPreviosNode = i;
                        }
                    }
                }
                for (int i = 0; i < usedNode.Count; i++)
                {
                    if (usedNode[i].Neighbors.Contains(closestNeighbor))
                    //удаление для неориентированных графов
                    {
                        usedNode[i].Costs.RemoveAt(usedNode[i].Neighbors.IndexOf(closestNeighbor));
                        usedNode[i].Neighbors.Remove(closestNeighbor);
                        closestNeighbor.Costs.RemoveAt(closestNeighbor.Neighbors.IndexOf(usedNode[i]));
                        closestNeighbor.Neighbors.Remove(usedNode[i]);
                    }
                }
                GraphNode<T> resultNode = new GraphNode<T>(closestNeighbor.Value);
                resultNode.Neighbors.Add(result[numberPreviosNode]);
                resultNode.Costs.Add(closestEdge);
                result[numberPreviosNode].Neighbors.Add(resultNode);
                result[numberPreviosNode].Costs.Add(closestEdge);

                result.Add(resultNode);

                usedNode.Add(closestNeighbor);
                notUsedNode.Remove(closestNeighbor);
            }

            return new Graph<T>(result);
        }
    }
}
