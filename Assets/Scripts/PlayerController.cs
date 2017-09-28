using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    [SerializeField]
    float maxSpeed = 10f;
    [SerializeField]
    float accel = 1f;
    [SerializeField]
    float jumpSpeed = 5f;
    [SerializeField]
    int jumpTime = 25;
    [SerializeField]
    float groundRadius = 0.2f;
    [SerializeField]
    LayerMask whatIsGround;
    [SerializeField]
    float drag = 1;


    private float distToGround;
    private int jumpCounter = 0;
    private bool facingRight = true;
    Rigidbody2D rb;
    Collider2D col;
    Animator anim;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    SpriteRenderer sr;
    [SerializeField]
    AudioClip jumpAudio;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        distToGround = col.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            jumpCounter = jumpTime;
            AudioSource.PlayClipAtPoint(jumpAudio, transform.position, 10f);
        } else if (Input.GetButtonUp("Jump")) {
            jumpCounter = 0;
        }

        if (((Input.GetAxisRaw("Horizontal") > 0 && !facingRight) || (Input.GetAxisRaw("Horizontal") < 0 && facingRight))) {
            Flip();
        }
        UpdateAnimator();
	}

    private void Flip() {
        sr.flipX = facingRight;
        facingRight = !facingRight;
        
    }

    private void UpdateAnimator() {
        if (IsGrounded()) {
            anim.SetBool("Grounded", true);
        } else {
            anim.SetBool("Grounded", false);
        }
        anim.SetFloat("InputX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Speed", Math.Abs(rb.velocity.x));
        anim.SetFloat("Velocity", rb.velocity.x);
        
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void FixedUpdate() {
        float _xvelocity = rb.velocity.x + Input.GetAxisRaw("Horizontal")*accel;
        //Limiting Velocity
        _xvelocity = Mathf.Max(Mathf.Min(_xvelocity, maxSpeed), -maxSpeed);
        //print(_xvelocity);
        rb.velocity = new Vector2(_xvelocity, rb.velocity.y);
        if (jumpCounter > 0) {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpCounter -= 1;
        }
        if (Input.GetAxisRaw("Horizontal") == 0) {
            if (rb.velocity.x > 0) {
                rb.velocity = new Vector2(Math.Max(rb.velocity.x - drag, 0), rb.velocity.y);
            } else if(rb.velocity.x < 0) {
                rb.velocity = new Vector2(Math.Min(rb.velocity.x + drag, 0), rb.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "EnemyWeakSpot") {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            print("bounce");
        }
    }

}