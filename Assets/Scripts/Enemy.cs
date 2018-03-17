using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider collision)
    {
        //check if collision is the player, if so, deal damage to the player
        PlayerHealth h = collision.gameObject.GetComponent<PlayerHealth>();
        if (h != null)
        {
            h.takeDamage(20.0f);
        }
    }

    //function to call to deal damage to enemy
    private void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            KillObject();
        }
    }

    private void KillObject()
    {
        //TODO: add in death logic
    }
}
