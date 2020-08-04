using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWatering : MonoBehaviour
{
    public int duration;
    float wiltTimer;
    public int timeRemaining;
    public bool isCountingDown = false;
    public playerMovement inRange;
    Renderer wilt;
    public Mesh[] meshes;
    GameObject myObject;
    
    // Start is called before the first frame update
    void Start()
    {
        wiltTimer = duration / 2;
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
        myObject = GameObject.Find("Player");
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
        if(timeRemaining <= wiltTimer)
        {
            GetComponent<MeshFilter>().mesh = meshes[1];
        }
       if(timeRemaining == 0)
        {
            GetComponent<MeshFilter>().mesh = meshes[2];
        }
        

    }

    private void FixedUpdate()
    {
        if (!inRange == false && Input.GetKey("e") && myObject.GetComponent<playerMovement>().canFull == true)
        {
            timeRemaining += 10;
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
