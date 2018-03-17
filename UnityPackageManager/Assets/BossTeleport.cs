using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport : MonoBehaviour {

    public float timeUntilTeleport = 5f;
    float nextTeleport;

    public List<GameObject> teleportPositions;

    int position = 0;
    int newPosition = 0;

    bool teleporting = false;

    // Use this for initialization
    void Awake () {
        nextTeleport = timeUntilTeleport;
        this.transform.position = teleportPositions[0].transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(nextTeleport <= 0 && !teleporting)
        {
            teleporting = true;
            while(position == newPosition)
            {
                newPosition = (int)Random.Range(0, teleportPositions.Count - .01f);
            }

            this.transform.position = teleportPositions[newPosition].transform.position;
            position = newPosition;

            nextTeleport = timeUntilTeleport;
            teleporting = false;

        }


        nextTeleport -= Time.deltaTime;
    }
}
