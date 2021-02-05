using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int opening; //1, bot. 2, top. 3, left. 4, right. This is what door the point NEEDS

    private RoomTemplates templates;

    private int rngRngPleaseBeNiceToMe;
    private bool isSpawned = false;

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnNewRoom", 0.1f);
    }

    void SpawnNewRoom() {
        if (isSpawned == false) {
            switch (opening) {
                case 1:
                    rngRngPleaseBeNiceToMe = Random.Range(0, templates.botRooms.Length);
                    Instantiate(templates.botRooms[rngRngPleaseBeNiceToMe], transform.position, Quaternion.identity);
                    break;
                case 2:
                    rngRngPleaseBeNiceToMe = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rngRngPleaseBeNiceToMe], transform.position, Quaternion.identity);
                    break;
                //Need top
                case 3:
                    rngRngPleaseBeNiceToMe = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rngRngPleaseBeNiceToMe], transform.position, Quaternion.identity);
                    break;
                //Need left
                case 4:
                    rngRngPleaseBeNiceToMe = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rngRngPleaseBeNiceToMe], transform.position, Quaternion.identity);
                    break;
                    //Need right
            }
            isSpawned = true;
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("SpawnPoint") ) {
            if (other.GetComponent<RoomSpawner>().isSpawned == false && isSpawned == false) {
                Instantiate(templates.decorations, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            isSpawned = true;
            
        }
    }
}
