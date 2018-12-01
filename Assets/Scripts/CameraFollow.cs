using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset;
    public Transform target;
    public float speed;

	// Use this for initialization
	void Start () {
        offset = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 newPos = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);

	}
}
