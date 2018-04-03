using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

    public Stack<GameObject> priestsR { get; set; }
    public Stack<GameObject> devilsR { get; set; }
    public Stack<GameObject> priestsL { get; set; }
    public Stack<GameObject> devilsL { get; set; }
    public Stack<GameObject> boats { get; set; }
    public GameObject theboat { get; set; }
    public enum boatstatus { empty, left, right, full};
    public boatstatus Status;

    void Awake()
    {
        priestsR = new Stack<GameObject>();
        devilsR = new Stack<GameObject>();
        boats = new Stack<GameObject>();
        Status = boatstatus.empty;
        Director director = Director.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
    }

    public void LoadResources()
    {
        GameObject priest1 = Instantiate<GameObject> (
                Resources.Load("Prefab/Priest") as GameObject,
                Vector3.right * 6, Quaternion.identity);
        priest1.name = "priest1";
        priestsR.Push(priest1);
        GameObject priest2 = Instantiate<GameObject>(
                Resources.Load("Prefab/Priest") as GameObject,
                Vector3.right * 8, Quaternion.identity);
        priest2.name = "priest2";
        priestsR.Push(priest2);
        GameObject priest3 = Instantiate<GameObject>(
                Resources.Load("Prefab/Priest") as GameObject,
                Vector3.right * 10, Quaternion.identity);
        priest3.name = "priest3";
        priestsR.Push(priest3);
        Debug.Log("load priests\n");

        GameObject devil1 = Instantiate<GameObject>(
                Resources.Load("Prefab/Devil") as GameObject,
                Vector3.right * 12, Quaternion.identity);
        devil1.name = "devil1";
        devilsR.Push(devil1);
        GameObject devil2 = Instantiate<GameObject>(
                Resources.Load("Prefab/Devil") as GameObject,
                Vector3.right * 14, Quaternion.identity);
        devil2.name = "devil2";
        devilsR.Push(devil2);
        GameObject devil3 = Instantiate<GameObject>(
                Resources.Load("Prefab/Devil") as GameObject,
                Vector3.right * 16, Quaternion.identity);
        devil3.name = "devil3";
        devilsR.Push(devil3);
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
        theboat = boat;
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
        if (Status != boatstatus.empty)
        {
            boats.Peek().transform.Translate(new Vector3(-6, 0, 0));
        }
    }

    public void GetOnBoatDR()
    {
        GameObject target = devilsR.Pop();
        if (Status != boatstatus.right)
        {
            target.transform.position = new Vector3(3.5f, 0, 0);
            boats.Push(target);
            Status = boatstatus.right;
        }
        else if (Status != boatstatus.left)
        {
            boats.Push(target);
            target.transform.position = new Vector3(2.5f, 0,0);
            Status = boatstatus.full;
        }
    }

    public void GetOnBoatDL()
    {
        GameObject target = devilsL.Pop();
        if (Status != boatstatus.left)
        {
            boats.Push(target);
            target.transform.position = new Vector3(-3.5f, 0, 0);
            Status = boatstatus.left;
        }
        else if (Status != boatstatus.right)
        {
            boats.Push(target);
            target.transform.position = new Vector3(-2.5f, 0, 0);
            Status = boatstatus.full;
        }
    }

    public void GetOnBoatPR()
    {
        GameObject target = priestsR.Pop();
        if (Status != boatstatus.right)
        {
            boats.Push(target);
            target.transform.position = new Vector3(3.5f, 0, 0);
            Status = boatstatus.right;
        }
        else if (Status != boatstatus.left)
        {
            boats.Push(target);
            target.transform.position = new Vector3(2.5f, 0, 0);
            Status = boatstatus.full;
        }
    }

    public void GetOnBoatPL()
    {
        GameObject target = priestsL.Pop();
        if (Status != boatstatus.left)
        {
            boats.Push(target);
            target.transform.position = new Vector3(-3.5f, 0, 0);
            Status = boatstatus.left;
        }
        else if (Status != boatstatus.right)
        {
            boats.Push(target);
            target.transform.position = new Vector3(-2.5f, 0, 0);
            Status = boatstatus.full;
        }
    }

    public void GetOffBoatL()
    {

    }

    public void GetOffBoatR()
    {

    }
}
