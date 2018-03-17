using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;

    public float bulletSpeed = 5f;

    PlayerMovement player;

    void Awake()
    {
        player = this.GetComponent<PlayerMovement>();
    }

    public void DoShoot()
    {
        GameObject b = Instantiate(bullet, this.transform.position, Quaternion.identity);

        b.GetComponent<Rigidbody>().velocity = player.directionFacing * Vector3.right * bulletSpeed;
    }

    public void DoShootBoss(Transform target)
    {
        GameObject b = Instantiate(bullet, this.transform.position, Quaternion.identity);

        b.GetComponent<Rigidbody>().velocity = (target.position - this.transform.position).normalized * bulletSpeed;
    }
}
