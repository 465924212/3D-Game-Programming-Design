using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool<T>
{
    T GetT();
    bool ReturnT(T obj);
}
