// Kruskal implementation in C#
using System;
using System.Collections.Generic;

public class Edge : IComparable<Edge>
{
    public int Source, Destination, Weight;

    public Edge(int source, int destination, int weight)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }

    public int CompareTo(Edge other)
    {
        return this.Weight.CompareTo(other.Weight);
    }
}

public class Subset
{
    public int Parent;
    public int Rank;
}

public class Kruskal
{
    private int Vertices;
    private List<Edge> Edges;

    public Kruskal(int vertices)
    {
        Vertices = vertices;
        Edges = new List<Edge>();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        Edges.Add(new Edge(source, destination, weight));
    }

    // Find set of an element with path compression
    private int Find(Subset[] subsets, int i)
    {
        if (subsets[i].Parent != i)
            subsets[i].Parent = Find(subsets, subsets[i].Parent);

        return subse

