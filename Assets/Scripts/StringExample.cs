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

        int a = 10;
        int b = 20;
        // this is 10 (a), and this is 20 (b)
        Debug.Log("this is " + a + " (a), and this is " + b + " (b)");
        Debug.Log($"this is {a} (a), and this is {b} (b)");

        float pi = 3.141592f;
        Debug.Log(pi.ToString("F2"));

        DateTime now = DateTime.Now;
        Debug.Log(now);
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        Debug.Log($"{year}-{month}-{day}");
        Debug.Log(now.ToString("yyyy-M-d"));
        Debug.Log(now.ToString("yyyy-MMM-d"));
    }
}
