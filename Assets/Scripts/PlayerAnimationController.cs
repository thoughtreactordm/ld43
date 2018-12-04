using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    Animator anim;
    Rigidbody2D rb;
    PlatformerController controller;

    bool landed = true;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlatformerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x) / controller.speed);
        anim.SetFloat("velocityY", Mathf.Floor(rb.velocity.y));
        anim.SetBool("grounded", controller.isGrounded);

    }
}
