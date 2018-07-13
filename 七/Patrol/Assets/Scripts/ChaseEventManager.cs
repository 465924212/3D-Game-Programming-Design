using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEventManager : MonoBehaviour {

    public List<PatrolController> Patrols;

    // Use this for initialization
    void Start () {
        Patrols = Director.getInstance().currentSceneController.getPatrols();
    }
	
	// Update is called once per frame
	void Update () {
		//if the character is in the controller's patrol square
        Vector3 player = Director.getInstance().currentSceneController.getPlayer().transform.position;
        foreach (var i in Patrols)
        {
            //send message
            if (player.x < i.square[2].x && player.x > i.square[0].x && player.z < i.square[2].z && player.z > i.square[0].z)
            {
                i.StartChase();
            }
            else if (!i.Patrol)
            {
                i.StopChase();
                Recorder.RaiseScore();
            }
        }
        
	}
}
