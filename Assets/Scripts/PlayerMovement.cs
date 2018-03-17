using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody rigid;

	public float maxSpeed = 20f;
	public float acceleration = 35f;
	public AnimationCurve animCurve;

	// Use this for initialization
	void Awake () {
		rigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		Vector3 velocity = rigid.velocity;

		//Horizontal Movement
		float xInput = Input.GetAxisRaw("Horizontal");
		float targetSpeed = xInput * maxSpeed;
		float xDiff = targetSpeed - velocity.x;
		float thisAcceleration = acceleration * animCurve.Evaluate(Mathf.Abs(xDiff / maxSpeed));
		float xStep = Mathf.Sign(xDiff) *
			Mathf.Min(Mathf.Abs(xDiff), thisAcceleration * Time.deltaTime);
		velocity.x += xStep;

		rigid.velocity = velocity;
	}
}
