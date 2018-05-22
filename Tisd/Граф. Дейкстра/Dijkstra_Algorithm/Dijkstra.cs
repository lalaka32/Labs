using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra_s_algorithm
{
    class DijkstraData<T>//данные алгоритма
    {
        public double Price { get; set; }//кратчайшее рассояние до заданного узла
        public GraphNode<T> Previous { get; set; }//прошлый в обработке узел
    }
    class Dijkstra<T>
    {
        public static List<string> DijkstraAlgorithm(Graph<T> CurrentGrahp, GraphNode<T> selectedNode)// граф и нужный узел
        {
            NodeList<T> notVisited = CurrentGrahp.Nodes;//список непосещённых узлов
            Dictionary<GraphNode<T>, DijkstraData<T>> track = new Dictionary<GraphNode<T>, DijkstraData<T>>();
            //словарь, хранящий в ключе узел и в значении данные алгоритма
            track[selectedNode] = new DijkstraData<T> { Previous = null, Price = 0 };//добавление выбранного узла в активные данные
            while (notVisited.Count != 0)//пока есть непосещённых узлов  
            {
                GraphNode<T> openNode = null;
                double bestPrice = double.MaxValue;//создание лучшего пути
                foreach (var item in notVisited)
                {
                    //если в активных данных есть узел из непосещённых и у него путь до выбранного узла меньше нынешнего лучшего пути
                    if (track.ContainsKey(item) && track[item].Price < bestPrice)
                    {
                        openNode = item;//то он выбирается для обработки
                        bestPrice = track[item].Price;//и лучший путь обновляется приравниваясь к пути данного узла
                    }
                }//!!!в конце цикла будет найден ближайший сосед для обработки
                if (openNode == null) return null;//если вдруг граф несвязный, в определённый момент алгоритм завершится без ошибок
                for (int i = 0; i < openNode.Costs.Count; i++)//цикл по соседям выбранного для обработки узла
                {
                    double currentPrice = track[openNode].Price + openNode.Costs[i];//создание пути для данного соседа сложением пути
                    //обрабатываемого узла и веса ребра между соседом и обрабатываемым узлом
                    GraphNode<T> nextNode = openNode.Neighbors[i];//создание предполагаемого следующего узла в виде данного соседа
                    //если такого узла в активных данных нет или его путь лучше(меньше) записанного в активных данных
                    if (!track.ContainsKey(nextNode) || track[nextNode].Price > currentPrice)
                    {//то узел будет добавлен в активные данные со своим весом и прошлым узлом, находящимся сейчас на раскрытии(обработке)
                        track[nextNode] = new DijkstraData<T> { Price = currentPrice, Previous = openNode };
                    }
                }//!!!в конце цикла все недобавленные в активные данные соседи будут добавлены, а у уже добавленных будут обновлены 
                //величина пути и предыдущий узел, если его предыдущая величина пути была больше
                notVisited.Remove(openNode);//из непосещённых узлов удаляется уже обработанный
            }
            var result = new List<string>();
            foreach (var item in track)
            {
                result.Add("К узлу " + item.Key.Value +
                    " минимальный путь от узла " +
                    selectedNode.Value + " = " + item.Value.Price);
            }
            return result;
        }
    }
}
