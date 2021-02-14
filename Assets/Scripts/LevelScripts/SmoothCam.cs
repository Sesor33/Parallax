using UnityEngine;

public class SmoothCam : MonoBehaviour {
    public Transform objectToFollow;
    public Vector3 camOffset;
    [Range(1, 10)]
    public float smoothing;

    private void Start() {
        Invoke("setPlayerFollow", 0.1f);
    }

    private void FixedUpdate() {
        FollowObject();
    }

    private void setPlayerFollow() {
        objectToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FollowObject() {
        Vector3 targetPos = objectToFollow.position + camOffset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothing * Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
}