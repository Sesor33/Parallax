using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationBackup : MonoBehaviour {
    public Transform[] startingPositions;
    public GameObject[] rooms; // 0 -> LR, 1 -> LRB, 2 -> LRT, 3 -> LRTB
    public GameObject[] specialTiles;

    private int direction;
    public float moveAmount;

    private float timeBetweenRoom;
    public float startTimeBetweenRoom = 0.25f; //Call move() every x seconds

    public bool stopGeneration;

    //minX is where it starts in terms of x,y coords
    //maxX and minY are the number of rooms you want in that direction

    public float minX;
    public float maxX;
    public float minY;
    public float xUnits;
    public float yUnits;

    public LayerMask room;

    private int downCount;

    void Start() {
        int randStartingPos = Random.Range(0, startingPositions.Length); //Start at Position (pos) on top layer
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6); //Determines direction next room will spawn
    }

    private void Update() {
        if (timeBetweenRoom <= 0 && stopGeneration == false) {
            Move();
            timeBetweenRoom = startTimeBetweenRoom;
        }

        else {
            timeBetweenRoom -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    private void Move() {
        if (direction == 1 || direction == 2) //GO RIGHT
        {       

            if (transform.position.x < maxX) {
                downCount = 0;

                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6); //Pick new direction

                //Prevent overlap by forcing it to go either right or down
                if (direction == 3) {
                    direction = 2;
                }
                else if (direction == 4) {
                    direction = 5;
                }
            }
            else {
                direction = 5; //GO DOWN
            }


        }
        else if (direction == 3 || direction == 4) //GO LEFT
        {
            
            if (transform.position.x > minX) {
                downCount = 0;

                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length); 
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6); //Force generator to go left or down

            }
            else {
                direction = 5;
            }


        }
        else if (direction == 5) //GO DOWN
        {

            downCount++; //Level has moved down

            if (transform.position.y > minY) {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3) {

                    if (downCount >= 2) {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }

                    else {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2) {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }

                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4); //Force room with top opening to spawn
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6); //Doesn't matter which direction it moves in
            }
            else {
                //STOP GEN, place exit
                stopGeneration = true;
                Instantiate(specialTiles[0], transform.position, Quaternion.identity); //Spawn exit
            }


        }

        //Instantiate(rooms[0], transform.position, Quaternion.identity);

    }

}
