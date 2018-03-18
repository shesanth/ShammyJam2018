using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFlavourText : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            this.GetComponent<Canvas>().enabled = false;
        }
	}
}
