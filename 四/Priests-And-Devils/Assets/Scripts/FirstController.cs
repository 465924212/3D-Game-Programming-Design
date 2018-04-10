using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

    private CCActionManager actionManager;
    private List<GameObject> Left;
    private List<GameObject> Right;
    private List<GameObject> OnBoat;
    private GameObject Boat;

    public List<Vector3> CharacterPositionL;
    public bool[] charL;
    public bool[] charR;
    public List<Vector3> CharacterPositionR;
    public List<Vector3> BoatPosition;
    public List<Vector3> OnBoatPosition;

    
    private enum BoatPos : int { left = 1, right = 0 }
    private enum BoatStatus : int { empty = 0, one, full }
    private enum OnBoatPos : int { left = 1, right = 0 }
    private BoatPos boatPos;
    private BoatStatus boatStatus;
    private OnBoatPos onBoatPos;

    void Awake()
    {
        Left = new List<GameObject>(6);
        Right = new List<GameObject>(6);
        OnBoat = new List<GameObject>(4);
        boatPos = BoatPos.right;
        boatStatus = BoatStatus.empty;
        CharacterPositionL = new List<Vector3>(6);
        CharacterPositionR = new List<Vector3>(6);
        charL = new bool[6];
        charR = new bool[6];
        for (int i = 0; i < 6; i++)
        {
            charL[i] = false;
            charR[i] = true;
            CharacterPositionL.Add(Vector3.left * (6 + 2 * i));
            CharacterPositionR.Add(Vector3.right * (6 + 2 * i));
        }
        BoatPosition = new List<Vector3>(2);
        BoatPosition.Add(new Vector3(3, -1.5f, 0));
        BoatPosition.Add(new Vector3(-3, -1.5f, 0));
        OnBoatPosition = new List<Vector3>(2);
        OnBoatPosition.Add(new Vector3(4, 0, 0));
        OnBoatPosition.Add(new Vector3(2, 0, 0));
        OnBoatPosition.Add(new Vector3(-2, 0, 0));
        OnBoatPosition.Add(new Vector3(-4, 0, 0));

        SSDirector director = SSDirector.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
    }

    public void LoadResources()
    {
        Vector3 pos = CharacterPositionR[0];

        for (int i = 1; i <= 3; i++, pos.x += 2)
        {
            GameObject priest = Instantiate<GameObject>(
                Resources.Load("Prefab/Priest") as GameObject,
                pos, Quaternion.identity);
            priest.name = "priest" + i.ToString();
            Right.Add(priest);
        }
        Debug.Log("load priests\n");

        for (int i = 1; i <= 3; i++, pos.x += 2)
        {
            GameObject devil = Instantiate<GameObject>(
                Resources.Load("Prefab/Devil") as GameObject,
                pos, Quaternion.identity);
            devil.name = "devil" + i.ToString();
            Right.Add(devil);
        }
        Debug.Log("load devils\n");

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
                BoatPosition[(int)BoatPos.right], Quaternion.AngleAxis(90, Vector3.forward));
        boat.name = "boat";
        Boat = boat;
        Debug.Log("load boat\n");
    }

    void Start()
    {
        actionManager = GetComponent<CCActionManager>();
    }

    public void Resume() { }

    public void Pause() { }

    public void GameOver()
    {
        SSDirector.getInstance().GameOver();
    }

    public void MoveCharacter(GameObject gameObject)
    {
        if (Left.Contains(gameObject))
        {
            if (boatPos.Equals(BoatPos.left) && !boatStatus.Equals(BoatStatus.full))
            {
                charL[CharacterPositionL.IndexOf(gameObject.transform.position)] = false;
                Left.Remove(gameObject);
                OnBoat.Add(gameObject);
                gameObject.transform.SetParent(Boat.transform, true);
                if (boatStatus.Equals(BoatStatus.empty))
                {
                    onBoatPos = OnBoatPos.left;
                    boatStatus = BoatStatus.one;
                    actionManager.RunAction(gameObject, CCMoveToAction.GetSSAction(OnBoatPosition[3]), actionManager);
                }
                else if (boatStatus.Equals(BoatStatus.one) && onBoatPos.Equals(OnBoatPos.left)){
                    onBoatPos = OnBoatPos.right;
                    boatStatus = BoatStatus.full;
                    actionManager.RunAction(gameObject, CCMoveToAction.GetSSAction(OnBoatPosition[2]), actionManager);
                }
                else if (boatStatus.Equals(BoatStatus.one) && onBoatPos.Equals(OnBoatPos.right))
                {
                    onBoatPos = OnBoatPos.left;
                    boatStatus = BoatStatus.full;
                    actionManager.RunAction(gameObject, CCMoveToAction.GetSSAction(OnBoatPosition[3]), actionManager);
                }
            }
        }
        else if (Right.Contains(gameObject))
        {
            if (boatPos.Equals(BoatPos.right) && !boatStatus.Equals(BoatStatus.full))
            {
                charR[CharacterPositionR.IndexOf(gameObject.transform.position)] = false;
                Right.Remove(gameObject);
                OnBoat.Add(gameObject);
                gameObject.transform.SetParent(Boat.transform, true);
                if (boatStatus.Equals(BoatStatus.empty))
                {
                    onBoatPos = OnBoatPos.right;
                    boatStatus = BoatStatus.one;
                    actionManager.RunAction(gameObject, CCMoveToAction.GetSSAction(OnBoatPosition[0]), actionManager);
                }
                else if (boatStatus.Equals(BoatStatus.one) && onBoatPos.Equals(OnBoatPos.right))
                {
                    onBoatPos = OnBoatPos.left;
                    boatStatus = BoatStatus.full;
                    actionManager.RunAction(gameObject, CCMoveToAction.GetSSAction(OnBoatPosition[1]), actionManager);
                }
                else if (boatStatus.Equals(BoatStatus.one) && onBoatPos.Equals(OnBoatPos.left))
                {
                    onBoatPos = OnBoatPos.right;
                    boatStatus = BoatStatus.full;
                    actionManager.RunAction(gameObject, CCMoveToAction.GetSSAction(OnBoatPosition[0]), actionManager);
                }
            }
        }
        else if (OnBoat.Contains(gameObject))
        {
            if (boatStatus.Equals(BoatStatus.full))
            {
                boatStatus = BoatStatus.one;
                if (OnBoatPosition.IndexOf(gameObject.transform.position) == 0 || OnBoatPosition.IndexOf(gameObject.transform.position) == 2)
                {
                    onBoatPos = OnBoatPos.left;
                }
                else if (OnBoatPosition.IndexOf(gameObject.transform.position) == 1 || OnBoatPosition.IndexOf(gameObject.transform.position) == 3)
                {
                    onBoatPos = OnBoatPos.right;
                }
            }
            else if (boatStatus.Equals(BoatStatus.one))
            {
                boatStatus = BoatStatus.empty;
            }
            OnBoat.Remove(gameObject);
            gameObject.transform.SetParent(null, true);
            if (boatPos.Equals(BoatPos.right))
            {
                Vector3 pos = Vector3.right;
                if (gameObject.name.Contains("devil"))
                {
                    for (int i = 3; i < 6; i++)
                    {
                        if (charR[i] == false)
                        {
                            charR[i] = true;
                            pos = CharacterPositionR[i];
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (charR[i] == false)
                        {
                            charR[i] = true;
                            pos = CharacterPositionR[i];
                            break;
                        }
                    }
                }
                
                Right.Add(gameObject);
                actionManager.RunAction(gameObject, CCMoveToAction.GetSSAction(pos), actionManager);
            }
            else if (boatPos.Equals(BoatPos.left))
            {
                Vector3 pos = Vector3.left;
                if (gameObject.name.Contains("devil"))
                {
                    for (int i = 3; i < 6; i++)
                    {
                        if (charL[i] == false)
                        {
                            charL[i] = true;
                            pos = CharacterPositionL[i];
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (charL[i] == false)
                        {
                            charL[i] = true;
                            pos = CharacterPositionL[i];
                            break;
                        }
                    }
                }

                Left.Add(gameObject);
                actionManager.RunAction(gameObject, CCMoveToAction.GetSSAction(pos), actionManager);
            }
        }
    }

    public void MoveBoat()
    {
        if (!boatStatus.Equals(BoatStatus.empty))
        {
            if (boatPos.Equals(BoatPos.left))
            {
                boatPos = BoatPos.right;
                actionManager.RunAction(Boat, CCMoveToAction.GetSSAction(BoatPosition[0]), actionManager);
            }
            else if (boatPos.Equals(BoatPos.right))
            {
                boatPos = BoatPos.left;
                actionManager.RunAction(Boat, CCMoveToAction.GetSSAction(BoatPosition[1]), actionManager);
            }
        }
    }
}
