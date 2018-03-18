﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required when Using UI elements.

public class PlayerHealth : MonoBehaviour
{

    private float health = 100.0f;
    public float iTime = 2.0f; //time iframes last
    private bool isInvincible = false;

    private float startHealth;

    public Slider slider;
    // Use this for initialization
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        startHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health / startHealth;
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
        string scenename = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scenename);
    }

    private IEnumerator GiveIFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(iTime);
        isInvincible = false;
    }
}