using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown("w"))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, 0, 1));
        }
        if (Input.GetKeyDown("a"))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(-1, 0, 0));
        }
        if (Input.GetKeyDown("s"))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, 0, -1));
        }
        if (Input.GetKeyDown("d"))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(1, 0, 0));
        }
    }
}
