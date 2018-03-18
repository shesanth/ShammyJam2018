using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBossUp : MonoBehaviour {
    Rigidbody rb;
    public float moveSpeedVariance = 0.5f;
    public float moveSpeed = 3f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
            
        rb.velocity = new Vector3(0,moveSpeed,0);
    }
}
