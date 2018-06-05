using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHit : MonoBehaviour {

    public delegate void Hit(object sender);
    public static event Hit HitEvent; 

	// Use this for initialization
	void Start () {
        HitEvent += Injured;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObject = hitInfo.collider.gameObject;
                HitEvent(gameObject);
            }
        }
    }

    public void Injured(object target)
    {
        GameObject gameObject = (GameObject)target;
        gameObject.GetComponentsInChildren<Slider>()[0].value--;
    }
}
