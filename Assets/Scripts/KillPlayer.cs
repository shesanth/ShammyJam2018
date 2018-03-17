using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<PlayerHealth>().KillPlayer();
        }
    }
}
