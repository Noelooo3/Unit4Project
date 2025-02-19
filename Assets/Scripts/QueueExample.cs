using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueExample : MonoBehaviour
{
    public Queue<int> MyQueue = new Queue<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        MyQueue.Enqueue(10);
        MyQueue.Enqueue(20);
        MyQueue.Enqueue(30);
        
        //Return 10
        int data1 = MyQueue.Dequeue();
        //Return 20
        int data2 = MyQueue.Dequeue();
        //We only have 30 left in the queue
        int justTakeALook = MyQueue.Peek();
        
        int remainingSize = MyQueue.Count;
    }
    
    public Queue<string> CommandQueue = new Queue<string>();
    
    private void AddNewCommand()
    {
        CommandQueue.Enqueue("Hello");
    }

    private string GetNextCommand()
    {
        if (CommandQueue.Count > 0)
        {
            return CommandQueue.Dequeue();
        }
        return null;
    }
}
