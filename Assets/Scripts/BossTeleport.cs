using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport : MonoBehaviour
{
    //time between teleports
    public float timeUntilTeleport = 5f;
    float nextTeleport;
    bool teleporting = false;

    //how long after teleport he shoots
    public float shotDelay = 1f;
    float nextShot;
    public int numPerBurst = 3;
    public float timeBetweenBurstShots = .3f;
    bool hasShot = false;
    


    //empty game objects at locations boss can go to, new position is randomly assigned on teleport
    public List<GameObject> teleportPositions;
    int position = 0;
    int newPosition = 0;

    Transform player;

    // Use this for initialization
    void Awake()
    {
        nextTeleport = timeUntilTeleport;
        nextShot = shotDelay;
        this.transform.position = teleportPositions[0].transform.position;
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nextTeleport <= 0 && !teleporting)
        {
            teleporting = true;
            while (position == newPosition)
            {
                newPosition = (int)Random.Range(0, teleportPositions.Count - .01f);
            }

            this.transform.position = teleportPositions[newPosition].transform.position;
            position = newPosition;

            nextTeleport = timeUntilTeleport;
            hasShot = false;
            teleporting = false;
            nextShot = shotDelay;
            
        }
        if(nextShot <= 0 && !hasShot)
        {
            hasShot = true;
            StartCoroutine(FireShots(numPerBurst));
        }

        nextShot -= Time.deltaTime;
        nextTeleport -= Time.deltaTime;
    }

    IEnumerator FireShots(int shotsLeft)
    {
        yield return new WaitForSeconds(timeBetweenBurstShots);
        if (shotsLeft > 0)
        {
            this.GetComponent<Shoot>().DoShootBoss(player);
            StartCoroutine(FireShots(shotsLeft- 1));
        }
    }
}
