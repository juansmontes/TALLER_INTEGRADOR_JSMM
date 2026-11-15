
using System;
using CampusNet.Controllers;

namespace CampusNet
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphController controller = new GraphController();

            controller.AddVertex("A", "Universidad");
            controller.AddVertex("B", "Biblioteca");
            controller.AddVertex("C", "Laboratorio");
            controller.AddVertex("D", "Cafeteria");

            controller.AddEdge("A", "B");
            controller.AddEdge("A", "C");
            controller.AddEdge("B", "D");
            controller.AddEdge("C", "D");

            Console.WriteLine("SISTEMA DE GRAFOS");
            controller.ShowGraph();

            Console.ReadKey();
        }
    }
}
