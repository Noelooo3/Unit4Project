using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalTree : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 startRotation;

    [SerializeField] private float ratio;
    [SerializeField] private float minimumScale;

    [SerializeField] private GameObject leafPrefab;
    
    private TreePart _tree;
    private List<TreePart> _leaves = new List<TreePart>();
    
    void Start()
    {
        _tree = GenerateTree(startPosition, startRotation, 1f);
        GetLeaves(_tree);
        foreach (var leaf in _leaves)
        {
            GameObject treePart = leaf.Part;
            Vector3 leafPosition = treePart.transform.position + treePart.transform.up * treePart.transform.localScale.x;
            GameObject newLeaf = Instantiate(leafPrefab, leafPosition, Quaternion.identity);
            newLeaf.transform.localScale = treePart.transform.localScale;
        }
    }

    private void GetLeaves(TreePart part)
    {
        if (part.Left == null && part.Right == null)
        {
            _leaves.Add(part);
            return;
        }

        if (part.Left != null)
        {
            GetLeaves(part.Left);
        }

        if (part.Right != null)
        {
            GetLeaves(part.Right);
        }
    }
    
    private TreePart GenerateTree(Vector3 startPos, Vector3 startRot, float scale)
    {
        if (scale < minimumScale)
            return null;

        GameObject treePart = Instantiate(treePrefab, startPos, Quaternion.identity);
        treePart.transform.Rotate(startRot);
        treePart.transform.localScale = new Vector3(scale, scale, scale);

        // 1 is the height for our prefab
        Vector3 partEndPosition = startPos + treePart.transform.up * 1 * scale;
        float nextTreePartScale = scale * ratio;
        Vector3 currentRotation = treePart.transform.eulerAngles;
        
        float offSetLeftX = Random.Range(0f, 50f);
        float offSetLeftY = Random.Range(0f, 50f);
        float offSetLeftZ = Random.Range(0f, 50f);
        Vector3 offSetLeft = new Vector3(offSetLeftX, offSetLeftY, offSetLeftZ);
        
        float offSetRightX = Random.Range(0f, 50f);
        float offSetRightY = Random.Range(0f, 50f);
        float offSetRightZ = Random.Range(0f, 50f);
        Vector3 offSetRight = new Vector3(offSetRightX, offSetRightY, offSetRightZ);
        
        TreePart left = GenerateTree(partEndPosition, currentRotation + offSetLeft, nextTreePartScale);
        TreePart right = GenerateTree(partEndPosition, currentRotation - offSetRight, nextTreePartScale);

        TreePart currentTreePart = new TreePart(treePart, left, right);
        return currentTreePart;
    }
}
