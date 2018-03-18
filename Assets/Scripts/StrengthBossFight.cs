using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBossFight : MonoBehaviour {

    float speed;
	// Use this for initialization
	void Awake() {
        speed = FindObjectOfType<CameraAutoScroll>().scrollSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += Vector3.right * speed;
    }
}
