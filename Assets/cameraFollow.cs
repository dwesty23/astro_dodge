using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 1f;

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}