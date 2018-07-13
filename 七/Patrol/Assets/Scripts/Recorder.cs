using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour {

    public delegate void GetScoreAction();
    public static event GetScoreAction OnGetScoreAction;

    public static void RaiseScore()
    {
        //raise event
        if (OnGetScoreAction != null)
        {
            OnGetScoreAction();
        }
    }

    public int Record;

    public void getScore()
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
        Record = 0;
        OnGetScoreAction += getScore;
	}

    void OnGUI()
    {
        float width = Screen.width / 10;
        float height = Screen.height / 12;


        GUI.TextArea(new Rect(Screen.width - width, 0, width, height), "Record: " + Record);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
