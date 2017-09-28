using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {

    bool landed = false;
    private Animator anim;
    [SerializeField]
    float groundRadius = 0.2f;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask whatIsGround;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (IsGrounded()) {
            landed = true;
            anim.SetBool("Pole", false);
        }
        if (landed) {
            rb.velocity = Vector2.down * 3 + Vector2.right * 3;

        } else {
            rb.velocity = Vector2.down * 3;
        }
        UpdateAnimator();
	}
    private void UpdateAnimator() {
        if (IsGrounded()) {
            anim.SetBool("Grounded", true);
        } //else {
        //    anim.SetBool("Grounded", false);
        //}
        anim.SetFloat("InputX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Speed", 3f);
        anim.SetFloat("Velocity", 8f);

    }
    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "End") {
            Destroy(gameObject);
        }
    }
}