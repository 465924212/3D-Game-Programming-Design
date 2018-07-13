using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneController
{
    GameObject getPlayer();
    List<PatrolController> getPatrols();
    void LoadResources();
    void Pause();
    void Resume();

}