using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseloidSpawner : MonoBehaviour {

    public GameObject[] tesseloids;
    public bool placing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.LeftShift) && !placing) {

            Spawn();

        }


	}

    void Spawn()
    {
        placing = true;

        int random = Random.Range(0, tesseloids.Length);

        Vector3 pos = new Vector3(transform.position.x, 15, transform.position.z);

        GameObject newTesseloid = Instantiate(tesseloids[random], pos, Quaternion.identity);
    }
}
