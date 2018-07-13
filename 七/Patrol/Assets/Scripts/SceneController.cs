using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour, ISceneController
{
    IPool<GameObject> pool;
    Queue<GameObject> patrol;
    public GameObject Character { get; set; }
    public enum status { start, end, result }
    public status Status { get; set; }

    void Awake()
    {
        Status = status.start;
        Director director = Director.getInstance();
        patrol = new Queue<GameObject>();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
    }

    public void LoadResources()
    {
        GameObject player = Instantiate<GameObject>(
                Resources.Load("Prefab/Character") as GameObject,
                new Vector3(1, 0, 1), Quaternion.identity);
        player.name = "player";
        Character = player;
        pool = new Pool<GameObject>("Patrol") as IPool<GameObject>;
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = pool.GetT();
            obj.transform.position = new Vector3(5 * (i + 1), 0, 5 * (i + 1));
            patrol.Enqueue(obj);
        }
    }

    public GameObject getPlayer()
    {
        return Character;
    }

    public List<PatrolController> getPatrols()
    {
        List<PatrolController> patrols = new List<PatrolController>();
        foreach (var i in patrol)
        {
            patrols.Add(i.GetComponent<PatrolController>());
        }
        return patrols;
    }

    public void Start() { }

    public void Resume() { }

    public void Pause() { }
}
