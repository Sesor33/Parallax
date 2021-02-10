using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] botRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject decorations;

    public List<GameObject> rooms;

    public float timeUntilExitpawns;
    private bool exitSpawned;
    private bool playerSpawned;

    public GameObject playerCharacter;
    public GameObject exit;

    private void Start() {
        Instantiate(playerCharacter, rooms[0].transform.position, Quaternion.identity);
    }

    void Update() {
        if (timeUntilExitpawns <= 0 && !exitSpawned) {
            Instantiate(exit, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            exitSpawned = true;
        } 
        else {
            timeUntilExitpawns -= Time.deltaTime;
        }
    }
}
