using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {

    public float bulletDamage = 10f;

    [HideInInspector]
    public PlayerMovement shooter = null;

    void OnTriggerEnter(Collider collision)
    {
        if(shooter != null)//if player shot
        {
            Enemy e = collision.GetComponent<Enemy>();
            if(e != null) {
                //e.takeDamage(bulletDamage);
                Destroy(this.gameObject);
            }     
        }
        else//if enemy shot
        {
            PlayerHealth h = collision.GetComponent<PlayerHealth>();
            if (h != null)
            {
                h.takeDamage(bulletDamage);
                Destroy(this.gameObject);
            }
        }
    }
}
