using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform controlPoint;
    
    [SerializeField] private int resolution;
    
    [SerializeField] private LineRenderer lineRenderer;

    private void Update()
    {
        lineRenderer.positionCount = resolution + 1;
        for (int i = 0; i <= resolution; i++)
        {
            float t = i / (float) resolution;
            Vector2 position = BezierPosition(startPoint.position, controlPoint.position, endPoint.position, t);
            lineRenderer.SetPosition(i, position);
        }
    }

    private Vector2 BezierPosition(Vector2 beginPoint, Vector2 controlPoint, Vector2 destinationPoint, float t)
    {
        Vector2 pointAPosition = Vector2.Lerp(beginPoint, controlPoint, t);
        Vector2 pointBPosition = Vector2.Lerp(controlPoint, destinationPoint, t);
        Vector2 pointCPosition = Vector2.Lerp(pointAPosition, pointBPosition, t);
        return pointCPosition;
    }
}
