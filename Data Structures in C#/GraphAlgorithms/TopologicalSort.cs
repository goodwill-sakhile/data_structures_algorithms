// TopologicalSort implementation in C#
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
    }

    private void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
    {
        visited[v] = true;

        foreach (int neighbor in adjacencyList[v])
        {
            if (!visited[neighbor])
                TopologicalSortUtil(neighbor, visited, stack);
        }

        stack.Push(v);
    }

    public void TopologicalSort()
    {
        bool[] visited = new bool[Vertices];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < Vertices; i++)
        {
            if (!visited[i])
                TopologicalSortUtil(i, visited, stack);
        }

        Console.WriteLine("Topological Sort Order:");
        while (stack.Count > 0)
            Console.Write(stack.Pop() + " ");
    }

    public static void Main(string[] args)
    {
        Graph g = new Graph(6);
        g.AddEdge(5, 2);
        g.AddEdge(5, 0);
        g.AddEdge(4, 0);
        g.AddEdge(4, 1);
        g.AddEdge(2, 3);
        g.AddEdge(3, 1);

        g.TopologicalSort();
    }
}

