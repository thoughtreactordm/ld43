using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseloid : MonoBehaviour {

    public Transform pivot;

    public bool placed;

    float fallTimer;
    public float fallInterval;
    float fallMultiplier = 1f;

    float translateTimer;
    public float translateInterval;

    public LayerMask collisionMask;

    public TesseloidBlock[] blocks;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (!placed) {
            fallTimer += Time.deltaTime * fallMultiplier;
            translateTimer += Time.deltaTime;

		    if (Input.GetKeyDown(KeyCode.Q)) {
                Rotate(90f);
            } else if (Input.GetKeyDown(KeyCode.E)) {
                Rotate(-90f);
            }

            if (Input.GetKey(KeyCode.A)) {
                Translate(-1f);
            } else if (Input.GetKey(KeyCode.D)) {
                Translate(1f);
            }

            if (Input.GetKey(KeyCode.S)) {
                fallMultiplier = 4f;
            } else {
                fallMultiplier = 1f;
            }
            
            Fall();

            if (transform.position.y < -7f) {
                Sacrifice();
            }
        }
	}

    void Rotate(float direction)
    {
        Vector2 dir = new Vector2(direction / 90, 0f);

        if (OnCollisionCheck(dir)) {
            pivot.Rotate(0, 0, direction);
        }
    }

    void Translate(float direction)
    {
        if (translateTimer >= translateInterval) {
            Vector2 dir = new Vector2(direction, 0f);

            if (OnCollisionCheck(dir)) {
                transform.Translate(dir);
                translateTimer = 0;
            }
        }
    }

    void Fall()
    {
        if (fallTimer >= fallInterval) {
            transform.Translate(Vector2.down);
            fallTimer = 0;
        }
    }

    public void Sacrifice()
    {
        Destroy(gameObject);
    }

    bool OnCollisionCheck(Vector2 dir)
    {
        bool collision = true;

        foreach (var block in blocks) {
            if (!block.CheckCollisions(dir)) {
                collision = false;
            }
        }

        return collision;
    }
}
