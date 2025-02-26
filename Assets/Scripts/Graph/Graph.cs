using System;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public List<Vertice> vertices;
    
    private Vertice _startVertice;
    private Vertice _endVertice;

    private Dictionary<Vertice, float> _minDistanceDictionary = new Dictionary<Vertice, float>();
    private Dictionary<Vertice, Vertice> _lastVerticeDictionary = new Dictionary<Vertice, Vertice>();
    
    public Stack<Vertice> GetPath(Vertice startVertice, Vertice endVertice)
    {
        _startVertice = startVertice;
        _endVertice = endVertice;
        
        DijkstrasAlgorithm();
        
        Stack<Vertice> VerticesOnPath = new Stack<Vertice>();
        VerticesOnPath.Push(_endVertice);
        Vertice currentVertice = _endVertice;
        
        while (currentVertice != _startVertice)
        {
            Vertice theLastVertice = _lastVerticeDictionary[currentVertice];
            VerticesOnPath.Push(theLastVertice);
            currentVertice = theLastVertice;
        }
        
        return VerticesOnPath;
    }

    // ALL NAMES ARE LONG JUST FOR EASIER TO UNDERSTAND
    private void DijkstrasAlgorithm()
    {
        List<Vertice> unvisitedVertices = new List<Vertice>();
        _minDistanceDictionary.Clear();
        _lastVerticeDictionary.Clear();
        
        foreach (var vertice in vertices)
        {
            unvisitedVertices.Add(vertice);
            _minDistanceDictionary.Add(vertice, float.MaxValue);
            _lastVerticeDictionary.Add(vertice, null);
        }

        _minDistanceDictionary[_startVertice] = 0;
        _lastVerticeDictionary[_startVertice] = _startVertice;
        
        while (unvisitedVertices.Count > 0)
        {
            Vertice verticeWithTheShortestDistance = unvisitedVertices[0];
            foreach (var vertice in unvisitedVertices)
            {
                float distanceForThisVertice = _minDistanceDictionary[vertice];
                float distanceForTheShortestDistanceVertice = _minDistanceDictionary[verticeWithTheShortestDistance];
                if (distanceForThisVertice < distanceForTheShortestDistanceVertice)
                {
                    verticeWithTheShortestDistance = vertice;
                }
            }
            //At this point, we will have the vertice (vertex) with the shortest distance in the dictionary
            //We will start "visit" it
            unvisitedVertices.Remove(verticeWithTheShortestDistance);
            
            float distanceSoFar = _minDistanceDictionary[verticeWithTheShortestDistance];

            List<Edge> edges = verticeWithTheShortestDistance.Edges;
            foreach (var edge in edges)
            {
                Vertice theOtherVertice = null;
                if (verticeWithTheShortestDistance == edge.PointA)
                {
                    theOtherVertice = edge.PointB;
                }
                else
                {
                    theOtherVertice = edge.PointA;
                }
                
                float distanceForOtherVertice = _minDistanceDictionary[theOtherVertice];
                float distanceForOtherVerticeFromTheCurrentCheckingVertice = distanceSoFar + edge.Distance;

                if (distanceForOtherVerticeFromTheCurrentCheckingVertice < distanceForOtherVertice)
                {
                    _minDistanceDictionary[theOtherVertice] = distanceForOtherVerticeFromTheCurrentCheckingVertice;
                    _lastVerticeDictionary[theOtherVertice] = verticeWithTheShortestDistance;
                }
            }
        }
    }
}
