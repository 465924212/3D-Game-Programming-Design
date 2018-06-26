using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour {

    public int Record { get; set; }

    public void getRecord(GameObject gameObject)
    {
        Record = Record + 1;
    }

    protected static Recorder instance;
    public static Recorder Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (Recorder)FindObjectOfType(typeof(Recorder));
            }
            return instance;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
