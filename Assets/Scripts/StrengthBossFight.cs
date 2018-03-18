using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBossFight : MonoBehaviour {

    public float speed;
    Animator animator;

	// Use this for initialization
	void Awake() {
        speed = FindObjectOfType<CameraAutoScroll>().scrollSpeed;
        animator = GetComponent<Animator>();
        animator.SetTrigger("run");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += Vector3.right * speed;
    }
}
