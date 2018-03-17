using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{

    public float destroyTime = 2f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
