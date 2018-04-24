using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

    private IUserAction action;

	// Use this for initialization
	void Start () {
        action = SSDirector.getInstance().currentSceneController as IUserAction;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray,out hitInfo))
            {
                GameObject gameObject = hitInfo.collider.gameObject;
                action.hit(gameObject);
            }
        }
	}

    void OnGUI()
    {
        float width = Screen.width / 10;
        float height = Screen.height / 12;
        if (GUI.Button(new Rect(0, 0, width, height), "Start"))
        {
            action.GameStart();
        }
        string mode = "";
        if (action.GetMode())
        {
            if (GUI.Button(new Rect(0, height, width, height), "ChangeMode"))
            {
                action.UseKin();
            }
            mode = "Physis";
        }
        else
        {
            if (GUI.Button(new Rect(0, height, width, height), "ChangeMode"))
            {
                action.UsePhy();
            }
            mode = "Kinematic";
        }
        GUI.TextArea(new Rect(0, height * 2, width, height), "Mode: " + mode);
        if (action.GetStatus())
        {
            GUI.Window(0, new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 70), Restart, "Game Result\n" + "Your Record is " + action.GetRecord().ToString());
        }
        GUI.TextArea(new Rect(0, height * 3, width, height), "Record: " + action.GetRecord().ToString());
    }

    void Restart(int WindowID)
    {
        
    }
}
