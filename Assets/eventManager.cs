using System;
using System.Collections;
using System.Collections.Generic;
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
    public event Action RoseWater;
    public void waterRose()
    {
        if(RoseWater!=null)
        {
            RoseWater();
        }
    }

    public event Action SunflowerWater;
    public void waterSunflower()
    {
        if(SunflowerWater!=null)
        {
            SunflowerWater();
        }    
    }

    public event Action MushroomWater;
    public void waterMushroom()
    {
        if(MushroomWater!=null)
        {
            MushroomWater();
        }
    }

    public event Action WhiteWater;
    public void waterWhite()
    {
        if(WhiteWater!=null)
        {
            WhiteWater();
        }
    }
}
