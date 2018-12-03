using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseloidSpawner : MonoBehaviour {

    public static TesseloidSpawner instance;

    public GameObject[] tesseloidPrefabs;
    public List<Tesseloid> tesseloids = new List<Tesseloid>();
    public int maxTesseloids;

    public bool placing = false;

    Tesseloid activeTesseloid;


	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.LeftShift) && !placing) {
            Spawn();
        }

        if (activeTesseloid != null && activeTesseloid.placed) {
            activeTesseloid = null;
            placing = false;
        } else if (activeTesseloid == null) {
            placing = false;
        }        

	}

    void Spawn()
    {
        placing = true;

        if (tesseloids.Count == maxTesseloids) {
            tesseloids[0].Sacrifice();
            tesseloids.RemoveAt(0);
        }

        int random = Random.Range(0, tesseloidPrefabs.Length);

        Vector3 pos = new Vector3(Mathf.Ceil(transform.position.x), Mathf.Ceil(transform.position.y + 12f), transform.position.z);

        GameObject newTesseloid = Instantiate(tesseloidPrefabs[random], pos, Quaternion.identity);

        activeTesseloid = newTesseloid.GetComponent<Tesseloid>();

        tesseloids.Add(activeTesseloid);
    }
}
