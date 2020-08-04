using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Diagnostics;
//using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public float movementSpeed;
	public bool wellZone = false;
	public bool canFull = false;
	public PlantWatering currentPlant;
	//public object myObject;

	// Use this for initialization
	void Start() 
	{

	}
	void Update()
    {
		if (wellZone == true && !canFull == true)
		{
			if (Input.GetKey("e"))
			{
				canFull = true;
			}
		}
		if(currentPlant != null && canFull == true)
        {
            //water plant
            if (Input.GetKey("e"))
            {
				canFull = false;
			}
			
        } 
	}

	
	//Update is called once per frame
	void FixedUpdate() {

		/*if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w")) {
			transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
		} else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift)) {
			transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
		} else if (Input.GetKey("s")) {
			transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
		}*/

		if (Input.GetKey("a") && !Input.GetKey("d")) {
			transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
		} else if (Input.GetKey("d") && !Input.GetKey("a")) {
			transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
		}
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a") && !Input.GetKey("d"))
        {
			transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed * 2.5f;
        }
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d") && !Input.GetKey("a"))
        {
			transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * movementSpeed * 2.5f;
		}
		if (Input.GetKey(KeyCode.Space))
        {
			transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * movementSpeed * 2.5f;
        } 
	}

	public void OnTriggerEnter(Collider otherObject)
    {
		if(otherObject.gameObject.name == "Well")
        {
			wellZone = true;
        }
		if(otherObject.gameObject.GetComponent<PlantWatering>())
        {
			currentPlant = otherObject.gameObject.GetComponent<PlantWatering>();

		}
    }
	public void OnTriggerExit(Collider otherObject)
    {
		if(otherObject.gameObject.name == "Well")
        {
			wellZone = false;
        }
		if (otherObject.gameObject.GetComponent<PlantWatering>())
		{
			currentPlant = null;
		}
	}
}
