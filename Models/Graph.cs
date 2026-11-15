
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusNet.Models
{
    public class Graph
    {
        public List<Vertex> Vertices { get; private set; }
        public List<Edge> Edges { get; private set; }

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        // Agregar vertice
        public void AddVertex(string id, string name)
        {
            if (Vertices.Any(v => v.Id == id))
                return;

            Vertices.Add(new Vertex(id, name));
        }

        // Agregar arista dirigida
        public void AddEdge(string fromId, string toId)
        {
            if (!Vertices.Any(v => v.Id == fromId) ||
                !Vertices.Any(v => v.Id == toId))
                return;

            if (!Edges.Any(e =>
                e.FromId == fromId && e.ToId == toId))
            {
                Edges.Add(new Edge(fromId, toId));
            }
        }

        // Eliminar vertice
        public void RemoveVertex(string id)
        {
            Vertices.RemoveAll(v => v.Id == id);

            Edges.RemoveAll(e =>
                e.FromId == id || e.ToId == id);
        }

        // Eliminar arista
        public void RemoveEdge(string fromId, string toId)
        {
            Edges.RemoveAll(e =>
                e.FromId == fromId && e.ToId == toId);
        }

        // Obtener vecinos
        public List<string> GetNeighbors(string id)
        {
            return Edges
                .Where(e => e.FromId == id)
                .Select(e => e.ToId)
                .ToList();
        }

        // BFS
        public List<string> BFS(string startId)
        {
            List<string> result = new List<string>();

            if (!Vertices.Any(v => v.Id == startId))
                return result;

            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(startId);
            visited.Add(startId);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);

                foreach (string neighbor in GetNeighbors(current))
                {
                    if (visited.Add(neighbor))
                        queue.Enqueue(neighbor);
                }
            }

            return result;
        }

        // DFS
        public List<string> DFS(string startId)
        {
            List<string> result = new List<string>();

            if (!Vertices.Any(v => v.Id == startId))
                return result;

            HashSet<string> visited = new HashSet<string>();

            DFSRecursive(startId, visited, result);

            return result;
        }

        private void DFSRecursive(
            string current,
            HashSet<string> visited,
            List<string> result)
        {
            visited.Add(current);
            result.Add(current);

            foreach (string neighbor in GetNeighbors(current))
            {
                if (!visited.Contains(neighbor))
                    DFSRecursive(neighbor, visited, result);
            }
        }

        // Detectar ciclos
        public bool HasCycle()
        {
            HashSet<string> visited = new HashSet<string>();
            HashSet<string> recursionStack = new HashSet<string>();

            foreach (var vertex in Vertices)
            {
                if (!visited.Contains(vertex.Id))
                {
                    if (HasCycleRecursive(
                        vertex.Id, visited, recursionStack))
                        return true;
                }
            }

            return false;
        }

        private bool HasCycleRecursive(
            string current,
            HashSet<string> visited,
            HashSet<string> recursionStack)
        {
            visited.Add(current);
            recursionStack.Add(current);

            foreach (string neighbor in GetNeighbors(current))
            {
                if (!visited.Contains(neighbor))
                {
                    if (HasCycleRecursive(
                        neighbor, visited, recursionStack))
                        return true;
                }
                else if (recursionStack.Contains(neighbor))
                {
                    return true;
                }
            }

            recursionStack.Remove(current);
            return false;
        }

        // Grado de entrada
        public int GetInDegree(string id)
        {
            return Edges.Count(e => e.ToId == id);
        }

        // Grado de salida
        public int GetOutDegree(string id)
        {
            return Edges.Count(e => e.FromId == id);
        }

        // Usuarios influyentes
        public List<Vertex> GetInfluentialVertices()
        {
            return Vertices
                .OrderByDescending(v => GetInDegree(v.Id))
                .ToList();
        }

        // Usuarios activos
        public List<Vertex> GetActiveVertices()
        {
            return Vertices
                .Where(v => GetOutDegree(v.Id) > 0)
                .ToList();
        }

        // Usuarios sin seguidores
        public List<Vertex> GetVerticesWithoutFollowers()
        {
            return Vertices
                .Where(v => GetInDegree(v.Id) == 0)
                .ToList();
        }

        // Alcanzabilidad
        public bool IsReachable(string fromId, string toId)
        {
            return BFS(fromId).Contains(toId);
        }
    }
}
