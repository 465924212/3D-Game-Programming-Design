using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction {

    void GameOver();
    void GetOnBoatP();
    void GetOnBoatD();
    void GetOffBoatR();
    void GetOffBoatL();
    void MoveBoat();
}
