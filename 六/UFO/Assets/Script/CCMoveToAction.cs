using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMoveToAction : SSAction {
    
    public float speed;
    public float g;
    public float speedd;

    public static CCMoveToAction GetSSAction (float speed, float g)
    {
        CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction>();
        action.speed = speed;
        action.g = g;
        action.speedd = 0;
        return action;
    }

    // Use this for initialization
	public override void Start () { }
	
	// Update is called once per frame
	public override void Update ()
    {
        this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y - speedd * Time.deltaTime);
        speedd += g;
        if (this.transform.position .y < -7 || this.transform.position.x > 12)
        {
            this.destroy = true;
            this.callback.SSActionEvent(this);
        }
	}
}
