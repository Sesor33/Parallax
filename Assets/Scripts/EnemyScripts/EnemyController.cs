﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Transform target;
    public Transform startingPosition;

    public int startingHealth;
    private int currentHealth;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private float moveWaitTime;
    public float startMoveWaitTime;

    public GameObject bullet;

    private bool isFollowingPlayer;
    private bool isGoingHome;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.parent.transform;
        target = GameObject.FindObjectOfType<Player>().transform;
        currentHealth = startingHealth;
        isFollowingPlayer = false;
        isGoingHome = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        


        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange) {
            isFollowingPlayer = true;

            FollowPlayer();
        } 
        else if (Vector3.Distance(target.position, transform.position) >= maxRange) {
            isFollowingPlayer = false;

            GoToStartingPosition();

        }

        if (isGoingHome && Vector3.Distance(transform.position, startingPosition.position) < 0.2f) {
            isGoingHome = false;
        }

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }

        if (timeBetweenShots <= 0 && isFollowingPlayer) {
            Quaternion bulletDrift = Quaternion.Euler(0, 0, Random.Range(-5f, 5f));

            Instantiate(bullet, transform.position, transform.rotation * bulletDrift);
            timeBetweenShots = startTimeBetweenShots;
        }

        if (moveWaitTime <= 0 && !isFollowingPlayer && !isGoingHome) {
            if (GameManager.isDebug) {
                Debug.Log("Trying to roam");
            }
        }

        else {
            timeBetweenShots -= Time.deltaTime;
        }

        
    }

    public void FollowPlayer() {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoToStartingPosition() {
        isGoingHome = true;
        transform.position = Vector3.MoveTowards(transform.position, startingPosition.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
    }
}
