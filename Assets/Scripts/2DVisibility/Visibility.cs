using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    [SerializeField] private List<Renderer> renderers;
    
    private Ray2D _ray2D;
    private List<Vector2> _points;
    
    // Start is called before the first frame update
    void Start()
    {
        _ray2D = new Ray2D();
        _points = new List<Vector2>();
        
        // This will break if there's rotation on renderers
        foreach (var spriteRenderer in renderers)
        {
            Vector2 centerPosition = spriteRenderer.bounds.center;
            Vector2 extents = spriteRenderer.bounds.extents;

            // 0.01f is the offset
            float x1 = centerPosition.x - extents.x - 0.01f;
            float y1 = centerPosition.y - extents.y - 0.01f;
            _points.Add(new Vector2(x1, y1));
            
            float x2 = centerPosition.x - extents.x - 0.01f;
            float y2 = centerPosition.y + extents.y + 0.01f;
            _points.Add(new Vector2(x2, y2));
            
            float x3 = centerPosition.x + extents.x + 0.01f;
            float y3 = centerPosition.y - extents.y - 0.01f;
            _points.Add(new Vector2(x3, y3));
            
            float x4 = centerPosition.x + extents.x + 0.01f;
            float y4 = centerPosition.y + extents.y + 0.01f;
            _points.Add(new Vector2(x4, y4));
        }
    }

    // Update is called once per frame
    void Update()
    {
        _ray2D.origin = this.transform.position;
        
        for (int i = 0; i < 36; i++)
        {
            int currentAngle = i * 10; // in degrees
            float currentAngleRad = currentAngle * Mathf.Deg2Rad;
            _ray2D.direction = new Vector2(Mathf.Cos(currentAngleRad), Mathf.Sin(currentAngleRad)).normalized;

            RaycastHit2D hit = Physics2D.Raycast(_ray2D.origin, _ray2D.direction);
            if (hit.collider == null)
            {
                Debug.DrawLine(_ray2D.origin, _ray2D.origin + _ray2D.direction * 100f, Color.green);
            }
            else
            {
                Debug.DrawLine(_ray2D.origin, hit.point, Color.green);
            }
        }

        foreach (var point in _points)
        {
            _ray2D.direction = new Vector2(point.x - _ray2D.origin.x, point.y - _ray2D.origin.y).normalized;
            RaycastHit2D hit = Physics2D.Raycast(_ray2D.origin, _ray2D.direction);
            
            if (hit.collider == null)
            {
                Debug.DrawLine(_ray2D.origin, _ray2D.origin + _ray2D.direction * 100f, Color.green);
            }
            else
            {
                Debug.DrawLine(_ray2D.origin, hit.point, Color.green);
            }
        }
    }
    
    public class Solution 
    {
        Dictionary<int, int> record = new Dictionary<int, int>();

        public int[] TwoSum(int[] nums, int target) {
        
            for (int i = 0; i < nums.Length; i++)
            {
                if (record.ContainsKey(nums[i]))
                {
                    return new int[] {record[nums[i]], i};
                }
                var result = target - nums[i];
                if (record.ContainsKey(result))
                    continue;
                record.Add(result, i);
            }

            return new int[2];
        }
    }
}
