using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {


    public float attentionRadius = 10.0f; //xdistance at which enemies will notice and run towards you
    public float yRadius = 5f;
    private GameObject player;
    public float runSpeed = 4f;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float distanceX = GetComponent<Transform>().position.x - player.GetComponent<Transform>().position.x;
        float distanceY = GetComponent<Transform>().position.y - player.GetComponent<Transform>().position.y;
        int direction = 1;
        if (distanceX > 0)
        {
            direction = -1;
        }
        if (Mathf.Abs(distanceX) < attentionRadius && Mathf.Abs(distanceY) < yRadius)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(runSpeed * direction, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<PlayerHealth>().takeDamage(50f);
        }
    }


}
