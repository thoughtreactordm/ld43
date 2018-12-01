using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughPlatform : MonoBehaviour {

    PlatformerController controller;
    PlatformEffector2D effector;

    public float waitTime;
    float wait;


	// Use this for initialization
	void Start () {
        wait = waitTime;
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerController>();
        effector = GetComponent<PlatformEffector2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") < 0 && controller.canPassThrough) {
            if (wait <= 0) {
                effector.rotationalOffset = 180f;
                StartCoroutine(ResetPlatform());
            } else {
                wait -= Time.deltaTime;
            }
        }
	}

    IEnumerator ResetPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        wait = waitTime;
        effector.rotationalOffset = 0f;
    }
}
