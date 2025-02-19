using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursionExample : MonoBehaviour
{
    private void Start()
    {
        int result1 = FactorialWithIteration(5);
        Debug.Log(result1);
        int result2 = FactorialWithRecursion(5);
        Debug.Log(result2);
    }

    public int FactorialWithIteration(int n)
    {
        if (n < 1)
        {
            return 1;
        }
        
        int value = 1;
        for (int i = 1; i <= n; i++)
        {
            value *= i;
        }
        return value;
    }

    public int FactorialWithRecursion(int n)
    {
        if (n <= 1)
        {
            return 1;
        }
        int result = n * FactorialWithRecursion(n - 1);
        return result;
    }
}
