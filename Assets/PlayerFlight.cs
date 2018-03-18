using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlight : MonoBehaviour {

    float speed;

    Rigidbody rb;

	// Use this for initialization
	void Awake () {
        rb = this.GetComponent<Rigidbody>();
        PlayerMovement p = this.GetComponent<PlayerMovement>();
        speed = p.maxSpeed;
        p.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(xInput * speed, yInput * speed, 0);
    }
}
