using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

    Stack<GameObject> priests;
    Stack<GameObject> devils;

    void Awake()
    {
        Director director = Director.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
        priests = new Stack<GameObject>();
        devils = new Stack<GameObject>();
    }

    public void LoadResources()
    {
        GameObject priest1 = Instantiate<GameObject> (
                Resources.Load("Prefab/Priest") as GameObject,
                Vector3.right * 6, Quaternion.identity);
        priest1.name = "priest1";
        priests.Push(priest1);
        GameObject priest2 = Instantiate<GameObject>(
                Resources.Load("Prefab/Priest") as GameObject,
                Vector3.right * 8, Quaternion.identity);
        priest2.name = "priest2";
        priests.Push(priest2);
        GameObject priest3 = Instantiate<GameObject>(
                Resources.Load("Prefab/Priest") as GameObject,
                Vector3.right * 10, Quaternion.identity);
        priest3.name = "priest3";
        priests.Push(priest3);
        Debug.Log("load priests\n");

        GameObject devil1 = Instantiate<GameObject>(
                Resources.Load("Prefab/Devil") as GameObject,
                Vector3.right * 12, Quaternion.identity);
        devil1.name = "devil1";
        devils.Push(devil1);
        GameObject devil2 = Instantiate<GameObject>(
                Resources.Load("Prefab/Devil") as GameObject,
                Vector3.right * 14, Quaternion.identity);
        devil2.name = "devil2";
        devils.Push(devil2);
        GameObject devil3 = Instantiate<GameObject>(
                Resources.Load("Prefab/Devil") as GameObject,
                Vector3.right * 16, Quaternion.identity);
        devil3.name = "devil3";
        devils.Push(devil3);
        Debug.Log("load devils\n");

        GameObject GO = Instantiate<GameObject>(
                Resources.Load("Prefab/GO") as GameObject,
                new Vector3(11, -1.5f, 0), Quaternion.identity);
        GO.name = "GO";
        Debug.Log("load button\n");

        GameObject riverside1 = Instantiate<GameObject>(
                Resources.Load("Prefab/RiverSide") as GameObject,
                new Vector3(11, -1.5f, 0), Quaternion.identity);
        riverside1.name = "riverside1";
        GameObject riverside2 = Instantiate<GameObject>(
                Resources.Load("Prefab/RiverSide") as GameObject,
                new Vector3(-11, -1.5f, 0), Quaternion.identity);
        riverside2.name = "riverside2";
        Debug.Log("load riverside\n");

        GameObject boat = Instantiate<GameObject>(
                Resources.Load("Prefab/Boat") as GameObject,
                new Vector3(3, -1.5f, 0), Quaternion.AngleAxis(90, Vector3.forward));
        boat.name = "boat";
        Debug.Log("load boat\n");
    }

    void Start()
    {

    }

    public void Resume()
    {

    }

    public void Pause()
    {

    }

    public void GameOver()
    {
        Director.getInstance();
    }

    public void MoveBoat()
    {

    }

    public void GetOnBoatD()
    {

    }

    public void GetOnBoatP()
    {

    }

    public void GetOffBoatL()
    {

    }

    public void GetOffBoatR()
    {

    }
}
