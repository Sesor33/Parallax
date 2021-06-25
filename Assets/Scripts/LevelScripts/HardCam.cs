using UnityEngine;

public class HardCam : MonoBehaviour {
    public Transform objectToFollow;
    

    private bool followEnabled;

    private void Start() {
        Invoke("setPlayerFollow", 0.1f);
    }

    private void FixedUpdate() {
              FollowObject();
          
    }

    private void setPlayerFollow() {
        objectToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    

    void FollowObject()
    {
        this.transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, this.transform.position.z);
    }
}