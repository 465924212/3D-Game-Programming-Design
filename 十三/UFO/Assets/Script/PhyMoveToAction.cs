using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhyMoveToAction : SSAction
{

    // Use this for initialization
    public override void Start () { }

    // Update is called once per frame
    public override void Update () {
        if (this.transform.position.y < -7 || this.transform.position.x > 12)
        {
            this.destroy = true;
            this.callback.SSActionEvent(this);
        }
    }

    public static PhyMoveToAction GetSSAction(float speed, float g)
    {
        PhyMoveToAction action = ScriptableObject.CreateInstance<PhyMoveToAction>();
        return action;
    }
}
