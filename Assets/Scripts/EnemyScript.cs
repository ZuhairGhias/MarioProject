using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    int velocityMultiplier = -1;
    Rigidbody2D rb;
    [SerializeField]
    LayerMask colMask;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        if (Physics2D.Raycast(transform.position, Vector2.left, 0.35f, colMask)) {
            velocityMultiplier = 1;
            //print("wall left");
        }
        if (Physics2D.Raycast(transform.position, Vector2.right, 0.35f, colMask)) { 
            velocityMultiplier = -1;
            //print("wall right");
        }
        rb.velocity = new Vector2(velocityMultiplier * 2, rb.velocity.y);
        if (GetComponent<Animator>().GetBool("Dead")){
            rb.velocity = Vector2.zero;
        }
    }
}