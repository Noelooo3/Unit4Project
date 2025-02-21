using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    public Node Root;

    public Tree (int value)
    {
        Root = new Node(value);
    }
    
    public void Insert(int key, int value)
    {
        Node targetNode = FindNode(Root, key);
        if (targetNode == null)
        {
            Debug.LogWarning("No target node found");
            return;
        }
        Node newNode = FindNode(Root, value);
        if (newNode != null)
        {
            Debug.LogWarning("Node with this value already exists");
            return;
        }
        targetNode.Children.Add(new Node(value));
        Debug.Log("Successfully inserted node: " + value);
    }

    public bool Contains(int key)
    {
        Node targetNode = FindNode(Root, key);
        if (targetNode == null)
            return false;
        return true;
    }

    public void Traverse(Node node)
    {
        Debug.Log(node.Key);
        foreach (var child in node.Children)
        {
            Traverse(child);
        }
    }
    
    private Node FindNode(Node node, int key)
    {
        if (node.Key == key)
            return node;
        foreach (var child in node.Children)
        {
            Node result = FindNode(child, key);
            if (result != null)
                return result;
        }
        return null;
    }
}
