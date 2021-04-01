using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Transform target;
    public Transform startingPosition;

    public int startingHealth;
    private int currentHealth;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject bullet;

    [SerializeField]
    public LayerMask solidObjects;

    private int pointToMoveTo;

    private bool isFollowingPlayer;
    private bool isGoingHome;
    private bool isHome;
    private bool playerInLOS;

    private RaycastHit2D hitInfo;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.parent.transform;
        target = GameObject.FindObjectOfType<Player>().transform;
        currentHealth = startingHealth;

        isFollowingPlayer = false;
        isGoingHome = false;
        isHome = true;
        playerInLOS = false;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange) {
            hitInfo = Physics2D.Raycast(transform.position, target.transform.position - transform.position, Mathf.Infinity, solidObjects);

            if (GameManager.isDebug) {
                Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.green);
            }          
            
                if (hitInfo.collider.CompareTag("Player")) {
                    if (GameManager.isDebug) {
                        Debug.Log("Player in LoS");
                    }
                    playerInLOS = true;
            }
                else {
                    if (GameManager.isDebug) {
                        Debug.Log("Hitting something else: " + hitInfo.collider.name);
                    }
                    playerInLOS = false;
                }
            
        
        }

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange && playerInLOS) {
            isFollowingPlayer = true;
            isHome = false;
            FollowPlayer();
        } 
        else if (Vector3.Distance(target.position, transform.position) >= maxRange && !isHome) {
            isFollowingPlayer = false;
            
            GoToStartingPosition();

        }

        if (isGoingHome && Vector3.Distance(transform.position, startingPosition.position) < 0.2f) {
            isGoingHome = false;
            isHome = true;
        }

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }

        if (timeBetweenShots <= 0 && isFollowingPlayer) {
            Quaternion bulletDrift = Quaternion.Euler(0, 0, Random.Range(-5f, 5f));

            Vector3 dir = (target.transform.position - transform.position);
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

            Instantiate(bullet, transform.position, transform.rotation * bulletDrift);
            timeBetweenShots = startTimeBetweenShots;
        }

        else {
            timeBetweenShots -= Time.deltaTime;
        }

        
    }

    public void FollowPlayer() {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoToStartingPosition() {
        isGoingHome = true;

        if (GameManager.isDebug) {
            Debug.Log("Going Home");
        }

        transform.position = Vector3.MoveTowards(transform.position, startingPosition.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
    }

    
}
