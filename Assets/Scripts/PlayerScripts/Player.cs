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

    private bool isInvulnerable;


    // Start is called before the first frame update
    void Start()
    {
        //Find game manager, reference it, initialize health bar        
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerHealthBar = FindObjectOfType<HealthBar>().GetComponent<HealthBar>();
        currentHealth = startingHealth;
        playerHealthBar.SetMaxHealth(startingHealth);
        isInvulnerable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && GameManager.isDebug) {
            GameManager.instance.LoadNextLevel();
        }
    }

    public void TakeDamage(int damage) {
        if (!isInvulnerable) {
            currentHealth -= damage;
            playerHealthBar.SetHealth(currentHealth);

            if (currentHealth > 0) {
                StartCoroutine("IFrames");
            }
        }
        
    }

    public void HealPlayer(int healAmount) {
        if (currentHealth + healAmount > startingHealth) {
            currentHealth = 50;
        }

        else {
            currentHealth += healAmount;
        }

        playerHealthBar.SetHealth(currentHealth);
    }

    IEnumerator IFrames() {

        isInvulnerable = true;
        
        
        yield return new WaitForSeconds(1f);

        
        isInvulnerable = false;
    }
}
