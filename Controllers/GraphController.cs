
using System;
using System.Collections.Generic;
using CampusNet.Models;

namespace CampusNet.Controllers
{
    public class GraphController
    {
        private Graph graph;

        public GraphController()
        {
            graph = new Graph();
        }

        public void AddVertex(string id, string name)
        {
            graph.AddVertex(id, name);
        }

        public void AddEdge(string fromId, string toId)
        {
            graph.AddEdge(fromId, toId);
        }

        public void RemoveVertex(string id)
        {
            graph.RemoveVertex(id);
        }

        public void RemoveEdge(string fromId, string toId)
        {
            graph.RemoveEdge(fromId, toId);
        }

        public List<Vertex> GetVertices()
        {
            return graph.Vertices;
        }

        public void ShowGraph()
        {
            graph.ShowGraph();
        }
    }
}
