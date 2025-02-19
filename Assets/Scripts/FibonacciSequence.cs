using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FibonacciSequence : MonoBehaviour
{
    private int _timeOfFibonacci;
    
    private Dictionary<int, int> _fibonacciDictionary = new Dictionary<int, int>();
    
    void Start()
    {
        _timeOfFibonacci = 0;
        Debug.Log(Fibonacci(15));
        Debug.Log(_timeOfFibonacci);
        
        _timeOfFibonacci = 0;
        Debug.Log(Fibonacci(15));
        Debug.Log(_timeOfFibonacci);
    }

    private int Fibonacci(int n)
    {
        _timeOfFibonacci++;
        if (_fibonacciDictionary.ContainsKey(n))
        {
            return _fibonacciDictionary[n];
        }
        if (n == 0)
        {
            return 0;
        }
        if (n == 1)
        {
            return 1;
        }
        int result = Fibonacci(n - 1) + Fibonacci(n - 2);
        _fibonacciDictionary.Add(n, result);
        return result;
    }
}
