using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUIbloodbar : MonoBehaviour {

    public delegate void Hit(object sender);
    public static event Hit HitEvent;
    float blood = 10;
    public float height;

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

    void OnGUI()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(GetComponent<Transform>().position);
        pos.y -= height;
        pos.x -= GetComponent<Transform>().lossyScale.x * 20;
        GUI.HorizontalSlider(new Rect(pos, new Vector2(50, 20)), blood, 0, 10);
    }

    public void Injured(object target)
    {
        GameObject gameObject = (GameObject)target;
        gameObject.GetComponent<IMGUIbloodbar>().blood--;
    }
}
