using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSortExample : MonoBehaviour
{
    public int[] exampleArray = new[] { 9, 7, 4, 5, 6 };

    private void Start()
    {
        QuickSort(exampleArray, 0, exampleArray.Length - 1);
    }
    
    private void QuickSort(int[] array, int left, int right)
    {
        if (left >= right)
            return;
        int newIndexForPivot = Partition(array, left, right);
        QuickSort(array, left, newIndexForPivot - 1);
        QuickSort(array, newIndexForPivot + 1, right);
    }

    private int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int availableSpot = left;

        for (int checkPoint = left; checkPoint < right; checkPoint++)
        {
            if (array[checkPoint] > pivot)
                continue;
            // int temp = array[availableSpot];
            // array[availableSpot] = array[checkPoint];
            // array[checkPoint] = temp;
            (array[availableSpot], array[checkPoint]) = (array[checkPoint], array[availableSpot]);
            availableSpot++;
        }
        
        // array[right] is the pivot
        (array[availableSpot], array[right]) = (array[right], array[availableSpot]);
        // New position for the pivot after this partition.
        return availableSpot;
    }
}
