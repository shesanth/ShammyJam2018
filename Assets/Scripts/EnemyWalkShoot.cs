using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkShoot : MonoBehaviour {
    public GameObject bullet;


    //for shooting
    public float bulletSpeed = 5f;
    public float timeBetweenBurstShots = .5f;
    public int numPerBurst = 2;
    bool shooting = false;

    //distance where he starts to actually shoot
    public float aggroDistance = 6f;

    //positions he moves between
    public GameObject startPosition;
    public GameObject endPosition;
    public float speed = 2f;
    int directionFacing;
    Vector3 destination;

    Transform target;

    void Awake()
    {
        this.transform.position = startPosition.transform.position;
        target = FindObjectOfType<PlayerMovement>().transform;
        destination = endPosition.transform.position;
        if(destination.x < this.transform.position.x)
        {
            directionFacing = -1;
        }
        else
        {
            directionFacing = 1;
        }
    }

    void FixedUpdate()
    {
        if (!shooting)
        {
            if (transform.position != destination)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            }
            else
            {
                if (transform.position == startPosition.transform.position && destination == startPosition.transform.position)
                {
                    destination = endPosition.transform.position;
                    if (Mathf.Abs(this.transform.position.x - target.transform.position.x) <= 6)
                    {
                        shooting = true;
                        StartCoroutine(FireShots(numPerBurst));
                    }
                }
                else if (transform.position == endPosition.transform.position && destination == endPosition.transform.position)
                {
                    destination = startPosition.transform.position;
                    if (Mathf.Abs(this.transform.position.x - target.transform.position.x) <= 6)
                    {
                        shooting = true;
                        StartCoroutine(FireShots(numPerBurst));
                    }
                }
            }
        }   
    }

    public void DoShoot()
    {
        GameObject b = Instantiate(bullet, this.transform.position + (new Vector3(.5f, 0, 0) * directionFacing), Quaternion.identity);
        b.GetComponent<Rigidbody>().velocity = (target.position - (this.transform.position + (new Vector3(.5f, 0, 0) * directionFacing))).normalized * bulletSpeed;
    }

    IEnumerator FireShots(int shotsLeft)
    {
        yield return new WaitForSeconds(timeBetweenBurstShots);
        if (shotsLeft > 0)
        {
            DoShoot();
            StartCoroutine(FireShots(shotsLeft - 1));
        }
        else
        {
            shooting = false;
        }
    }
}
