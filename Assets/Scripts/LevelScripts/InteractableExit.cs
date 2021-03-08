using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableExit : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange) {
            if (Input.GetKeyDown(interactKey)) {

            }
        }
    }
}
