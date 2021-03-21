using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float speed;
    public float bulletLifetime;
    public float dist;
    public int bulletDamage;
    public LayerMask solidObjects;

    public GameObject destroyEffect;

    private void Start() {
        Invoke("DestroyBullet", bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, dist, solidObjects);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy")) {
                
                if (GameManager.isDebug) {
                    Debug.Log("Enemy takes damage here");
                }

                hitInfo.collider.GetComponent<EnemyController>().TakeDamage(bulletDamage);
                
            }
            DestroyBullet();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyBullet() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
