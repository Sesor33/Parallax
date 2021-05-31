using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperLaser : MonoBehaviour
{
    private LineRenderer laser;
    private Transform target;

    private RaycastHit2D hitInfo;

    [SerializeField]
    public LayerMask solidObjects;

    public int laserMaxRange;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<Player>().transform;
        laser = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        laser.SetPosition(0, transform.position);
        if (Vector3.Distance(target.position, transform.position) <= laserMaxRange) {
            hitInfo = Physics2D.Raycast(transform.position, target.transform.position - transform.position, Mathf.Infinity, solidObjects);
            laser.SetPosition(1, hitInfo.point);
            //laser.SetPosition(1, target.transform.position);
        }

        else {
            laser.SetPosition(1, transform.position);
        }
    }
}
