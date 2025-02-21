using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public List<Vertice> vertices;
    
    public Vertice StartVertice;

    private Dictionary<Vertice, float> _minDistanceDictionary = new Dictionary<Vertice, float>();
    private Dictionary<Vertice, Vertice> _lastVerticeDictionary = new Dictionary<Vertice, Vertice>();

    private void DijkstrasAlgorithm(Vertice startVertice)
    {
        List<Vertice> unvisitedVertices = new List<Vertice>();
        
        foreach (var vertice in vertices)
        {
            unvisitedVertices.Add(vertice);
            _minDistanceDictionary.Add(vertice, float.MaxValue);
            _lastVerticeDictionary.Add(vertice, null);
        }

        _minDistanceDictionary[StartVertice] = 0;
        _lastVerticeDictionary[StartVertice] = StartVertice;
        
        while (unvisitedVertices.Count > 0)
        {
            
        }
    }
}
