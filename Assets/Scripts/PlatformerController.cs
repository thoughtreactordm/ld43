using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour {
    
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;
    private int extraJumps;
    public int maxExtraJumps;
    public float jumpTime;
    float jumpTimeCounter;
    private bool isJumping;

    private float moveInput;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;

    public bool canPassThrough = true;

    TesseloidSpawner spawner;

    private void Start()
    {
        extraJumps = maxExtraJumps;
        rb = GetComponent<Rigidbody2D>();

        spawner = GetComponent<TesseloidSpawner>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        moveInput = Input.GetAxisRaw("Horizontal");

        if (!spawner.placing)
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;

        if (facingRight == false && moveInput > 0) {
            Flip();
        } else if (facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    private void Update()
    {
        if (isGrounded) {
            extraJumps = maxExtraJumps;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Jump();
            extraJumps--;
        } else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Jump();
        }

        if (Input.GetButton("Jump") && isJumping) {
            if (jumpTimeCounter > 0) {
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
        }
    }

    void Jump()
    {
        if (!spawner.placing)
            rb.velocity = Vector2.up * jumpForce;
    }

    private void Flip() 
    {
        if (!spawner.placing) {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }
}
