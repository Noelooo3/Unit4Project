using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    public int[] ExampleArray;

    // Sorting algorithm
    // Time: O (n^2)
    public void SortArray()
    {
        int time = 0;
        
        for (int i = 0; i < ExampleArray.Length; i++)
        {
            bool swapped = false;
            
            for (int j = 0; j < ExampleArray.Length - i - 1; j++)
            {
                int temp1 = ExampleArray[j];
                int temp2 = ExampleArray[j + 1];
                
                time++;
                Debug.Log(time + " " + temp1 + " " + temp2);
                
                if (temp1 > temp2)
                {
                    ExampleArray[j] = temp2;
                    ExampleArray[j + 1] = temp1;
                    swapped = true;
                }
            }
            
            if (swapped == false)
                break;
        }
    }

    private void Start()
    {
        SortArray();
    }
}
