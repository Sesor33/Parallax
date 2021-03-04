﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public int startingHealth = 50;
    [HideInInspector]
    public int currentHealth;

    //[HideInInspector]
    public HealthBar playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthBar = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
        currentHealth = startingHealth;
        playerHealthBar.SetMaxHealth(startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DamagePlayer(5);
        }
    }

    void DamagePlayer(int damage) {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);
    }
}