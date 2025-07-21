// DetectCycle implementation in C#
using System;
using System.Collections.Generic;

public class Graph
{
    private int Vertices;
    private List<int>[] adjacencyList;

    public Graph(int v)
    {
        Vertices = v;
        adjacencyList = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        adjacencyList[u].Add(v);
        adjacencyList[v].Add(u); // Undirected graph
    }

    private bool DFS(int current, bool[] visited, int parent)
    {
        visited[current] = true;

        foreach (int neighbor in adjacencyList[current])
        {
            if (!visited[neighbor])
            {
                if (DFS(neighbor, visited, current))
                    return true;
            }
            else if (neighbor != parent)
            {
                // If visited and not parent, then there's a cycle
                return true;
            }
        }

        return false;
    }

    public bool DetectCycle()
    {
        bool[] visited = new bool[Vertices];

        for (int i = 0; i < Vertices; i++)
        {
            if (!visited[i])
            {
                if (DFS(i, visited, -1))
                    return true;
            }
        }

        return false;
    }

    public static void Main(string[] args)
    {
        Graph g1 = new Graph(5);
        g1.AddEdge(0, 1);
        g1.AddEdge(1, 2);
        g1.AddEdge(2, 3);
        g1.AddEdge(3, 4);
        // Uncomment to introduce a cycle:
        // g1.AddEdge(4, 1);

        Console.WriteLine("Graph contains cycle: " + g1.DetectCycle());
    }
}


