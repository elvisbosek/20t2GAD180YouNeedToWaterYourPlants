using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    public static eventManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action onPressWater;
    public void watering()
    {
        if(onPressWater!=null)
        {
            onPressWater();
        }
    }
}
