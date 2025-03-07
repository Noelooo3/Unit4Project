using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurveTwoControlPoint : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform controlPoint1;
    [SerializeField] private Transform controlPoint2;
    
    [SerializeField] private int resolution;
    
    [SerializeField] private LineRenderer lineRenderer;

    private void Update()
    {
        lineRenderer.positionCount = resolution + 1;
        for (int i = 0; i <= resolution; i++)
        {
            float t = i / (float)resolution;
            Vector2 p1 = BezierPosition(startPoint.position, controlPoint1.position, controlPoint2.position, t);
            Vector2 p2 = BezierPosition(controlPoint1.position, controlPoint2.position, endPoint.position, t);
            Vector2 final = Vector2.Lerp(p1, p2, t);
            lineRenderer.SetPosition(i, final);
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
