using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This should be Vertex, my bad!
public class Vertice : MonoBehaviour
{
    public List<Edge> Edges = new List<Edge>();
    public Action<Vertice> OnClickListener;
    
    public void AddEdge(Edge edge)
    {
        Edges.Add(edge);
    }

    private void OnMouseDown()
    {
        OnClickListener?.Invoke(this);
    }
}
