using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringyPowerBlock : MonoBehaviour {

    private Vector3 lowestPosition;
    [SerializeField]
    GameObject parent;
    [SerializeField]
    GameObject coin;
    bool activated = false;

    // Use this for initialization
    void Start() {
        lowestPosition = transform.position;
        GetComponent<SpringJoint2D>().connectedAnchor = lowestPosition;

    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y > lowestPosition.y + 0.2f && !activated) {
            parent.GetComponent<Animator>().SetBool("Activated", true);
            activated = true;
            Instantiate(coin, transform.position, Quaternion.identity, parent.transform);
        }

        //transform.position = new Vector3(lowestPosition.x, Mathf.Max(transform.position.y, lowestPosition.y), transform.position.z);
    }
}