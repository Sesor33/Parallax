using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public int startingHealth = 50;
    [HideInInspector]
    public int currentHealth;

    public GameManager gm;

    //[HideInInspector]
    public HealthBar playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        //Find game manager, reference it, initialize health bar
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerHealthBar = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
        currentHealth = startingHealth;
        playerHealthBar.SetMaxHealth(startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            gm.LoadNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(5);

        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);
    }
}
