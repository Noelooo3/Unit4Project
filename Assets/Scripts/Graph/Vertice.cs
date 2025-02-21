using System.Collections.Generic;
using UnityEngine;

public class Vertice : MonoBehaviour
{
    public List<Edge> Edges = new List<Edge>();

    public void AddEdge(Edge edge)
    {
        Edges.Add(edge);
    }
}
