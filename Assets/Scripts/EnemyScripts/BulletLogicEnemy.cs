using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogicEnemy : MonoBehaviour
{
    public float speed;
    public float bulletLifetime;
    public float dist;
    public int bulletDamage;
    public LayerMask solidObjects;

    public GameObject destroyEffect;

    private Transform player;
    private Vector3 target;

    private void Start() {
        player = GameObject.FindObjectOfType<Player>().transform;
        target = new Vector2(player.position.x, player.position.y);

        Invoke("DestroyBullet", bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, dist, solidObjects);
        if (hitInfo.collider != null) {

            if (hitInfo.collider.CompareTag("Player")) {
                if (GameManager.isDebug) {
                    Debug.Log("Player takes damage here");
                }

                hitInfo.collider.GetComponent<Player>().TakeDamage(bulletDamage);
            }
            DestroyBullet();
        }

        //transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestroyBullet();
        }
    }

    void DestroyBullet() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
