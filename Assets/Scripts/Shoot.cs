using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;

    public float bulletSpeed = 5f;

    PlayerMovement player;
    BossTeleport enemy;

    void Awake()
    {
        player = this.GetComponent<PlayerMovement>();
        enemy = this.GetComponent<BossTeleport>();
    }

    public void DoShoot()
    {
        GameObject b = Instantiate(bullet, this.transform.position, Quaternion.identity);
        b.GetComponent<DestroyOnHit>().shooter = player;
        b.GetComponent<Rigidbody>().velocity = player.directionFacing * Vector3.right * bulletSpeed;
    }

    public void DoShootBoss(Transform target)
    {
        GameObject b = Instantiate(bullet, this.transform.position + (new Vector3(.5f, 0, 0) * enemy.directionFacing), Quaternion.identity);

        b.GetComponent<Rigidbody>().velocity = (target.position - (this.transform.position + (new Vector3(.5f, 0, 0) * enemy.directionFacing))).normalized * bulletSpeed;
    }
}
