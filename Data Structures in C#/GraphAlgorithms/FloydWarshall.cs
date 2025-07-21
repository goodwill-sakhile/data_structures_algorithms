// FloydWarshall implementation in C#
using System;

public class FloydWarshall
{
    private const int INF = int.MaxValue / 2; // To prevent overflow

    public static void FloydWarshallAlgorithm(int[,] graph, int vertices)
    {
        int[,] dist = new int[vertices, vertices];

        // Initialize distance matrix
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                dist[i, j] = graph[i, j];
            }
        }

        // Main Floyd-Warshall algorithm
        for (int k = 0; k < vertices; k++)
        {
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        // Print the shortest distance matrix
        Console.WriteLine("Shortest distances between every pair of vertices:");
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                if (dist[i, j] == INF)

