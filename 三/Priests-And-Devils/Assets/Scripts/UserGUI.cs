using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

    private IUserAction action;

	// Use this for initialization
	void Start () {
        action = Director.getInstance().currentSceneController as IUserAction;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        float width = Screen.width / 2;
        float height = Screen.height / 2;

        if (GUI.Button(new Rect(width + 130, height + 40, 100, 30 ), "GetOn")) 
        {
            action.GetOnBoatP();
        }

        if (GUI.Button(new Rect(width + 270, height + 40, 100, 30), "GetOn"))
        {
            action.GetOnBoatD();
        }
    }
}
