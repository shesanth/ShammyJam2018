using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //check if collision is the player, if so, deal damage to the player
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            
        }
    }
}
