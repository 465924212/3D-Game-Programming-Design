using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    ParticleSystem ball;
    //三个属性对应RGB属性
    public float temperature;
    public float height;
    public float humidity;

	// Use this for initialization
	void Start () {
        ball = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        var main = ball.main;
        main.startColor = new Color(temperature/255, height/255, humidity/255);
	}
}
