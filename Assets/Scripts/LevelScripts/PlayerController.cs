using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    Rigidbody2D rig;

    public Text collectedScore;
    public static int numBits = 0;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rig.velocity = new Vector3(h * playerSpeed, v * playerSpeed, 0);
        collectedScore.text = "Bits: " + numBits;
    }
}
