using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public float movementSpeed;

	// Use this for initialization
	void Start() {

	}

	//Update is called once per frame
	void FixedUpdate() {

		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w")) {
			transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
		} else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift)) {
			transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
		} else if (Input.GetKey("s")) {
			transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
		}

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
}
