using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour {

    public List<Vector3> square;
    int line;

    public bool Patrol {
        get; set;
    }

	// Use this for initialization
	void Start () {
        Patrol = true;
        line = 1;
        Vector3 pos = GetComponent<Transform>().position;
        square.Add(pos);
        square.Add(new Vector3(pos.x + 5, 0, pos.z));
        square.Add(new Vector3(pos.x + 5, 0, pos.z + 5));
        square.Add(new Vector3(pos.x, 0, pos.z + 5));
    }
	
	// Update is called once per frame
	void Update () {
        if (Patrol)
        {
            Vector3 pos = GetComponent<Transform>().position;
            if (line == 2)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, square[2], 0.05f);
                if (pos == square[2])
                {
                    line = 3;
                }
            }
            else if (line == 3)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, square[3], 0.05f);
                if (pos == square[3])
                {
                    line = 4;
                }
            }
            else if (line == 4)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, square[0], 0.05f);
                if (pos == square[0])
                {
                    line = 1;
                }
            }
            else if (line == 1)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, square[1], 0.05f);
                if (pos == square[1])
                {
                    line = 2;
                }
            }
        }
        else
        {
            Vector3 player = Director.getInstance().currentSceneController.getPlayer().transform.position;
            transform.position = Vector3.MoveTowards(this.transform.position, player, 0.05f);
        }
    }

    public void StartChase()
    {
        Patrol = false;
    }

    public void StopChase()
    {
        Patrol = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            Debug.Log("Game Over!");
        }
    }
}
