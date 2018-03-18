using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour {

	void OnTriggerEnter(Collider collision)
    {
        Enemy e = collision.GetComponent<Enemy>();
        if(e != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
