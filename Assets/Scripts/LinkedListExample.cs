using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListExample : MonoBehaviour
{
    public LinkedList<int> linkedList;

    private int _example;
    
    // Start is called before the first frame update
    void Start()
    {
        linkedList = new LinkedList<int>();
        linkedList.AddFirst(5);
        linkedList.AddFirst(8);
        linkedList.AddFirst(10);
        linkedList.AddLast(5);
        var secondNode = linkedList.First.Next;
        linkedList.AddAfter(secondNode, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
