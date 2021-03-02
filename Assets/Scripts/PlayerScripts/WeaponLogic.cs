using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    public float offset;

    public GameObject bullet;
    public Transform startingPoint;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private void Update() {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);

        if (timeBetweenShots <= 0 && !PauseMenu.isPaused) {
            if (Input.GetMouseButtonDown(0)) {
                Instantiate(bullet, startingPoint.position, transform.rotation);
                timeBetweenShots = startTimeBetweenShots;
            }

            
        }
        else {
            timeBetweenShots -= Time.deltaTime;
        }
    }

        

}
