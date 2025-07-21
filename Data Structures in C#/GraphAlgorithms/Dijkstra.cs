// Dijkstra implementation in C#
using System;
using System.Collections.Generic;

public class Graph
{
    private int Vertices;
    private List<(int destination, int weight)>[] adjacencyList;

    public Graph(int vertices)
    {
        Vertices = vertices;
        adjacencyList = new List<(int, int)>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            adjacencyList[i] = new List<(int, int)>();
        }
    }

    public void AddEdge(int source, int destination, int weight)
    {
        adjacencyList[source].Add((destination, weight));
        // For undirected graph, also add the reverse edge:
        // adjacencyList[destination].Add((source, weight));
    }

    public void Dijkstra(int startVertex)
    {
        int[] distance = new int[Vertices];
        for (int i = 0; i < Vertices; i++)
            distance[i] = int.MaxValue;

        distance[startVertex] = 0;

        var priorityQueue = new SortedSet<(int distance, int vertex)>();
        priorityQueue.Add((0, startVertex));

        while (priorityQueue.Count > 0)
        {
            var (currentDistance, currentVertex) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            foreach (var (neighbor, weight) in adjacencyList[currentVertex])
            {
                int newDist = currentDistance + weight;
                if (newDist < distance[neighbor])
                {
                    // Remove the old pair if it exists
                    priorityQueue.Remove((distance[neighbor], neighbor));
                    distance[neighbor] = newDist;
                    priorityQueue.Add((newDist, neighbor));
                }
            }
        }

        // Print results
        Console.WriteLine($"Shortest distances from vertex {startVertex}:");
        for (int i = 0; i < Vertices; i++)
        {
            Console.WriteLine($"To vertex {i} = {(distance[i] == int.MaxValue ? "∞" : distance[i].ToString())}");
        }
    }

    public static void Main(string[] args)
    {
        Graph g = new Graph(6);
        g.AddEdge(0, 1, 4);
        g.AddEdge(0, 2, 2);
        g.AddEdge(1, 2, 1);
        g.AddEdge(1, 3, 5);
        g.AddEdge(2, 3, 8);
        g.AddEdge(2, 4, 10);
        g.AddEdge(3, 4, 2);
        g.AddEdge(3, 5, 6);
        g.AddEdge(4, 5, 3);

        g.Dijkstra(0);
    }
}


