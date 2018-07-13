using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : IPool<T> where T : Object
{
    Queue<T> pool = new Queue<T>();
    IFactory<T> factory;
    
    public Pool(string name)
    {
        factory = new Factory<T>(name) as IFactory<T>;
        for (int i = 0; i < 10; i++)
        {
            T obj = factory.CreateT();
            pool.Enqueue(obj);
        }
    }

    public int GetCount()
    {
        return pool.Count;
    }

    public T GetT()
    {
        if (pool.Count <= 0)
        {
            pool.Enqueue(factory.CreateT());
        }
        return pool.Dequeue();
    }

    public bool ReturnT(T obj)
    {
        pool.Enqueue(obj);
        return true;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
