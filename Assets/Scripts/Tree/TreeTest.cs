using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTest : MonoBehaviour
{
    void Start()
    {
        Tree tree = new Tree(0);
        tree.Insert(0, 1);
        tree.Insert(0, 2);
        
        // Warning, not target node
        tree.Insert(5, 100);
        // Warning, node with value 1 existed
        tree.Insert(0, 1);
        
        tree.Insert(1, 4);
        tree.Insert(1, 10);
        tree.Insert(1, 6);
        
        tree.Insert(4, 5);
        tree.Insert(4, 20);
        
        tree.Insert(2, 9);
        tree.Insert(2, 12);
        
        bool contains12 = tree.Contains(12);
        Debug.Log(contains12);
        bool contains13 = tree.Contains(13);
        Debug.Log(contains13);
        
        Debug.Log("Traverse");
        tree.Traverse(tree.Root);
    }
}
