using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryExample : MonoBehaviour
{
    // Those will be on the heap memory
    public GameObject prefab;
    public Transform parent;
    public Camera fpsCamera;
    
    void Start()
    {
        int a = 10; // This will be on the stack memory
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
