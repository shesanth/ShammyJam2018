﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 100;
    public float damage = 20f;
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
            h.takeDamage(damage);
        }
    }

    //function to call to deal damage to enemy
    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            KillObject();
        }
    }

    void KillObject()
    {
        if(this.GetComponent<BossTeleport>() || this.GetComponent<JumpBoss>())
        {
            //go to next scene here
        }
        Destroy(this.gameObject);
    }
}
