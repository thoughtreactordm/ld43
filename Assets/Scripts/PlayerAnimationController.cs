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
        if (Input.GetAxisRaw("Horizontal") != 0f) {
            anim.SetBool("Walking", true); // Walking
        } else if (controller.isJumping) {
            anim.SetTrigger("Jump"); // Jumping
            landed = false;
        } else if (rb.velocity.y < 0 && !controller.isGrounded) {
            anim.SetBool("Falling", true); // Falling
            landed = false;
        } else if (rb.velocity.y != 0 && !landed) {
            anim.SetTrigger("Landed");
            landed = true;        
        } else if (Input.GetAxisRaw("Horizontal") == 0f && landed) {
            anim.SetBool("Walking", false); // Idle
        }
    }
}
