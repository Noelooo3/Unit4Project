using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StringExample : MonoBehaviour
{
    private void Start()
    {
        string str = "Hello World!";
        char letterE = str[1];

        //Don't do this!
        string reverseStr = string.Empty;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reverseStr += str[i];
        }
        Debug.Log(reverseStr);
        
        //Do this! (But not always, don't do this for short text)
        StringBuilder reverseStrBuilder = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reverseStrBuilder.Append(str[i]);
        }
        Debug.Log(reverseStrBuilder.ToString());
    }
}
