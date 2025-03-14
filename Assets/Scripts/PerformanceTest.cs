using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Count(100);
    }

    private void Count(int count)
    {
        if (count <= 0)
            return;
        
        int temp = 0;
        for (int i = 0; i < 1000000; i++)
        {
            temp += 2;
        }
        Debug.Log(temp);
        
        count--;
        Count(count);
    }
}
