using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour {


    [SerializeField]
    float tossCountDown = 2f;
    bool toss = false;
    float initialGravity;
    [SerializeField]
    Transform gameManager;


	// Use this for initialization
	void Start () {
        initialGravity = GetComponent<Rigidbody2D>().gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (toss == true) {
            tossCountDown -= Time.deltaTime;
        }
        if (tossCountDown <= 0) {
            TossPlayer();
            toss = false;
            tossCountDown = 1;
        }
	}

    private void TossPlayer() {
        GetComponent<Rigidbody2D>().gravityScale = initialGravity;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 20;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Finish") {
            print("finish");
            GetComponent<PlayerController>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Animator>().SetBool("Pole", true);
            GetComponent<FinishScript>().enabled = true;
        }
        if (collision.gameObject.tag == "EnemyDeathSpot") {
            //Destroy(gameObject);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Animator>().SetBool("Dead", true);
            toss = true;
            gameManager.GetComponent<GameManager>().ResetLevel();
            print("Die");
        }
    }
}