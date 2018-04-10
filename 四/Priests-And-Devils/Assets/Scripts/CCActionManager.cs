﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback {

    public FirstController sceneController;

    // Use this for initialization
    protected new void Start ()
    {
        sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
    }
	
	// Update is called once per frame
	protected new void Update ()
    {
        base.Update();
	}

    #region ISSActionCallback implementation
    public void SSActionEvent (SSAction source,
        SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null)
    {

    }
    #endregion


}
