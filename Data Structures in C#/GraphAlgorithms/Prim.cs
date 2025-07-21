// Prim implementation in C#
using System;

public class Prim
{
    private const int INF = int.MaxValue;
    private int Vertices;

    public Prim(int vertices)
    {
        Vertices = vertices;
    }

    // Function to find the vertex with the minimum key value
    private int MinKey(int[] key, bool[] mstSet)
    {
        int min = INF, minIndex = -1;

        for (int v = 0; v < Vertices; v++)
        {
            if (!mstSet[v] && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    public void PrimMST(int[,] graph)
    {
        int[] parent = new int[Vertices]; // Store MST result
        int[] key = new int[Vertices];    // Minimum weights
        bool[] mstSet = new bool[Vertices]; // Included in MST?

        for (int i = 0; i < Vertices; i++)
        {
            key[i] = INF;
            mstSet[i] = false;
        }

        key[0] = 0;       // Start from the first vertex
        parent[0] = -1;   // First node is always root of MST

        for (int count = 0; count < Vertices - 1; count++)
        {
            int u = MinKey(key, mstSet);
            mstSet[u] = true;

            for (int v = 0; v < Vertices; v++)
            {
                if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }

        // Print MST
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < Vertices; i++)
        {
            Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}");
        }
    }

    public static void Main(string[] args)
    {
        int[,] graph = new int[,] {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7


