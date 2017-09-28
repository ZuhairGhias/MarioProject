using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    [SerializeField]
    GameObject cam;
    [SerializeField]
    Transform enemy;
    [SerializeField]
    float spawnDist = 10f;
    // Use this for initialization
    void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x - cam.transform.position.x <= spawnDist) {
            Instantiate(enemy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}