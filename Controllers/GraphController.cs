
using System.Collections.Generic;
using System.Linq;
using CampusNet.Models;

namespace CampusNet.Controllers
{
    public class GraphController
    {
        private readonly Graph graph;

        public GraphController()
        {
            graph = new Graph();
        }

        // CRUD: Agregar vertice
        public void AddVertex(string id, string name)
        {
            graph.AddVertex(id, name);
        }

        // CRUD: Agregar arista
        public void AddEdge(string fromId, string toId)
        {
            graph.AddEdge(fromId, toId);
        }

        // CRUD: Eliminar vertice
        public void RemoveVertex(string id)
        {
            graph.RemoveVertex(id);
        }

        // CRUD: Eliminar arista
        public void RemoveEdge(string fromId, string toId)
        {
            graph.RemoveEdge(fromId, toId);
        }

        // Obtener todos los vertices
        public List<Vertex> GetVertices()
        {
            return graph.Vertices;
        }

        // Obtener todas las aristas
        public List<Edge> GetEdges()
        {
            return graph.Edges;
        }

        // Obtener vecinos
        public List<string> GetNeighbors(string id)
        {
            return graph.GetNeighbors(id);
        }

        // Recorrido BFS
        public List<string> RunBFS(string startId)
        {
            return graph.BFS(startId);
        }

        // Recorrido DFS
        public List<string> RunDFS(string startId)
        {
            return graph.DFS(startId);
        }

        // Detectar ciclos
        public bool DetectCycle()
        {
            return graph.HasCycle();
        }

        // Obtener grado de entrada
        public int GetInDegree(string id)
        {
            return graph.GetInDegree(id);
        }

        // Obtener grado de salida
        public int GetOutDegree(string id)
        {
            return graph.GetOutDegree(id);
        }

        // Obtener usuarios influyentes
        public List<Vertex> GetInfluentialUsers()
        {
            return graph.GetInfluentialVertices();
        }

        // Obtener usuarios activos
        public List<Vertex> GetActiveUsers()
        {
            return graph.GetActiveVertices();
        }

        // Obtener usuarios sin seguidores
        public List<Vertex> GetUsersWithoutFollowers()
        {
            return graph.GetVerticesWithoutFollowers();
        }

        // Comprobar alcanzabilidad
        public bool CheckReachability(string fromId, string toId)
        {
            return graph.IsReachable(fromId, toId);
        }

        // Representacion textual del grafo
        public string GetGraphDescription()
        {
            List<string> lines = new List<string>();

            lines.Add("=== GRAFO DIRIGIDO ===");

            foreach (var vertex in graph.Vertices)
            {
                lines.Add(vertex.ToString());

                foreach (var edge in graph.Edges
                    .Where(e => e.FromId == vertex.Id))
                {
                    lines.Add("  -> " + edge.ToId);
                }
            }

            return string.Join("\n", lines);
        }
    }
}
