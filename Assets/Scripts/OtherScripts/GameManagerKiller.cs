using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerKiller : MonoBehaviour
{

    private GameObject gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        if (gm == null) {
            return;
        }
        else {
            Destroy(gm);
        }
    }

   
}
