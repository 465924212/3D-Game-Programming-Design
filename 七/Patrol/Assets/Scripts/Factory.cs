using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory<T> : IFactory<T> where T : Object
{
    string Name;

    public Factory(string name)
    {
        Name = name;
    }

    public T CreateT()
    {
        if (typeof(T) == typeof(GameObject))
        {
            return Object.Instantiate<T>(
                Resources.Load("Prefab/" + Name) as T,
                Vector3.zero, Quaternion.identity);
        }
        return default(T);
    }

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }
}