using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

    private IActionManager actionManager;
    private Factory factory;
    private Recorder recorder;
    public int Round { get; set; }
    public enum Status { start, end, result }
    public Status status { get; set; }
    public bool Mode {get; set;}

    void Awake()
    {
        status = Status.end;
        SSDirector director = SSDirector.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
        factory = Factory.Instance;
        recorder = Recorder.Instance;
        Round = 1;
        actionManager = GetComponent<CCActionManager>() as IActionManager;
        Mode = false;
    }

    public void UseKin()
    {
        actionManager = GetComponent<CCActionManager>() as IActionManager;
        Mode = false;
    }

    public void UsePhy()
    {
        actionManager = GetComponent<PhysisActionManager>() as IActionManager;
        Mode = true;
    }

    public void LoadResources() { }

    public void Start() { }

    public void Resume() { }

    public void Pause() { }

    public void GameOver()
    {
        SSDirector.getInstance().GameOver();
    }

    public void GameStart()
    {
        if (Round < 11 && status.Equals(Status.end))
        {
            for (int i = 0; i < Round; i++)
            {
                Debug.Log("s" + i.ToString());
                GameObject ufo = factory.UseUFO();
                float speed = Random.Range(1, 3 * Round);
                float g = Random.Range(0.1f, Round / 7);
                actionManager.PlayDisk(ufo, speed, g);
            }
            Round++;
            status = Status.start;
        } else if (Round == 11)
        {
            status = Status.result;
        }
    }

    public void hit(GameObject gameObject)
    {
        factory.ChangeM(gameObject);
        if (!gameObject.tag.Contains("hit"))
        {
            recorder.getRecord(gameObject);
        }
        gameObject.tag = "hit";
    }

    public bool GetStatus()
    {
        if (status.Equals(Status.result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetMode()
    {
        return Mode;
    }

    public int GetRecord()
    {
        return recorder.Record;
    }

    public void Restart()
    {
        Round = 1;
        status = Status.end;
        recorder.Record = 0;
    }

    public void ReturnUFO(GameObject gameObject)
    {
        gameObject.tag = "Untagged";
        factory.ReturnUFO(gameObject);
        if (!factory.NoUseUFO())
        {
            status = Status.end;
        }
    }
}
