using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody rigid;

	//Horizontal
	public float maxSpeed = 20f;
	public float acceleration = 35f;
	public AnimationCurve animCurve;

	//Vertical
	public float jumpTime = .5f;
	public float jumpHeight = 2.5f;
	public float maxFallSpeed = 5f;
	public AnimationCurve gravCurve;
	public float variableJumpCutoffSpeed = 1f;

	//Buffers
	public float groundedSlope = .75f;
	public float maxGroundedBuffer = .2f;
	float groundedBuffer = 0f;
	public float maxJumpBuffer = .2f;
	float jumpBuffer = 0;


	// Use this for initialization
	void Awake () {
		rigid = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")) {
			jumpBuffer = maxJumpBuffer;
		}
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

		//Gravity	
		float jumpPower = 2 * jumpHeight / jumpTime;
		float gravity = -2 * jumpHeight / (jumpTime * jumpTime);
		gravity *= gravCurve.Evaluate(velocity.y / jumpPower);
		if (!Input.GetButton("Jump") && velocity.y > variableJumpCutoffSpeed) {
			gravity *= 5;
		}
		velocity.y += gravity * Time.deltaTime;
		velocity.y = Mathf.Max(velocity.y, -maxFallSpeed);

		// Jump
		if (jumpBuffer > 0 && groundedBuffer > 0) 	{
			velocity.y = jumpPower;
			jumpBuffer = 0;
			groundedBuffer = 0;
		} 

		rigid.velocity = velocity;

		jumpBuffer -= Time.deltaTime;
		groundedBuffer -= Time.deltaTime;
	}

	void OnCollisionStay(Collision collision){
		if (Vector3.Dot(collision.contacts[0].normal, Vector3.up) > groundedSlope && rigid.velocity.y <= 0) {
			groundedBuffer = maxGroundedBuffer;
		}
	}
}
