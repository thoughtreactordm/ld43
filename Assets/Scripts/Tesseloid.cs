﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tesseloid : MonoBehaviour {

    public Transform pivot;

    public bool placed;

    float fallTimer;
    public float fallInterval;
    float fallMultiplier = 1f;

    float translateTimer;
    public float translateInterval;

    float rotateTimer;
    public float rotateInterval;

    public LayerMask collisionMask;

    public TesseloidBlock[] blocks;

    Transform deathLevel;

	// Use this for initialization
	void Start () {
        deathLevel = GameObject.FindGameObjectWithTag("DeathLevel").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!placed) {
            fallTimer += Time.deltaTime * fallMultiplier;
            translateTimer += Time.deltaTime;
            rotateTimer += Time.deltaTime;

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

            if (transform.position.y < deathLevel.position.y) {
                Sacrifice();
                TesseloidSpawner.instance.tesseloids.Remove(this);
            }
        }
	}

    void Rotate(float direction)
    {
        if (rotateTimer >= rotateInterval) {
            Vector2 dir = new Vector2(direction / 90, 0f);

            if (OnCollisionCheck(dir)) {
                pivot.Rotate(0, 0, direction);

                rotateTimer = 0f;
            }
        }
    }

    void Translate(float direction)
    {
        if (translateTimer >= translateInterval) {
            Vector2 dir = new Vector2(direction, 0f);

            if (OnCollisionCheck(dir)) {
                //transform.Translate(dir);

                transform.DOMoveX(transform.position.x + dir.x, 0.35f, true);
                translateTimer = 0f;
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

    public void Remove()
    {
        TesseloidSpawner.instance.tesseloids.Remove(this);
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
