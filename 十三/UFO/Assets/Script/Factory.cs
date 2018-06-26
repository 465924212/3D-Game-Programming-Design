using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {
    
    private List<GameObject> UFOSF;
    private List<GameObject> UFOSU;
    private List<Material> materials;

    // Use this for initialization
    void Start() { }

    void Awake () {
        UFOSF = new List<GameObject>();
        UFOSU = new List<GameObject>();
        materials = new List<Material>();
        for (int i = 0; i < 10; i++)
        {
            GameObject UFO = Instantiate<GameObject>(
                Resources.Load("Prefab/UFO") as GameObject,
                new Vector3(-12, 7, 0), Quaternion.identity);
            
            UFOSF.Add(UFO);
        }
        
        materials.Add(Resources.Load("Materials/UFOA", typeof(Material)) as Material);
        materials.Add(Resources.Load("Materials/UFOB", typeof(Material)) as Material);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool NoUseUFO()
    {
        return UFOSU.Count > 0;
    }

    public void ChangeM(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().material = materials[1];
    }

    public GameObject UseUFO()
    {
        if (UFOSF.Count <= 0)
        {
            UFOSF.Add(Instantiate<GameObject>(
                Resources.Load("Prefab/UFO") as GameObject,
                new Vector3(-12, 7, 0), Quaternion.identity));
        }
        GameObject ufo = UFOSF[0];
        UFOSF.Remove(ufo);
        UFOSU.Add(ufo);
        return ufo;
    }

    public void ReturnUFO(GameObject ufo)
    {
        UFOSU.Remove(ufo);
        ufo.transform.position = new Vector3(-12, 7, 0);
        ufo.GetComponent<Renderer>().material = materials[0];
        UFOSF.Add(ufo);
    }

    protected static Factory instance;
    public static Factory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (Factory)FindObjectOfType(typeof(Factory));
            }
            return instance;
        }
    }
}
