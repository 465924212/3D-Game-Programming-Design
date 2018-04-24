using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction {
    void hit(GameObject gameObject);
    bool GetStatus();
    int GetRecord();
    void Restart();
    void GameOver();
    void GameStart();
    void UsePhy();
    void UseKin();
    bool GetMode();
}
