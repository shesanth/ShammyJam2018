using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;

    public float bulletSpeed = 10f;

    public void DoShoot()
    {
        GameObject b = Instantiate(bullet, this.transform.position, Quaternion.identity);

        b.GetComponent<Rigidbody>().velocity = Vector3.right * bulletSpeed;
    }

    public void DoShootBoss(Transform target)
    {
        GameObject b = Instantiate(bullet, this.transform.position, Quaternion.identity);

        b.GetComponent<Rigidbody>().velocity = (target.position - this.transform.position).normalized * bulletSpeed;
    }
}
