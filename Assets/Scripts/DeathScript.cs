using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    [SerializeField]
    GameObject gameManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            gameManager.GetComponent<GameManager>().ResetLevel();
        } else {
            Destroy(collision.gameObject);
        }
    }
}