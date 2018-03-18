using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnJumpBoss : MonoBehaviour {


    public GameObject barrier;
    public GameObject boss;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerHealth>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            SpawnBoss();
        }
    }


    public void SpawnBoss()
    {
        SceneManager.LoadScene("mars");
    }
}
