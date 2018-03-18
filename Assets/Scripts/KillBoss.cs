using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
        }
    }
}
