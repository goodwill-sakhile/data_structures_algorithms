// BFS implementation in C#
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

    public void AddEdge(int source, int destination)
    {
        adjacencyList[source].Add(destination);
        // If the graph is undirected, also add the reverse edge:
        // adjacencyList[destination].Add(source);
    }

    public void BFS(int startVertex)
    {
        bool[] visited = new bool[Vertices];
        Queue<int> queue = new Queue<int>();

        visited[startVertex] = true;
        queue.Enqueue(startVertex);

        while (queue.Count != 0)
        {
            int currentVertex = queue.Dequeue();
            Console.Write(currentVertex + " ");

            foreach (int neighbor in adjacencyList[currentVertex])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        Graph g = new Graph(6);
        g.AddEdge(0, 1);
        g.Ad


