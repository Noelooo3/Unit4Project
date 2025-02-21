using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public Vertice PointA;
    public Vertice PointB;
    
    public float Distance;

    private void Awake()
    {
        // Those are data, but we use those methods to help us to set it up
        Distance = Vector3.Distance(PointA.transform.position, PointB.transform.position);
        PointA.AddEdge(this);
        PointB.AddEdge(this);
    }

    private void OnDrawGizmos()
    {
        if (PointA == null)
            return;
        if (PointB == null)
            return;
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}
