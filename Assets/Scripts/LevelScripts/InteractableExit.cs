using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableExit : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;

    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange) {
            if (Input.GetKeyDown(interactKey)) {
                gm.LoadNextLevel();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isInRange = true;
            Debug.Log("In range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isInRange = false;
            Debug.Log("Out of range");
        }
    }
}
