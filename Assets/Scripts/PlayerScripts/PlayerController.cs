﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    Rigidbody2D rig;

    private bool canMove;

    //public Text collectedScore;
    //public static int numBits = 0;

    // Start is called before the first frame update
    void Start()
    {   
        canMove = false;
        rig = GetComponent<Rigidbody2D>();
        Invoke("startMove", 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.playerIsDead && canMove) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            rig.velocity = new Vector3(h * playerSpeed, v * playerSpeed, 0);
        }

        else {
            rig.velocity = new Vector3(0, 0, 0);
        }
        
        //collectedScore.text = "Bits: " + numBits;
    }

    void startMove() {
        canMove = true;
    }
}
