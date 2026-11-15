
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

        public void AddVertex(string id, string name)
        {
            if (Vertices.Any(v => v.Id == id))
                return;

            Vertices.Add(new Vertex(id, name));
        }

        public void AddEdge(string fromId, string toId)
        {
            if (!Vertices.Any(v => v.Id == fromId) ||
                !Vertices.Any(v => v.Id == toId))
                return;

            if (!Edges.Any(e => e.FromId == fromId && e.ToId == toId))
                Edges.Add(new Edge(fromId, toId));
        }

        public void RemoveVertex(string id)
        {
            Vertices.RemoveAll(v => v.Id == id);
            Edges.RemoveAll(e => e.FromId == id || e.ToId == id);
        }

        public void RemoveEdge(string fromId, string toId)
        {
            Edges.RemoveAll(e =>
                e.FromId == fromId && e.ToId == toId);
        }

        public void ShowGraph()
        {
            Console.WriteLine("=== GRAFO DIRIGIDO ===");

            foreach (var vertex in Vertices)
            {
                Console.WriteLine(vertex);

                foreach (var edge in Edges.Where(e => e.FromId == vertex.Id))
                    Console.WriteLine("  -> " + edge.ToId);
            }
        }
    }
}
