using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWatering : MonoBehaviour
{
    public int duration = 20;
    public int timeRemaining;
    public bool isCountingDown = false;
    public playerMovement inRange;
    Renderer wilt;
    public Mesh[] meshes;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
    }
    
    private void _tick()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", 1f);
        }
        else
        {
            isCountingDown = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(timeRemaining <=10)
        {
            GetComponent<MeshFilter>().mesh = meshes[1];
        }
       if(timeRemaining == 0)
        {
            GetComponent<MeshFilter>().mesh = meshes[2];
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<playerMovement>())
        {
            if(collision.gameObject.GetComponent<playerMovement>().canFull == true)
            {
                timeRemaining = timeRemaining + 10;
            }
        }
    }

    private void OnTriggerEnter(Collider otherobject)
    {
        if(otherobject.gameObject.GetComponent<playerMovement>())
        {
            inRange = otherobject.gameObject.GetComponent<playerMovement>();
        }
    }
    private void OnTriggerExit(Collider otherobject)
    {
        if(otherobject.gameObject.GetComponent<playerMovement>())
        {
            inRange = null;
        }
    }
}
