using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesseloid : MonoBehaviour {

    public Transform pivot;

    public bool placed;

    float fallTimer;
    public float fallInterval;
    public float fallMultiplier;

    float translateTimer;
    public float translateInterval;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (!placed) {
            fallTimer += Time.deltaTime;
            translateTimer += Time.deltaTime;

		    if (Input.GetKeyDown(KeyCode.Q)) {
                Rotate(90f);
            } else if (Input.GetKeyDown(KeyCode.E)) {
                Rotate(-90f);
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                Translate(-1f);
            } else if (Input.GetKeyDown(KeyCode.D)) {
                Translate(1f);
            }
            
            Fall();
        }
	}

    void Rotate(float direction)
    {
        pivot.Rotate(0, 0, direction);
    }

    void Translate(float direction)
    {
        if (translateTimer >= translateInterval) {
            transform.Translate(direction, 0f, 0f);
            translateTimer = 0;
        }
    }

    void Fall()
    {
        if (fallTimer >= fallInterval) {
            transform.Translate(Vector2.down * fallMultiplier);
            fallTimer = 0;
        }
    }
}
