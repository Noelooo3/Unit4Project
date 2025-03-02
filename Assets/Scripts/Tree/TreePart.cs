using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePart
{
    public GameObject Part;
    public TreePart Left;
    public TreePart Right;

    public TreePart(GameObject part, TreePart left, TreePart right)
    {
        Part = part;
        Left = left;
        Right = right;
    }
}
