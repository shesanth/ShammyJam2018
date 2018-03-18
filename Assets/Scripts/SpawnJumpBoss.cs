using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnJumpBoss : MonoBehaviour {


    public GameObject barrier;
    public GameObject boss;
    private GameObject player;
	// Use this for initialization
<<<<<<< HEAD
	void Start () {
=======
	void Start () {
>>>>>>> b68cc1f9b7bf15f31d8a35c37c7f4de938008fd4
        player = FindObjectOfType<PlayerHealth>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

<<<<<<< HEAD
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
=======
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
>>>>>>> b68cc1f9b7bf15f31d8a35c37c7f4de938008fd4
    }
}
