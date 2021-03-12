using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    public float offset;

    public GameObject bullet;
    public Transform startingPoint;
    public AudioManager am;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private void Start() {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update() {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);

        if (timeBetweenShots <= 0 && !PauseMenu.isPaused) {
            if (Input.GetMouseButtonDown(0)) {
                Quaternion bulletDrift = Quaternion.Euler(0, 0, Random.Range(-5f,5f)); //Pick random drift range
                Instantiate(bullet, startingPoint.position, transform.rotation * bulletDrift); //Fire bullet with drift
                am.Play("BlasterSFX1"); //Self explanatory
                timeBetweenShots = startTimeBetweenShots; //Restart timer
            }

            
        }
        else {
            timeBetweenShots -= Time.deltaTime;
        }
    }

        

}
