// ConnectedComponents implementation in C#
using System;
using System.Collections.Generic;

class Graph
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

    private void DFS(int v, bool[] visited, List<int> component)
    {
        visited[v] = true;
        component.Add(v);

        foreach (int neighbor in adjacencyList[v])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, visited, component);
            }
        }
    }

    public void FindConnectedComponents()
    {
        bool[] visited = new bool[Vertices];
        int componentNumber = 1;

        for (int v = 0; v < Vertices; v++)
        {
            if (!visited[v])
            {
                List<int> component = new List<int>();
                DFS(v, visited, component);

                Console.WriteLine($"Component {componentNumber}: {string.Join(", ", component)}");
                componentNumber++;
            }
        }
    }

    static void Main(string[] args)
    {
        Graph g = new Graph(7);
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(3, 4);
        g.AddEdge(5, 6);

        Console.WriteLine("Connected Components:");
        g.FindConnectedComponents();
    }
}


