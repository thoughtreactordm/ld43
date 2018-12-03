using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateRigidbody : MonoBehaviour {

    Rigidbody rb;
    public Vector3 velocity;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        rb.angularVelocity = velocity * speed;
	}
}
