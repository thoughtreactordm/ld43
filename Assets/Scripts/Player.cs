using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    CameraFollow camera;
    bool dead;

	// Use this for initialization
	void Start () {
        camera = Camera.main.GetComponent<CameraFollow>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10f && !dead) {
            Debug.Log("Death!");
            dead = true;

            camera.target = null;
            GameManager.instance.GameOver();
        }
	}
}
