using UnityEngine;

public class SmoothCam : MonoBehaviour {
    public Transform objectToFollow;
    public Vector3 camOffset;
    [Range(1, 10)]
    public float smoothing;

    private bool followEnabled;

    private void Start() {
        followEnabled = false;
        Invoke("setPlayerFollow", 0.1f);
        Invoke("enableFollowing", 1f);
    }

    private void FixedUpdate() {
        if (followEnabled) {
            FollowObject();
        }     
    }

    private void setPlayerFollow() {
        objectToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void enableFollowing() {
        followEnabled = true;
    }

    void FollowObject() {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = objectToFollow.position + camOffset;
        Vector3 midPos = new Vector3(((targetPos.x + diff.x) / 2), ((targetPos.y + diff.y) / 2), ((targetPos.z + diff.z) / 2));
        Vector3 smoothPos = Vector3.Lerp(transform.position , midPos, smoothing * Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
}