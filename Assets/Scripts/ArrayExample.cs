using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrayExample : MonoBehaviour
{
    public int[] exampleArray;
    public int[,] twoDimensionalArray;
    public int [,,] threeDimensionalArray;

    private void Start()
    {
        exampleArray = new int[5]; // 5 is to tell the size of this array 
        exampleArray[0] = 1;
        exampleArray[1] = 2;
        exampleArray[2] = 30;
        exampleArray[3] = 40;
        exampleArray[4] = 99;
        
        int getIndexTwoFromArray = exampleArray[2];

        exampleArray[2] = 45;
        int[] anotherArray = new int[] { 60, 29 };
        exampleArray.AddRange(anotherArray);

        twoDimensionalArray = new int[2, 4];
        twoDimensionalArray[0, 0] = 5;
        twoDimensionalArray[0, 1] = 6;
        twoDimensionalArray[0, 2] = 7;
        twoDimensionalArray[1, 1] = 8;

        threeDimensionalArray = new int[2, 2, 2];
    }

    private void LinearTimeAlgorithm()
    {
        for (int i = 0; i < exampleArray.Length; i++)
        {
            Debug.Log(exampleArray[i]);
        }
    }

    private void QuadraticAlgorithm()
    {
        // n = exampleArray.Length
        // we will perform "Debug.Log("Get called")" n x n times.
        
        for (int i = 0; i < exampleArray.Length; i++)
        {
            for (int j = 0; j < exampleArray.Length; j++)
            {
                Debug.Log("Get called");
            }
        }
    }

    private void ExponentialAlgorithm()
    {
        // n = exampleArray.Lengtg
        // we will perform "Debug.Log("Get called")"
        // 2 x 2 x 2... for n time
    }

    private void ExampleForTimeComplexity()
    {
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        
        list.Add(10); // O(1) -> O(n) in the case of run out pre allocated space

        int[] array = new[] { 1, 3, 5 };
        array.AddRange(new [] {10}); // O(n)

        bool listHasNumberThree = list.Contains(3); // O(n)

        list.RemoveAt(0); // O(n)
    }
}
