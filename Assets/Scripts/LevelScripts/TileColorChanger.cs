using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColorChanger : MonoBehaviour
{
    private Renderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<Renderer>();

        switch (GameManager.floor) {
            case 1:
                break;
            case 2:
                spriteRend.material.color = new Color32(0,0,200,255);
                break;
        }
    }

    
}
