using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    void start()
    {
        
    }
    
    
    public delegate void wateringSunflower();
    public wateringSunflower myDelegate;
    //public static event wateringSunflower watered;

    /*public static void waterSunflower ()
    {
        eventManager.watered();
    }*/
   
}
