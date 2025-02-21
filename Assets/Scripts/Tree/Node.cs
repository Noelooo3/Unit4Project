using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int Key;
    public List<Node> Children;

    public Node (int key)
    {
        Key = key;
        Children = new List<Node>();
    }
}
