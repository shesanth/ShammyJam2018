using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Camera should move when center of camera is certain distance from player
public class CameraMoveScript : MonoBehaviour {



    public float dampTime = 0.15f;
    public float distAllow = 20;
    private Vector3 velocity = Vector3.zero;
    private GameObject player; 
    void Start () {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        if (player)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(player.GetComponent<Transform>().position);
            Vector3 delta = player.GetComponent<Transform>().position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
