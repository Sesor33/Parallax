using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private RoomTemplates templates;

    private void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Decoration") {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Room") {
            templates.rooms.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
        
        
    }
}
