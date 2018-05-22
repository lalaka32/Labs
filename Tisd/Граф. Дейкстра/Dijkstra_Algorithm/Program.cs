using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;


namespace Dijkstra_s_algorithm
{

    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> web = new Graph<string>();
            GraphNode<string> node1 = new GraphNode<string>("A");
            GraphNode<string> node2 = new GraphNode<string>("B");
            GraphNode<string> node3 = new GraphNode<string>("C");
            GraphNode<string> node4 = new GraphNode<string>("D");
            GraphNode<string> node5 = new GraphNode<string>("E");

            web.AddNode(node1);
            web.AddNode(node2);
            web.AddNode(node3);
            web.AddNode(node4);
            web.AddNode(node5);

            web.AddUndirectedEdge(node1, node2, 5);
            web.AddUndirectedEdge(node2, node3, 3);
            web.AddUndirectedEdge(node1, node3, 1);
            web.AddUndirectedEdge(node3, node4, 4);
            web.AddUndirectedEdge(node4, node5, 11);
            web.AddUndirectedEdge(node1, node5, 2);
            Print(web);

            //List<string> resultlist = Dijkstra<string>.DijkstraAlgorithm(web, node1);
            //Console.WriteLine("\nРезультат алгоритма Дейкстры:");
            //foreach (var item in resultlist)//Вывод алгоритма Дейкстры
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("\nРезультат алгоритма Прима:");
            Graph<string> web2 = Prima<string>.AlgorithmByPrim(web);
            Print(web2);

            Console.ReadKey();
        }

        static void Print(Graph<string> web)
        {
            foreach (var item in web.Nodes)//вывод
            {
                if (item.Neighbors.Count == 0)
                {
                    Console.Write("\nУзел " + item.Value + " не имеет соседей");
                }
                else
                {
                    Console.Write("\nУзел " + item.Value + " имеет соседей:");
                    foreach (var neigh in item.Neighbors)
                    {
                        Console.Write(neigh.Value + " ");
                    }
                    Console.Write("\nРасстояние до них: ");
                    foreach (var cost in item.Costs)
                    {
                        Console.Write(cost + " ");
                    }
                }
            }
        }
    }
}

