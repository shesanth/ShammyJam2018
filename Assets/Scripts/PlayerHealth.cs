using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private float health = 100.0f;
    public float iTime = 2.0f; //time iframes last
    private bool isInvincible = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    //callable function that deals damage to the player and activates iframes
    public void takeDamage(float damage)
    {
        if (isInvincible)
        {
            return;
        }
        health = health - damage;
        if (health <= 0)
        {
            KillPlayer();
        }
        StartCoroutine(GiveIFrames());
    }

    //handles players death
    public void KillPlayer()
    {
        return;
    }

    private IEnumerator GiveIFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(iTime);
        isInvincible = false;
    }
}