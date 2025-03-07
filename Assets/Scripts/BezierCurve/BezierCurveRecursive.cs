using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurveRecursive : MonoBehaviour
{
    // points[0] = start point, point[^1] = point[point.Count - 1] = end point
    [SerializeField] private List<Transform> points = new List<Transform>();
    
    [SerializeField] private int resolution;
    [SerializeField] private LineRenderer lineRenderer;

    private void Update()
    {
        lineRenderer.positionCount = resolution + 1;
        for (int i = 0; i <= resolution; i++)
        {
            float t = i / (float)resolution;
            List<Vector2> pointList = new List<Vector2>();
            foreach (Transform pointTransform in points)
            {
                pointList.Add(pointTransform.position);
            }
            Vector2 final = BezierRecursive(pointList, t);
            lineRenderer.SetPosition(i, final);
        }
    }

    private Vector2 BezierRecursive(List<Vector2> pointList, float t)
    {
        if (pointList.Count == 0)
        {
            Debug.LogError("No point in the list!");
            return Vector2.zero;
        }
        if (pointList.Count == 1)
        {
            return pointList[0];
        }
        if (pointList.Count == 2)
        {
            Vector2 final = Vector2.Lerp(pointList[0], pointList[1], t);
            return final;
        }
        
        List<Vector2> newPoints = new List<Vector2>();
        for (int i = 0; i < pointList.Count - 2; i++)
        {
            Vector2 beginPoint = pointList[i];
            Vector2 controlPoint = pointList[i + 1];
            Vector2 endPoint = pointList[i + 2];
            Vector2 newPoint = BezierPosition(beginPoint, controlPoint, endPoint, t);
            newPoints.Add(newPoint);
        }
        
        return BezierRecursive(newPoints, t);
    }
    
    private Vector2 BezierPosition(Vector2 beginPoint, Vector2 controlPoint, Vector2 destinationPoint, float t)
    {
        Vector2 pointAPosition = Vector2.Lerp(beginPoint, controlPoint, t);
        Vector2 pointBPosition = Vector2.Lerp(controlPoint, destinationPoint, t);
        Vector2 pointCPosition = Vector2.Lerp(pointAPosition, pointBPosition, t);
        return pointCPosition;
    }
}
