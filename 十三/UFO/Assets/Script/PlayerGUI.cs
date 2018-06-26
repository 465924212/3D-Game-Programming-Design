using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerGUI : NetworkBehaviour
{

    private IUserAction action;

    // Use this for initialization
    void Start()
    {
        action = SSDirector.getInstance().currentSceneController as IUserAction;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
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

        if (action.GetStatus())
        {
            GUI.Window(0, new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 70), Restart, "Game Result\n" + "Your Record is " + action.GetRecord().ToString());
        }
        GUI.TextArea(new Rect(Screen.width - width, height * 3, width, height), "Record: " + action.GetRecord().ToString());
    }

    void Restart(int WindowID)
    {

    }
}
