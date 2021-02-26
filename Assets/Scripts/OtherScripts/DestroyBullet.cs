using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
    
{
    public float effectTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThis", effectTime);
    }

    void DestroyThis() {
        Destroy(gameObject);
    }
}
