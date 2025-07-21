// DFS implementation in C#
using System;
using System.Collections.Generic;

public class Graph
{
    private int Vertices;
    private List<int>[] adjacencyList;

    public Graph(int vertices)
    {
        Vertices = vertices;
        adjacencyList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    public void AddEdge(int source, int destination)
    {
        adjacencyList[source].Add(destination);
        // For undirected graph, also add the reverse edge:
        // adjacencyList[destination].Add(source);
    }

    public void DFS(int startVertex)
    {
        bool[] visited = new bool[Vertices];
        Console.WriteLine("Depth-First Search starting from vertex " + startVertex + ":");
        DFSUtil(startVertex, visited);
    }

    private void DFSUtil(int vertex, bool[] visited)
    {
        visited[vertex] = true;
        Console.Write(vertex + " ");

        foreach (int neighbor in adjacencyList[vertex])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited);
            }
        }
    }

    public static void Main(string[] args)
    {
        Graph g = new Graph(6);
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 3);
        g.AddEdge(2, 4);
        g.AddEdge(4, 5);

        g.DFS(0);
    }
}


