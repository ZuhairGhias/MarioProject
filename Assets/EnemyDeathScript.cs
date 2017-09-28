using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour {

    [SerializeField]
    GameObject parent;
    [SerializeField]
    GameObject deathBox;
    [SerializeField]
    AudioClip deathSound;
    [SerializeField]
    float killTimer = 2f;
    bool setKillTimer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (setKillTimer == true) {
            killTimer -= Time.deltaTime;
        }
        if (killTimer <= 0) {
            Destroy(parent);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            parent.GetComponent<Animator>().SetBool("Dead", true);
            setKillTimer = true;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            GetComponent<BoxCollider2D>().enabled = false;
            deathBox.GetComponent<BoxCollider2D>().enabled = false;
            
            
        }
        //print(collision.gameObject.tag);
    }
}