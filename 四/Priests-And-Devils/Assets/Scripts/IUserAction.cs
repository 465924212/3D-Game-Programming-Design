using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction {
    void MoveCharacter(GameObject gameObject);
    void MoveBoat();
    void GameOver();
}
