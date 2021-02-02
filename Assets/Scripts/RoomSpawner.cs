using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int opening; //1, bot. 2, top. 3, left. 4, right. This is what door the point NEEDS

    private void Update() {
        switch (opening) {
            case 1:
            //Need bot
            case 2:
            //Need top
            case 3:
            //Need left
            case 4:
            //Need right
            break;
        }
    }
}
