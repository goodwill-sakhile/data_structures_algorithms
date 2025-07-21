// BellmanFord implementation in C#
using System;
using System.Collections.Generic;

class Edge
{
    public int Source, Destination, Weight;
    public Edge(int source, int destination, int weight)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }
}

class Graph
{
    public int Vertices;
    public List<Edge> Edges;

    public Graph(int vertices)
    {
        Vertices = vertices;
        Edges = new List<Edge>();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        Edges.Add(new Edge(source, destination, weight));
    }

    public void BellmanFord(int startVertex)
    {
        int[] distance = new int[Vertices];
        for (int i = 0; i < Vertices; i++)
            distance[i] = int.MaxValue;

        distance[startVertex] = 0;

        // Relax all edges |V| - 1 times
        for (int i = 1; i <= Vertices - 1; i++)
        {
            foreach (Edge edge in Edges)
            {
                int u = edge.Source;
                int v = edge.Destination;
                int weight = edge.Weight;

                if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
                    distance[v] = distance[u] + weight;
            }
        }

        // Check for negative-weight cycles
        foreach (Edge edge in Edges)
        {
            int u = edge.Source;
            int v = edge.Destination;
            int weight = edge.Weight;

            if (distance[u] != int.MaxValue && distance[u] + weight < distance[v])
            {
                Console.WriteLine("Graph contains a negative weight cycle");
                return;
            }
        }

        // Print distances
        Console.WriteLine("Vertex Distance from Source:");
        for (int i = 0; i < Vertices; i++)
        {
            Console.WriteLine($"Vertex {i} \t Distance: {(distance[i] == int.MaxValue ? "∞" : distance[i].ToString())}");
        }
    }

    static void Main(string[] args)
    {
        Graph g = new Graph(5);
        g.AddEdge(0, 1, -1);
        g.AddEdge(0, 2, 4);
        g.AddEdge(1, 2, 3);
        g.AddEdge(1, 3, 2);
        g.AddEdge(1, 4, 2);
        g.AddEdge(3, 2, 5);
        g.AddEdge(3, 1, 1);
        g.AddEdge(4, 3, -3);

        Console.WriteLine("Running Bellman-Ford from vertex 0:");
        g.BellmanFord(0);
    }
}


