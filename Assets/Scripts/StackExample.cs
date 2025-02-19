using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackExample : MonoBehaviour
{
    public Stack<int> StackExmaple1 = new Stack<int>();
    
    public Stack<GameObject> ObjectPoolExample = new Stack<GameObject>();
    public GameObject ExamplePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        StackExmaple1.Push(10);
        StackExmaple1.Push(20);
        StackExmaple1.Push(30);

        // return 30
        int data1 = StackExmaple1.Pop();
        // return 20
        int data2 = StackExmaple1.Pop();
        // We only have 10 left in the stack
        int justTakeALook = StackExmaple1.Peek();

        int remainingSize = StackExmaple1.Count;
    }

    private GameObject GetObjectFromThePool()
    {
        if (ObjectPoolExample.Count > 0)
        {
            return ObjectPoolExample.Pop();
        }
        return Instantiate(ExamplePrefab);
    }

    private void ReturnObjectToPool(GameObject obj)
    {
        ObjectPoolExample.Push(obj);
    }
}
