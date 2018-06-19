using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    GameObject gameObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    float DeltaTime;
    void FixedUpdate()
    {
        DeltaTime += Time.fixedDeltaTime;
        if (DeltaTime < 20)
        {
        }
    }
}
