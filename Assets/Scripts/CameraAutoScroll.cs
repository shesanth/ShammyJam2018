using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoScroll : MonoBehaviour {

    Camera mainCam;
    public float scrollSpeed = .01f;

	// Use this for initialization
	void Awake() {
        mainCam = FindObjectOfType<Camera>();
        mainCam.GetComponent<CameraMoveScript>().enabled = false;
	}

    void FixedUpdate()
    {
        mainCam.transform.position += Vector3.right * scrollSpeed;
    }
}
