using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    [SerializeField]
    public int healAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().HealPlayer(healAmount);
            AudioManager.instance.Play("HealthPickup");
            Destroy(gameObject);
        }
    }
}
