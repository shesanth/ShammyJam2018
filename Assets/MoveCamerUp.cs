using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamerUp : MonoBehaviour {
    private Rigidbody rb;

    public float moveSpeed = 5f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        rb.velocity = new Vector3(0, moveSpeed, 0);
    }
}
