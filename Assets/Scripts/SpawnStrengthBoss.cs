using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStrengthBoss : MonoBehaviour {

    public GameObject strengthBossGenerator;
    GameObject player;

    bool alreadyahppened = false;

    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !alreadyahppened)
        {
            alreadyahppened = true;
            GameObject a = Instantiate(strengthBossGenerator, this.transform.position, Quaternion.identity);
            //also spawn the actual boss and other stuff here, like health bar here
            Destroy(this.gameObject);
        }
    }
}
