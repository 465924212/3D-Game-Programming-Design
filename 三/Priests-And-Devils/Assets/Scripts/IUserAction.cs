using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction {

    void GameOver();
    void GetOnBoatPR();
    void GetOnBoatPL();
    void GetOnBoatDR();
    void GetOnBoatDL ();
    void GetOffBoatR();
    void GetOffBoatL();
    void MoveBoat();
}
