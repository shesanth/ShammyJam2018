using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStrengthBoss : MonoBehaviour {

    public GameObject strengthBossGenerator;
    GameObject player;

    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            GameObject a = Instantiate(strengthBossGenerator,this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
