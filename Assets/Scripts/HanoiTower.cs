using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    private Stack<int> pole1 = new Stack<int>();
    private Stack<int> pole2 = new Stack<int>();
    private Stack<int> pole3 = new Stack<int>();
    
    private void Start()
    {
        pole1.Push(2000);
        pole1.Push(500);
        pole1.Push(100);
        pole1.Push(20);
        
        Move(4, 1, 3);
        
        Debug.Log(pole3.Pop());
        Debug.Log(pole3.Pop());
        Debug.Log(pole3.Pop());
        Debug.Log(pole3.Pop());
    }

    private void Move(int numberOfDisk, int startingPole, int endingPole)
    {
        if (numberOfDisk == 1)
        {
            Helper(startingPole, endingPole);
            return;
        }
        int otherPole = 6 - startingPole - endingPole;
        Move(numberOfDisk - 1, startingPole, otherPole);
        Helper(startingPole, endingPole);
        Move(numberOfDisk -1, otherPole, endingPole);
    }

    private void Helper(int startingPole, int endingPole)
    {
        int id = -1;
        switch (startingPole)
        {
            case 1:
                id = pole1.Pop();
                break;
            case 2:
                id = pole2.Pop();
                break;
            case 3:
                id = pole3.Pop();
                break;
        }
        switch (endingPole)
        {
            case 1:
                pole1.Push(id);
                break;
            case 2:
                pole2.Push(id);
                break;
            case 3:
                pole3.Push(id);
                break;
        }
        Debug.Log(id + " from: " + startingPole + " to " + endingPole);
    }
}
