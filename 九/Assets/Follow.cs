using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public float Height;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = GetComponent<Transform>().parent.position;
        this.transform.position = new Vector3(pos.x, pos.y + Height, pos.z);
        this.transform.LookAt(Camera.main.transform);
	}
}
