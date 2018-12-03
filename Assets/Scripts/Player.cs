using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    CameraFollow camera;
    bool dead;
    Rigidbody2D rb;
    Transform deathLevel;

	// Use this for initialization
	void Start () {
        camera = Camera.main.GetComponent<CameraFollow>();
        rb = GetComponent<Rigidbody2D>();
        deathLevel = GameObject.FindGameObjectWithTag("DeathLevel").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < deathLevel.position.y && !dead) {
            Death();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Spikes" && !dead) {

            if (collision.contacts[0].normal.y != 0) {

                Death();
            }
        }
    }

    void Death()
    {
        Debug.Log("Death!");
        dead = true;
        camera.target = null;
        GameManager.instance.GameOver();
    }
}
