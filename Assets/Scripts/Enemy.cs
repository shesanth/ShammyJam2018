using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.


public class Enemy : MonoBehaviour {

    public float health = 100;
    public float damage = 20;
    private float startHealth;

    public Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponentInChildren<Slider>();
        startHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = health / startHealth;
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
