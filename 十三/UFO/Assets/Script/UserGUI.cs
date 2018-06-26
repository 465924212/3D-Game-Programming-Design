using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserGUI : NetworkBehaviour {

    private IUserAction action;
    [SyncVar]
    public string mode = "";

    // Use this for initialization
    void Start () {
        action = SSDirector.getInstance().currentSceneController as IUserAction;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {
        float width = Screen.width / 10;
        float height = Screen.height / 12;
        
        if (GUI.Button(new Rect(Screen.width - width, 0, width, height), "Start"))
        {
            action.GameStart();
        }
        if (action.GetMode())
        {
            if (GUI.Button(new Rect(Screen.width - width, height, width, height), "ChangeMode"))
            {
                action.UseKin();
            }
            mode = "Physis";
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width - width, height, width, height), "ChangeMode"))
            {
                action.UsePhy();
            }
            mode = "Kinematic";
        }

        GUI.TextArea(new Rect(Screen.width - width, height * 2, width, height), "Mode: " + mode);
    }

    void Restart(int WindowID)
    {
        
    }
}
