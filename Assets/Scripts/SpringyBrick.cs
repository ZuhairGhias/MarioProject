using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringyBrick : MonoBehaviour {

    private Vector3 lowestPosition;

	// Use this for initialization
	void Start () {
        lowestPosition = transform.position;
        GetComponent<SpringJoint2D>().connectedAnchor = lowestPosition;
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(lowestPosition.x, Mathf.Max(transform.position.y, lowestPosition.y), transform.position.z);
	}
}