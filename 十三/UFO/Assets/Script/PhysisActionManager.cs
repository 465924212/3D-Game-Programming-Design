using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysisActionManager : SSActionManager, ISSActionCallback, IActionManager {

    public FirstController sceneController;

    // Use this for initialization
    protected new void Start ()
    {
        sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        base.Update();
    }

    public void PlayDisk(GameObject gameObject, float speed, float g)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.position = new Vector3(Random.Range(-12, -5), Random.Range(5, 7), 0);
        this.RunAction(gameObject, PhyMoveToAction.GetSSAction(speed, g), this);
    }

    #region ISSActionCallback implementation
    public void SSActionEvent (SSAction source,
        SSActionEventType events = SSActionEventType.Completed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null)
    {
        source.gameObject.GetComponent<Rigidbody>().useGravity = false;
        source.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        source.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        sceneController.ReturnUFO(source.gameObject);
    }
    #endregion

}
